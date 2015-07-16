using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplexUniverse.Simulations
{
    /// <summary>
    /// Represents a timer whose tick interval is in microseconds rather than milliseconds.
    /// NOTE: This timer's accuracy is dependent on the system it is run on.
    /// </summary>
    public class MicroTimer
    {
        //The event handler for the timer
        public delegate void MicroTimerElapsedEventHandler(object sender, MicroTimerEventArgs timerEventArgs);
        public event MicroTimerElapsedEventHandler MicroTimerElapsed;

        //Private (hidden) variables
        System.Threading.Thread _threadTimer = null;
        long _ignoreEventIfLateBy = long.MaxValue;
        private long Interval_Field = 0;
        bool _stopTimer = true;
        //--------------------------

        /// <summary>
        /// Creates a new MicroTimer object
        /// </summary>
        public MicroTimer()
        {
        }

        /// <summary>
        /// Creates a new MicroTimer with a particular tick interval in microseconds.
        /// </summary>
        /// <param name="Interval"></param>
        public MicroTimer(long Interval)
        {
            this.Interval = Interval;
        }

        /// <summary>
        /// The tick interval of this timer in microseconds.
        /// </summary>
        public long Interval
        {
            get
            {
                return System.Threading.Interlocked.Read(ref Interval_Field);
            }
            set
            {
                System.Threading.Interlocked.Exchange(ref Interval_Field, value);
            }
        }

        /// <summary>
        /// Ignores the tick event if the timer is late by a particular value
        /// </summary>
        public long IgnoreEventIfLateBy
        {
            get
            {
                return System.Threading.Interlocked.Read(ref _ignoreEventIfLateBy);
            }
            set
            {
                System.Threading.Interlocked.Exchange(ref _ignoreEventIfLateBy, value <= 0 ? long.MaxValue : value);
            }
        }

        /// <summary>
        /// Whether this timer is enabled or not.
        /// </summary>
        public bool Enabled
        {
            set
            {
                if (value)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
            get
            {
                return (_threadTimer != null && _threadTimer.IsAlive);
            }
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            if (Enabled || Interval_Field <= 0)
            {
                return;
            }

            _stopTimer = false;

            System.Threading.ThreadStart threadStart = delegate()
            {
                NotificationTimer(ref Interval_Field, ref _ignoreEventIfLateBy, ref _stopTimer);
            };

            _threadTimer = new System.Threading.Thread(threadStart);
            _threadTimer.Priority = System.Threading.ThreadPriority.Highest;
            _threadTimer.Start();
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            _stopTimer = true;
        }

        /// <summary>
        /// Stops the timer synchronously, and will not return until the current timer (callback) event has finished and the timer thread has terminated.
        /// </summary>
        public void StopAndWait()
        {
            StopAndWait(System.Threading.Timeout.Infinite);
        }

        /// <summary>
        /// Stops the timer synchronously, and will not return until the current timer (callback) event has finished and the timer thread has terminated.
        /// Returns "true" if the timer is stopped within the given interval in milliseconds
        /// </summary>
        /// <param name="Timeout">The timeout interval in milliseconds</param>
        public bool StopAndWait(int Timeout)
        {
            _stopTimer = true;

            if (!Enabled || _threadTimer.ManagedThreadId == System.Threading.Thread.CurrentThread.ManagedThreadId)
            {
                return true;
            }

            return _threadTimer.Join(Timeout);
        }

        /// <summary>
        /// Forcefully terminates the timer thread
        /// </summary>
        public void Abort()
        {
            _stopTimer = true;

            if (Enabled)
            {
                _threadTimer.Abort();
            }
        }

        void NotificationTimer(ref long timerIntervalInMicroSec, ref long ignoreEventIfLateBy, ref bool stopTimer)
        {
            int timerCount = 0;
            long nextNotification = 0;

            MicroStopwatch microStopwatch = new MicroStopwatch();
            microStopwatch.Start();

            while (!stopTimer)
            {
                long callbackFunctionExecutionTime = microStopwatch.ElapsedMicroseconds - nextNotification;

                long timerIntervalInMicroSecCurrent = System.Threading.Interlocked.Read(ref timerIntervalInMicroSec);
                long ignoreEventIfLateByCurrent = System.Threading.Interlocked.Read(ref ignoreEventIfLateBy);

                nextNotification += timerIntervalInMicroSecCurrent;
                timerCount++;
                long elapsedMicroseconds = 0;

                while ((elapsedMicroseconds = microStopwatch.ElapsedMicroseconds)
                        < nextNotification)
                {
                    System.Threading.Thread.SpinWait(10);
                }

                long timerLateBy = elapsedMicroseconds - nextNotification;

                if (timerLateBy >= ignoreEventIfLateByCurrent)
                {
                    continue;
                }

                MicroTimerEventArgs microTimerEventArgs = new MicroTimerEventArgs(timerCount, elapsedMicroseconds, timerLateBy, callbackFunctionExecutionTime);
                MicroTimerElapsed(this, microTimerEventArgs);
            }

            microStopwatch.Stop();
        }
    }


    /// <summary>
    /// MicroStopwatch class
    /// </summary>
    public class MicroStopwatch : System.Diagnostics.Stopwatch
    {
        readonly double _microSecPerTick = 1000000D / System.Diagnostics.Stopwatch.Frequency;

        public MicroStopwatch()
        {
            if (!System.Diagnostics.Stopwatch.IsHighResolution)
            {
                throw new Exception("On this system the high-resolution " +
                                    "performance counter is not available");
            }
        }

        /// <summary>
        /// The number of elapsed microseconds
        /// </summary>
        public long ElapsedMicroseconds
        {
            get
            {
                return (long)(ElapsedTicks * _microSecPerTick);
            }
        }
    }

    /// <summary>
    /// MicroTimer Event Argument class
    /// </summary>
    public class MicroTimerEventArgs : EventArgs
    {
        // Simple counter, number times timed event (callback function) executed
        public int TimerCount { get; private set; }

        // Time when timed event was called since timer started
        public long ElapsedMicroseconds { get; private set; }

        // How late the timer was compared to when it should have been called
        public long TimerLateBy { get; private set; }

        // Time it took to execute previous call to callback function (OnTimedEvent)
        public long CallbackFunctionExecutionTime { get; private set; }

        public MicroTimerEventArgs(int timerCount, long elapsedMicroseconds, long timerLateBy, long callbackFunctionExecutionTime)
        {
            TimerCount = timerCount;
            ElapsedMicroseconds = elapsedMicroseconds;
            TimerLateBy = timerLateBy;
            CallbackFunctionExecutionTime = callbackFunctionExecutionTime;
        }

    }
}
