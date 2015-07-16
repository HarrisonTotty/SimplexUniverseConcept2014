using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;
using System.Threading.Tasks;

namespace SimplexUniverse.VisualizationComponents
{
    /// <summary>
    /// Represents a 2D/3D plotting grid for visualizing physics universes.
    /// All custom methods/properties (those that are not inherited) are preceded by "VG_".
    /// </summary>
    public class VisualizationGrid : System.Windows.Forms.DataVisualization.Charting.Chart
    {
        /// <summary>
        /// The private boolean for VG_3DMode
        /// </summary>
        private bool VG_3DMode_Field = false;

        /// <summary>
        /// The private int for VG_XIndex
        /// </summary>
        private int VG_XIndex_Field = 0;

        /// <summary>
        /// The private int for VG_YIndex
        /// </summary>
        private int VG_YIndex_Field = 1;

        /// <summary>
        /// Creates a new visualization grid with the default settings.
        /// </summary>
        public VisualizationGrid()
        {
            //Intialize the grid
            VG_ReinitializeGrid();

            //Handle some events
            this.MouseWheel += VisualizationGrid_MouseWheel;
            this.PreviewKeyDown += VisualizationGrid_PreviewKeyDown;
            this.MouseDown += VisualizationGrid_MouseDown;
            this.MouseUp += VisualizationGrid_MouseUp;
            this.MouseMove += VisualizationGrid_MouseMove;
        }

        /// <summary>
        /// Paused that handles the mouse moving across the visualization grid
        /// </summary>
        void VisualizationGrid_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If we are in 3D mode:
            if (this.VG_3DMode)
            {
                //If we are panning:
                if (this.VG_DragPan && VG_Panning_Field)
                {
                    try
                    {
                        //Find the new click location
                        int[] NewClickLocation = new int[2] { e.Location.X, e.Location.Y };

                        //Calculate the change
                        int ClickChangeX = NewClickLocation[0] - VG_DragPanPreviousClickLocation_Field[0];
                        //int ClickChangeY = NewClickLocation[1] - VG_DragPanPreviousClickLocation_Field[1];

                        //Rotate the camera
                        VG_RotateCameraAroundOrigin(ClickChangeX / 25, false);
                        //VG_RotateCameraAroundOrigin(ClickChangeY / 25, true);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else //Otherwise:
            {
                //If we are panning:
                if (this.VG_DragPan && VG_Panning_Field)
                {
                    try
                    {
                        //Find the new click location
                        int[] NewClickLocation = new int[2] { e.Location.X, e.Location.Y };

                        
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        /// <summary>
        /// Event that handles the mouse button being released on the visualization grid
        /// </summary>
        void VisualizationGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.VG_DragPan && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                VG_Panning_Field = false;
            }
        }

        /// <summary>
        /// Event that handles the mouse button being pressed down the visualization grid
        /// </summary>
        void VisualizationGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.VG_DragPan && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                VG_Panning_Field = true;
                VG_DragPanPreviousClickLocation_Field = new int[2] { e.Location.X, e.Location.Y };
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

            }
        }

        /// <summary>
        /// Handles various key presses.
        /// </summary>
        void VisualizationGrid_PreviewKeyDown(object sender, System.Windows.Forms.PreviewKeyDownEventArgs e)
        {
            if (this.VG_3DMode)
            {
                this.VG_Handle3DButtonPress(e.KeyData);
            }
            else
            {
                switch (e.KeyData)
                {
                    //Toggle the grid
                    case System.Windows.Forms.Keys.G:
                        ((VG_ChartArea)(this.ChartAreas[0])).VG_ToggleGrid();
                        break;

                    //Toggle the axes
                    case System.Windows.Forms.Keys.A:
                        ((VG_ChartArea)(this.ChartAreas[0])).VG_ToggleAxis();
                        break;

                    //Toggle point watcher plotting
                    case System.Windows.Forms.Keys.T:
                        this.VG_PlotPointWatcherTrails = !this.VG_PlotPointWatcherTrails;
                        break;

                    //Toggle point mode
                    case System.Windows.Forms.Keys.P:
                        if (((VG_Series)(this.Series[0])).VG_PointMode)
                        {
                            ((VG_Series)(this.Series[0])).VG_PointMode_OFF();
                        }
                        else
                        {
                            ((VG_Series)(this.Series[0])).VG_PointMode_ON();
                        }
                        break;

                    //ZOOM IN
                    case System.Windows.Forms.Keys.Oemplus:
                        this.VG_SetSize(this.VG_Size - (this.VG_Size * 0.1));
                        break;

                    //ZOOM OUT
                    case System.Windows.Forms.Keys.OemMinus:
                        this.VG_SetSize(this.VG_Size + (this.VG_Size * 0.1));
                        break;

                    //MOVE LEFT
                    case System.Windows.Forms.Keys.Left:
                        Vector NewOrgL = Vector.Vector_Copy(this.VG_Origin);
                        NewOrgL[this.VG_XIndex] -= (this.VG_Size * 0.1);
                        this.VG_SetOrigin(NewOrgL);
                        break;

                    //MOVE RIGHT
                    case System.Windows.Forms.Keys.Right:
                        Vector NewOrgR = Vector.Vector_Copy(this.VG_Origin);
                        NewOrgR[this.VG_XIndex] += (this.VG_Size * 0.1);
                        this.VG_SetOrigin(NewOrgR);
                        break;

                    //MOVE UP
                    case System.Windows.Forms.Keys.Up:
                        Vector NewOrgU = Vector.Vector_Copy(this.VG_Origin);
                        NewOrgU[this.VG_YIndex] += (this.VG_Size * 0.1);
                        this.VG_SetOrigin(NewOrgU);
                        break;

                    //MOVE DOWN
                    case System.Windows.Forms.Keys.Down:
                        Vector NewOrgD = Vector.Vector_Copy(this.VG_Origin);
                        NewOrgD[this.VG_YIndex] -= (this.VG_Size * 0.1);
                        this.VG_SetOrigin(NewOrgD);
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Handles zooming of the grid via mouse wheel when enabled.
        /// </summary>
        void VisualizationGrid_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //If zooming is enabled:
            if (this.VG_MouseWheelZoom)
            {
                //If 3D mode is the enabled:
                if (this.VG_3DMode)
                {
                    if (e.Delta > 0)
                    {
                        VG_CameraZoomToOrigin(-20);
                    }
                    else
                    {
                        VG_CameraZoomToOrigin(20);
                    }
                }
                else //Otherwise if we are in 2D:
                {
                    double ZoomPercent = System.Math.Abs(e.Delta) * 0.001;
                    //If the wheel was moved forward:
                    if (e.Delta > 0)
                    {
                        //ZOOM IN
                        this.VG_SetSize(this.VG_Size - (this.VG_Size * ZoomPercent));

                    }
                    else //Otherwise if the wheel was moved backward:
                    {
                        //ZOOM OUT
                        this.VG_SetSize(this.VG_Size + (this.VG_Size * ZoomPercent));
                    }
                }
            }
        }

        /// <summary>
        /// Reinitializes the grid to its default settings.
        /// </summary>
        public void VG_ReinitializeGrid()
        {
            //SETUP PREMADE SETTINGS
            this.Name = "Grid";
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            VG_ClearChartComponents();
            this.Titles.Add("GenerationCount");
            this.Titles[0].Text = "Generation 0";
            this.Titles[0].Visible = true;
            this.Series.Add(new VG_Series());
            this.ChartAreas.Add(new VG_ChartArea());
            this.Series[0].ChartArea = this.ChartAreas[0].Name;


            //SETUP CUSTOM SETTINGS
            this.VG_ZIndex = 2;
            this.VG_DragPan = true;
            this.VG_Panning_Field = false;
            this.VG_Size = 100;
            this.VG_MouseWheelZoom = true;
            this.VG_Origin = new Vector(3);
            this.VG_3DCameraPosition = Vector.Vector_FromArray(new double[] { 0, 0, 0 });
            this.VG_3DCameraOrientation = new Orientation3D();
            this.VG_3DFOV = 90;
            this.VG_PlotPointWatcherTrails = true;
            this.VG_PointWatcherTrailFrequency = 1;
        }

        /// <summary>
        /// A boolean value determining if the chart is currently in 3D mode.
        /// </summary>
        public bool VG_3DMode
        {
            get
            {
                return VG_3DMode_Field;
            }
            set
            {
                if (value == false)
                {
                    //Stylize the chart area
                    ((VG_ChartArea)this.ChartAreas[0]).VG_SetStyle_2D();

                    //Stylize the points
                    ((VG_Series)this.Series[0]).VG_SetStyle_2D();
                }
                else
                {
                    //Stylize the chart area
                    ((VG_ChartArea)this.ChartAreas[0]).VG_SetStyle_3D();

                    //Stylize the points
                    ((VG_Series)this.Series[0]).VG_SetStyle_3D();
                }
                VG_3DMode_Field = value;
            }
        }

        /// <summary>
        /// Clears the chart of all series, annotations, titles, legends, and chart areas.
        /// </summary>
        public void VG_ClearChartComponents()
        {
            this.Series.Clear();
            this.Annotations.Clear();
            this.Titles.Clear();
            this.ChartAreas.Clear();
            this.Legends.Clear();
        }

        /// <summary>
        /// Attempts to add a 2D point to the grid with the specified position and radius.
        /// </summary>
        /// <param name="Position">The position of the particle to add</param>
        /// <param name="Radius">The radius of the particle to add</param>
        public void VG_AddPoint2D(Vector Position, double Radius)
        {
            //If the capacity is too low, we need to return
            if (Position.Capacity < 2) return;

            //If we are in point mode:
            if (((VG_Series)(this.Series[0])).VG_PointMode)
            {
                VG_Point newpoint = new VG_Point(Position[this.VG_XIndex], Position[this.VG_YIndex], ((VG_Series)(this.Series[0])).MarkerSize, false);
                this.Series[0].Points.Add(newpoint);
            }
            else //Otherwise plot it like normal:
            {
                int EffectiveRadius = VG_RadiusToMarkerSize_2D(Radius);
                VG_Point newpoint = new VG_Point(Position[this.VG_XIndex], Position[this.VG_YIndex], EffectiveRadius, false);
                this.Series[0].Points.Add(newpoint);
            }
        }

        /// <summary>
        /// Represents a vector for the position of the camera in world coordinates
        /// </summary>
        public Vector VG_3DCameraPosition
        {
            get;
            set;
        }

        /// <summary>
        /// Represents the current dirction of the camera in degrees.
        /// </summary>
        public Orientation3D VG_3DCameraOrientation
        {
            get;
            set;
        }

        /// <summary>
        /// Represents the index of a position vector to pull the x-axis value from (default: 0)
        /// </summary>
        public int VG_XIndex
        {
            get
            {
                return VG_XIndex_Field;
            }
            set
            {
                if (value >= 0)
                {
                    //If we are in 3D mode, do nothing special
                    if (VG_3DMode)
                    {
                        VG_XIndex_Field = value;
                    }
                    else //Otherwise also set the axis to the appropriate label
                    {
                        string pickme = "xyzqwabcdefghijklmnoprstuv";
                        this.ChartAreas[0].AxisX.Title = pickme[value].ToString().ToUpper() + " Component";
                        VG_XIndex_Field = value;
                    }
                }
            }
        }

        /// <summary>
        /// Represents the index of a position vector to pull the y-axis value from (default: 1)
        /// </summary>
        public int VG_YIndex
        {
            get
            {
                return VG_YIndex_Field;
            }
            set
            {
                if (value >= 0)
                {
                    //If we are in 3D mode, do nothing special
                    if (VG_3DMode)
                    {
                        VG_YIndex_Field = value;
                    }
                    else //Otherwise also set the axis to the appropriate label
                    {
                        string pickme = "xyzqwabcdefghijklmnoprstuv";
                        this.ChartAreas[0].AxisY.Title = pickme[value].ToString().ToUpper() + " Component";
                        VG_YIndex_Field = value;
                    }
                }
            }
        }

        /// <summary>
        /// Represents the index of a position vector to pull the z-axis value from (default: 2)
        /// </summary>
        public int VG_ZIndex
        {
            get;
            set;
        }

        /// <summary>
        /// A vector representing the relative origin (center) of the visualization grid.
        /// DO NOT MANUALLY SET THIS VALUE (use VG_SetOrigin).
        /// </summary>
        public Vector VG_Origin
        {
            get;
            set;
        }

        /// <summary>
        /// Represents the size (radius from origin) of this grid.
        /// DO NOT MANUALLY SET THIS VALUE (use VG_SetSize).
        /// </summary>
        public double VG_Size
        {
            get;
            set;
        }

        /// <summary>
        /// Sets the size (radius) of the visualization grid
        /// </summary>
        /// <param name="Radius">The new size to set the grid to</param>
        public void VG_SetSize(double Size)
        {
            if (Size == 0) return;

            if (!this.VG_3DMode)
            {
                this.ChartAreas[0].AxisX.Maximum = this.VG_Origin[this.VG_XIndex] + System.Math.Abs(Size);
                this.ChartAreas[0].AxisX.Minimum = this.VG_Origin[this.VG_XIndex] - System.Math.Abs(Size);
                this.ChartAreas[0].AxisX.MajorGrid.Interval = (this.ChartAreas[0].AxisX.Maximum - this.ChartAreas[0].AxisX.Minimum) / 20;
                this.ChartAreas[0].AxisY.Maximum = this.VG_Origin[this.VG_YIndex] + System.Math.Abs(Size);
                this.ChartAreas[0].AxisY.Minimum = this.VG_Origin[this.VG_YIndex] - System.Math.Abs(Size);
                this.ChartAreas[0].AxisY.MajorGrid.Interval = (this.ChartAreas[0].AxisY.Maximum - this.ChartAreas[0].AxisY.Minimum) / 20;
                this.VG_Size = System.Math.Abs(Size);
            }
            else
            {
                throw new Exception("Changing the grid size is not a valid option when in 3D mode!");
            }
        }

        /// <summary>
        /// Sets the origin of the grid to a particular value.
        /// </summary>
        /// <param name="Origin">The vector corresponding to the new origin of the visualization grid</param>
        public void VG_SetOrigin(Vector Origin)
        {
            if (!this.VG_3DMode)
            {
                //Set the new origin
                this.VG_Origin = Origin;
                //Adjust the maximum and minimum values around the new origin
                this.ChartAreas[0].AxisX.Maximum = Origin[this.VG_XIndex] + this.VG_Size;
                this.ChartAreas[0].AxisX.Minimum = Origin[this.VG_XIndex] - this.VG_Size;
                this.ChartAreas[0].AxisY.Maximum = Origin[this.VG_YIndex] + this.VG_Size;
                this.ChartAreas[0].AxisY.Minimum = Origin[this.VG_YIndex] - this.VG_Size;
            }
            else
            {
                //Determine the vector the camera was from the old origin
                Vector Vec = (this.VG_3DCameraPosition - this.VG_Origin);
                //Set the new origin
                this.VG_Origin = Origin;
                //Change the camera's position to be the "Vec.Magnitude" units from the new origin in direction "Vec.Direction"
                this.VG_3DCameraPosition = this.VG_Origin + Vec;
                //Point the camera to the new origin
                this.VG_Point3DCameraToOrigin();
            }
        }

        /// <summary>
        /// Converts a particular particle's radius to the specified marker size at the current scale.
        /// </summary>
        /// <param name="ParticleRadius">The radius (size) of the particle to convert</param>
        public int VG_RadiusToMarkerSize_2D(double ParticleRadius)
        {
            //Modified function from Jack of Stack Overflow
            double innerScaleX = this.ChartAreas[0].AxisX.Maximum - this.ChartAreas[0].AxisX.Minimum;
            double innerScaleY = this.ChartAreas[0].AxisY.Maximum - this.ChartAreas[0].AxisY.Minimum;
            double innerScaleAvg = (innerScaleX + innerScaleY) / 2;
            float innerPctX = this.ChartAreas[0].InnerPlotPosition.Width / 100;
            float innerPctY = this.ChartAreas[0].InnerPlotPosition.Height / 100;
            float innerPixelsX = this.Width * innerPctX;
            float innerPixelsY = this.Height * innerPctY;
            float innerPixelsAvg = (innerPixelsX + innerPixelsY) / 2;
            return (int)System.Math.Round((ParticleRadius * 2) / innerScaleAvg * innerPixelsAvg);
        }

        /// <summary>
        /// Attempts to add a 3D point to the grid with the specified position and radius.
        /// </summary>
        /// <param name="Position">The position of the particle to add</param>
        /// <param name="Radius">The radius of the particle to add</param>
        public void VG_AddPoint3D(Vector Position, double Radius)
        {
            //If the capacity is too low, we need to return
            if (Position.Capacity < 3) return;

            //If we are in point mode:
            if (((VG_Series)(this.Series[0])).VG_PointMode)
            {
                //We don't care about size
                Vector PerspectivePosition = VG_ProjectTo2D(Position);
                if (PerspectivePosition == null) return;

                VG_Point newpoint = new VG_Point(PerspectivePosition[0], PerspectivePosition[1], ((VG_Series)(this.Series[0])).MarkerSize, true);
                this.Series[0].Points.Add(newpoint);
            }
            else //Otherwise if it is like normal:
            {
                //Obtain the 2D projected coordinates
                Vector Results = VG_ProjectTo2D(Position, Radius);
                if (Results == null) return;
                Vector PerspectivePosition = new Vector();
                PerspectivePosition[0] = Results[0];
                PerspectivePosition[1] = Results[1];

                //Obtain the size of the particle
                double PerspectiveRadius = Results[2];
                if (PerspectiveRadius <= 0) return;

                //Continue plotting the new perspective particle as if it were 2D
                int EffectiveRadius = VG_RadiusToMarkerSize_2D(PerspectiveRadius);
                if (EffectiveRadius <= 0) return;
                VG_Point newpoint = new VG_Point(PerspectivePosition[0], PerspectivePosition[1], EffectiveRadius, true);
                this.Series[0].Points.Add(newpoint);
            }
        }

        /// <summary>
        /// Projects a 3D position into the current 2D scene (Gets the equivelant 2D coordinates of a 3D position).
        /// Returns null if the position cannot be converted (object was behind camera, etc).
        /// Also returns the scaled radius as an additional term in the vector.
        /// </summary>
        public Vector VG_ProjectTo2D(Vector Position3D, double Radius)
        {
            //Determine if the particle has the appropriate capacity
            if (Position3D.Capacity < 3) return null;

            //Single out the components that will represent X, Y, and Z in our projection
            Vector Vec3 = new Vector(3);
            try
            {
                Vec3[0] = Position3D[this.VG_XIndex];
                Vec3[1] = Position3D[this.VG_YIndex];
                Vec3[2] = Position3D[this.VG_ZIndex];
            }
            catch (Exception)
            {
                return null;
            }

            //Determine the distance from the camera to the particle and return null if they are at the same position
            Vector DistanceToParticle = (Vec3 - this.VG_3DCameraPosition);
            if (DistanceToParticle.Magnitude == 0) return null;

            //Transform the coordinates using the rotational matrix
            Vector Translated = PerfromMatrixTranslation(Vec3, this.VG_3DCameraPosition, this.VG_3DCameraOrientation);
            if (Translated == null) return null;

            //Obtain the effective viewer position from the FOV
            Vector EffectiveViewerPos = GetEffectiveViewerPositionFromFOV(this.VG_3DFOV);
            if (EffectiveViewerPos == null) return null;

            //Project the translated coordinates into 2D
            Vector Position2D = TranslatedCoordinatesTo2D(Translated, EffectiveViewerPos);
            if (Position2D == null) return null;

            //Scale the Radius
            Vector ReturnVec = new Vector(3);
            double NewRadius = VG_ScaleRadiusToPerspective(Translated, Radius);
            ReturnVec[0] = Position2D[0];
            ReturnVec[1] = Position2D[1];
            ReturnVec[2] = NewRadius;

            //Return the 2D coordinates + Radius
            return ReturnVec;
        }

        /// <summary>
        /// Projects a 3D position into the current 2D scene (Gets the equivelant 2D coordinates of a 3D position).
        /// Returns null if the position cannot be converted (object was behind camera, etc).
        /// </summary>
        public Vector VG_ProjectTo2D(Vector Position3D)
        {
            //Determine if the particle has the appropriate capacity
            if (Position3D.Capacity < 3) return null;

            //Single out the components that will represent X, Y, and Z in our projection
            Vector Vec3 = new Vector(3);
            try
            {
                Vec3[0] = Position3D[this.VG_XIndex];
                Vec3[1] = Position3D[this.VG_YIndex];
                Vec3[2] = Position3D[this.VG_ZIndex];
            }
            catch (Exception)
            {
                return null;
            }

            //Determine the distance from the camera to the particle and return null if they are at the same position
            Vector DistanceToParticle = (Vec3 - this.VG_3DCameraPosition);
            if (DistanceToParticle.Magnitude == 0) return null;

            //Transform the coordinates using the rotational matrix
            Vector Translated = PerfromMatrixTranslation(Vec3, this.VG_3DCameraPosition, this.VG_3DCameraOrientation);

            //Obtain the effective viewer position from the FOV
            Vector EffectiveViewerPos = GetEffectiveViewerPositionFromFOV(this.VG_3DFOV);
            if (EffectiveViewerPos == null) return null;

            //Project the translated coordinates into 2D
            Vector Position2D = TranslatedCoordinatesTo2D(Translated, EffectiveViewerPos);

            //Return the position
            return Position2D;
        }

        /// <summary>
        /// The GenerationTimer of view of the camera in degrees (default: 90).
        /// Can be a value between 0 and 180.
        /// </summary>
        public double VG_3DFOV
        {
            get;
            set;
        }

        /// <summary>
        /// Scales a radius based on the current perspective (converts a 3D radius into a 2D radius).
        /// Assumes the distance between the particles is > 0.
        /// </summary>
        /// <param name="Radius">The radius (size) of the particle to scale</param>
        public double VG_ScaleRadiusToPerspective(Vector TranslatedPosition3D, double Radius)
        {
            if (TranslatedPosition3D == null) return 0;

            //We want to convert the radius into a ratio to a 1x1 grid.
            double Distance = TranslatedPosition3D[2];
            if (Distance <= 0) return 0;

            //Since Cot(45) = 1, if the FOV is 90 degrees, we can skip the Cot function
            double Cot;
            if (this.VG_3DFOV == 90)
            {
                Cot = 1;
            }
            else
            {
                Cot = (1.0 / System.Math.Tan(this.VG_3DFOV / 2.0));
            }
            
            
            double ScaledRadius = Radius * (Cot / Distance);

            //If the Scaled radius is > 1, then we will set it to 1
            if (ScaledRadius > 1) return 1;

            return ScaledRadius;
        }

        /// <summary>
        /// Points the 3D camera toward the relative origin from its current position.
        /// </summary>
        public void VG_Point3DCameraToOrigin()
        {
            //The unit vector that points from our camera to the origin is found by subtracting their position vectors and grabbing the direction
            this.VG_3DCameraOrientation = Orientation3D.FromDirection((this.VG_Origin - this.VG_3DCameraPosition).Direction);
        }

        /// <summary>
        /// Calculates the 2D coordinates (B) of a set of translated coordinates (D) given an effective viewer's position (E) using:
        /// Bx = ((Ez / Dz) * Dx) - Ex
        /// By = ((Ez / Dz) * Dy) - Ey
        /// 
        /// returns null if the object is behind the camera
        /// </summary>
        /// <param name="TranslatedCoordinates">The translated coorinates after performing the matrix calculation</param>
        /// <param name="EffectiveViewerPosition">The effective position of the viewer from the projection plane calculated from the FOV</param>
        private static Vector TranslatedCoordinatesTo2D(Vector TranslatedCoordinates, Vector EffectiveViewerPosition)
        {
            Vector Position2D = new Vector();

            if( TranslatedCoordinates[2] < 0) return null;

            Position2D[0] = ((EffectiveViewerPosition[2] / TranslatedCoordinates[2]) * TranslatedCoordinates[0]) - EffectiveViewerPosition[0];
            Position2D[1] = ((EffectiveViewerPosition[2] / TranslatedCoordinates[2]) * TranslatedCoordinates[1]) - EffectiveViewerPosition[1];

            return Position2D;
        }

        /// <summary>
        /// Calculates the effective viewer position from a FOV using the fact that:
        /// FOV = 2 * tan^-1(1 / Ez)    OR    1 / (tan(FOV / 2)) = Ez
        /// Assuming 2D varient of the grid is suppressed to size 1
        /// </summary>
        /// <param name="FOV">The angle of the FOV in degrees (which will be converted to radians)</param>
        private static Vector GetEffectiveViewerPositionFromFOV(double FOV)
        {
            //NOTE: IN MY COORDINATE SYSTEM, Z MAY BE Y AND VICE VERSA!!!
            Vector ReturnVector = new Vector(3);

            double BottomPart = System.Math.Tan(SimMath.DegreesToRadians(FOV) / 2.0);

            if (BottomPart == 0) return null;

            ReturnVector[2] = (1.0 / BottomPart);

            return ReturnVector;
        }

        /// <summary>
        /// Obtains the translated coordinates (D) from a 3D position vector (A), camera position (C), and orentation (T).
        /// </summary>
        /// <param name="Position3D">The origional 3D position of the object in world coordinates</param>
        /// <param name="CameraPosition">The position of the camera</param>
        /// <param name="CameraOrientation">The orientation of the camera</param>
        private static Vector PerfromMatrixTranslation(Vector Position3D, Vector CameraPosition, Orientation3D CameraOrientation)
        {
            //Calculate Angles
            double Sinx = System.Math.Sin(SimMath.DegreesToRadians(-CameraOrientation[0]));
            double Siny = System.Math.Sin(SimMath.DegreesToRadians(-CameraOrientation[1]));
            double Sinz = System.Math.Sin(SimMath.DegreesToRadians(-CameraOrientation[2]));
            double Cosx = System.Math.Cos(SimMath.DegreesToRadians(-CameraOrientation[0]));
            double Cosy = System.Math.Cos(SimMath.DegreesToRadians(-CameraOrientation[1]));
            double Cosz = System.Math.Cos(SimMath.DegreesToRadians(-CameraOrientation[2]));

            //Calculate the components of (A - C)
            double X = Position3D[0] - CameraPosition[0];
            double Y = Position3D[1] - CameraPosition[1];
            double Z = Position3D[2] - CameraPosition[2];

            //Translate the coordinates
            Vector Translated = new Vector(3);

            //Dx = (Cosy * ((Sinz * Y) + (Cosz * X))) - (Siny * Z)
            Translated[0] = (Cosy * ((Sinz * Y) + (Cosz * X))) - (Siny * Z);

            //Dy = (Sinx * ((Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X))))) + (Cosx * ((Cosz * Y) - (Sinz * X)))
            double FirstPart = (Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X)));
            double SecondPart = (Cosz * Y) - (Sinz * X);
            Translated[1] = (Sinx * FirstPart) + (Cosx * SecondPart);

            //Dz = (Cosx * ((Cosy * Z) + (Siny * ((Sinz * Y) + (Cosz * X))))) - (Sinx * ((Cosz * Y) - (Sinz * X)))
            Translated[2] = (Cosx * FirstPart) - (Sinx * SecondPart);

            return Translated;
        }

        /// <summary>
        /// Plots a list of particles in 2D with a particular sub-particle depth.
        /// When the depth is zero, only the top level particles will be plotted, when the depth is 1 only the first level of subparticles will be drawn, etc.
        /// </summary>
        /// <param name="Particles">The list of particles to plot</param>
        /// <param name="Depth">The depth at which to plot the particles</param>
        public void VG_PlotList_2D(List<Physics.Particle> Particles, int Depth)
        {
            //Check for errors
            if (Particles == null) return;
            if (Depth < 0) return;

            //If the depth is zero:
            if (Depth == 0)
            {
                //Run this list through the top level overload of this method
                this.VG_PlotList_2D(Particles);
            }
            else //if the depth is greater than zero:
            {
                //Grab the list of particles for that depth
                List<Physics.Particle> ParticlesAtDepth = new List<Physics.Particle>();

                //For each top-level particle:
                foreach (Physics.Particle P in Particles)
                {
                    //Check for errors:
                    if (P == null) continue;
                    if (P.SubParticles == null) continue;

                    //Add the children found at that particular depth
                    ParticlesAtDepth.AddRange(P.GrabChildDepth(Depth));
                }

                //Clean up the list
                ParticlesAtDepth.Capacity = ParticlesAtDepth.Count;

                //Run this list through the top level overload of this method
                this.VG_PlotList_2D(ParticlesAtDepth);
            }
        }

        /// <summary>
        /// Plots the top level of a list of particles (automatically clears the previous rendered set of particles and selectively renders particles based on visibility).
        /// </summary>
        /// <param name="Particles">The list of particles to plot</param>
        public void VG_PlotList_2D(List<Physics.Particle> Particles)
        {
            //Check for issues
            if (Particles == null) return;

            //First, we need to extract a list of all of the positions and radius'.
            List<PlotVector> PlotList = PlotVector.ExtractSortedListFromParticleList_2D(Particles);

            //Run this list through the plot vector overload of this method
            this.VG_PlotList_2D(PlotList);
        }

        /// <summary>
        /// Plots the top layer of a list of plot vectors (automatically clears the previous rendered set of particles and selectively renders particles based on visibility).
        /// </summary>
        /// <param name="PlotList">The list of plot vectors to plot</param>
        public void VG_PlotList_2D(List<PlotVector> PlotList)
        {
            //Check for issues
            if (PlotList == null) return;

            //Clear the current rendered set of particles
            this.VG_ClearPoints();

            //Just plot everything that is within the viewport
            foreach (PlotVector PVec in PlotList)
            {
                if (this.VG_IsPositionInView_2D(PVec.Position)) this.VG_AddPoint2D(PVec.Position, PVec.Radius);
            }
            return;

            /*//If we are in point mode:
            if (((VG_Series)(this.Series[0])).VG_PointMode)
            {
                //Just plot everything that is within the viewport
                foreach (PlotVector PVec in PlotList)
                {
                    if (this.VG_IsPositionInView_2D(PVec.Position)) this.VG_AddPoint2D(PVec.Position, PVec.Radius);
                }
                return;
            }


            //Sort the list of plot vectors by radius (with the largest radius' first)
            PlotList = PlotList.OrderByDescending(x => x.Radius).ToList();
            PlotList.Capacity = PlotList.Count;

            //Go ahead and plot the first 1/2 of particles (because these are likely to be too big to be swallowed)
            for (int i = 0; i < (PlotList.Capacity / 2); i++)
            {
                if (this.VG_IsPositionInView_2D(PlotList[i].Position))
                {
                    this.VG_AddPoint2D(PlotList[i].Position, PlotList[i].Radius);
                }
            }

            //For the second 1/2 of the plot list:
            Parallel.For((PlotList.Capacity / 2), PlotList.Capacity, i =>
            {
                try
                {
                    //Determine if that particle is within the plotted region
                    if (this.VG_IsPositionInView_2D(PlotList[i].Position))
                    {

                        //Determine its bounding coordinates
                        double MyLeftCoordinate = PlotList[i].Position[this.VG_XIndex] - PlotList[i].Radius;
                        double MyRightCoordinate = PlotList[i].Position[this.VG_XIndex] + PlotList[i].Radius;
                        double MyBottomCoordinate = PlotList[i].Position[this.VG_YIndex] - PlotList[i].Radius;
                        double MyTopCoordinate = PlotList[i].Position[this.VG_YIndex] + PlotList[i].Radius;

                        bool IsCovered = false; // <- This will be used to tell is if this particle has anything covering it completely (and thus doesn't need to be plotted)

                        //For each other object in the first 1/2 of the list:
                        for (int j = 0; j < (PlotList.Capacity / 2); j++)
                        {
                            //Determine if the comparison particle is within the plotted region
                            if (this.VG_IsPositionInView_2D(PlotList[j].Position))
                            {
                                //Determine the comparison's leftmost and rightmost coordinates
                                double ComparisonLeftCoordinate = PlotList[j].Position[this.VG_XIndex] - PlotList[j].Radius;
                                double ComparisonRightCoordinate = PlotList[j].Position[this.VG_XIndex] + PlotList[j].Radius;
                                double ComparisonBottomCoordinate = PlotList[j].Position[this.VG_YIndex] - PlotList[j].Radius;
                                double ComparisonTopCoordinate = PlotList[j].Position[this.VG_YIndex] + PlotList[j].Radius;

                                //Determine if that object swallows (completely covers) this particle
                                if ((ComparisonLeftCoordinate <= MyLeftCoordinate && ComparisonRightCoordinate >= MyRightCoordinate) && (ComparisonBottomCoordinate <= MyBottomCoordinate && ComparisonTopCoordinate >= MyTopCoordinate))
                                {
                                    IsCovered = true;
                                    break;
                                }
                            }
                        }

                        //If the particle wasn't covered, plot it
                        if (IsCovered == false)
                        {
                            lock (this.Series)
                            {
                                this.VG_AddPoint2D(PlotList[i].Position, PlotList[i].Radius);
                            }
                        }
                    }

                }
                catch (Exception) { };
            });*/

            //Now that we have plotted all points, we are done.
        }


        /// <summary>
        /// Determines if a 2D position is within the plotted region (is within the current plot grid).
        /// NOTE: This method will automatically extract the 2 plotted dimensions (pass the actual position of the particle, no matter how many dimentions it's in)
        /// </summary>
        /// <param name="PositionVector">The position of the particle to check</param>
        public bool VG_IsPositionInView_2D(Vector PositionVector)
        {
            double X = PositionVector[this.VG_XIndex];
            double Y = PositionVector[this.VG_YIndex];

            if (X < this.ChartAreas[0].AxisX.Minimum || X > this.ChartAreas[0].AxisX.Maximum) return false;
            if (Y < this.ChartAreas[0].AxisY.Minimum || Y > this.ChartAreas[0].AxisY.Maximum) return false;

            return true;
        }


        /// <summary>
        /// Clears the current rendered set of particles (automatically clears all series' points).
        /// </summary>
        public void VG_ClearPoints()
        {
            if (this.Series.Count < 1) return;
            else if (this.Series.Count > 1)
            {
                for (int i = 0; i < this.Series.Count; i++)
                {
                    this.Series[i].Points.Clear();
                }
            }
            else
            {
                this.Series[0].Points.Clear();
            }
        }

        /// <summary>
        /// If set to true, the grid will pan (or rotate around the origin if in 3D mode) when the user clicks and drags the mouse.
        /// </summary>
        public bool VG_DragPan
        {
            get;
            set;
        }

        /// <summary>
        /// If set to true, the grid will zoom in and out when the mouse wheel is scrolled.
        /// </summary>
        public bool VG_MouseWheelZoom
        {
            get;
            set;
        }

        /// <summary>
        /// Handles button presses for when the chart is in 3D mode
        /// </summary>
        private void VG_Handle3DButtonPress(System.Windows.Forms.Keys KeyPress)
        {
            switch (KeyPress)
            {
                //Toggle point mode
                case System.Windows.Forms.Keys.P:
                    if (((VG_Series)(this.Series[0])).VG_PointMode)
                    {
                        ((VG_Series)(this.Series[0])).VG_PointMode_OFF();
                    }
                    else
                    {
                        ((VG_Series)(this.Series[0])).VG_PointMode_ON();
                    }
                    break;

                //Toggle point watcher plotting
                case System.Windows.Forms.Keys.T:
                    this.VG_PlotPointWatcherTrails = !this.VG_PlotPointWatcherTrails;
                    break;

                //Rotate the camera
                case System.Windows.Forms.Keys.Right:
                    VG_RotateCameraAroundOrigin(10, false);
                    break;
                case System.Windows.Forms.Keys.Left:
                    VG_RotateCameraAroundOrigin(-10, false);
                    break;
                case System.Windows.Forms.Keys.Up:
                    VG_RotateCameraAroundOrigin(10, true);
                    break;
                case System.Windows.Forms.Keys.Down:
                    VG_RotateCameraAroundOrigin(-10, true);
                    break;

                //Zoom camera if needed
                case System.Windows.Forms.Keys.Oemplus:
                    VG_CameraZoomToOrigin(-10);
                    break;
                case System.Windows.Forms.Keys.OemMinus:
                    VG_CameraZoomToOrigin(10);
                    break;
            }
        }

        /// <summary>
        /// Rotates the 3D camera about the origin given a particular angle and direction
        /// </summary>
        /// <param name="Angle">The angle to rotate</param>
        /// <param name="IsVertical">Whether the rotation is vertical or not</param>
        public void VG_RotateCameraAroundOrigin(double Angle, bool IsVertical)
        {
            // Via https://stackoverflow.com/questions/3162643/proper-trigonometry-for-rotating-a-point-around-the-origin
            // xnew = xcos(angle) - ysin(angle)
            // ynew = xsin(angle) + ycos(angle)

            if (Angle == 0) return;
            double cosangle = System.Math.Cos(SimMath.DegreesToRadians(Angle));
            double sinangle = System.Math.Sin(SimMath.DegreesToRadians(Angle));

            //If we are moving vertically
            if (IsVertical)
            {
                int xindex = 2;
                int yindex = 1;

                double xnew = (this.VG_3DCameraPosition[xindex] * cosangle) - (this.VG_3DCameraPosition[yindex] * sinangle);
                double ynew = (this.VG_3DCameraPosition[xindex] * sinangle) + (this.VG_3DCameraPosition[yindex] * cosangle);

                this.VG_3DCameraPosition[xindex] = xnew;
                this.VG_3DCameraPosition[yindex] = ynew;
            }
            else //Otherwise, if we are moving horizontally
            {
                int xindex = 2;
                int yindex = 0;

                double xnew = (this.VG_3DCameraPosition[xindex] * cosangle) - (this.VG_3DCameraPosition[yindex] * sinangle);
                double ynew = (this.VG_3DCameraPosition[xindex] * sinangle) + (this.VG_3DCameraPosition[yindex] * cosangle);

                this.VG_3DCameraPosition[xindex] = xnew;
                this.VG_3DCameraPosition[yindex] = ynew;
            }

            //Now point the camera to the origin
            VG_Point3DCameraToOrigin();
        }

        /// <summary>
        /// "Zooms in" the camera toward the origin by physically moving it closer.
        /// </summary>
        /// <param name="MoveDistance">The change in percent distance to move (positive for farther away, negative for closer)</param>
        public void VG_CameraZoomToOrigin(double MoveDistance)
        {
            //Create a new "distance magnitude" that the camera will be at.
            this.VG_3DCameraPosition.Magnitude = this.VG_3DCameraPosition.Magnitude + (this.VG_3DCameraPosition.Magnitude * (MoveDistance / 100));
        }

        /// <summary>
        /// Updates any currently added point watchers with their reference particles and plots them.
        /// </summary>
        /// <param name="ReferenceList">The list of particles to reference</param>
        public void VG_UpdatePointWatchers(List<Physics.Particle> ReferenceList)
        {
            //For each connected chart layer (series):
            for (int i = 0; i < this.Series.Count; i++)
            {
                //If that layer is a point watcher:
                if (this.Series[i] is VG_PointWatchSeries)
                {
                    //Clear that layer's points if neccessary
                    if (((VG_PointWatchSeries)this.Series[i]).Points.Count > 0) ((VG_PointWatchSeries)this.Series[i]).Points.Clear();

                    //Determine the particle from the reference list
                    Physics.Particle Ref = null;
                    foreach (Physics.Particle P in ReferenceList)
                    {
                        if (P.ID == ((VG_PointWatchSeries)this.Series[i]).VG_WatchParticle)
                        {
                            Ref = P;
                            break;
                        }
                    }

                    //CalculateInteraction the point watcher
                    ((VG_PointWatchSeries)this.Series[i]).VG_UpdatePointWatcher(Ref);

                    //If plotting point watchers is enabled:
                    if (this.VG_PlotPointWatcherTrails)
                    {
                        //For each recorded position in the point watcher:
                        bool PlottedZero = false;

                        //If we are in 3D mode:
                        if (this.VG_3DMode)
                        {
                            //Store a list of all the 3D positions we are going to plot
                            List<Vector> PositionsNeeded = new List<Vector>();

                            //Get those positions
                            for (int j = ((VG_PointWatchSeries)this.Series[i]).VG_PWPositions.Count - 1; j >= 0; j -= this.VG_PointWatcherTrailFrequency)
                            {
                                //Make sure the vector is large enough
                                if (((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[j].Capacity < 3) break;
                                PositionsNeeded.Add(((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[j]);
                            }

                            //Cleanup
                            PositionsNeeded.Capacity = PositionsNeeded.Count;

                            //Now project those positions to 2D
                            List<Vector> _2DVectors = new List<Vector>(PositionsNeeded.Capacity);
                            for (int k = 0; k < PositionsNeeded.Capacity; k++)
                            {
                                _2DVectors.Add(new Vector());
                            }

                            Parallel.For(0, PositionsNeeded.Capacity, j =>
                            {
                                //Obtain the 2D projected coordinates
                                Vector Results = VG_ProjectTo2D(PositionsNeeded[j], 0);
                                if (Results == null) return;
                                Vector PerspectivePosition = new Vector();
                                PerspectivePosition[0] = Results[0];
                                PerspectivePosition[1] = Results[1];
                                lock (_2DVectors)
                                {
                                    _2DVectors[j] = PerspectivePosition;
                                }
                            });

                            //Now plot all of the 2D positions
                            foreach (Vector PerspectivePosition in _2DVectors)
                            {
                                if (this.VG_IsPositionInView_2D(PerspectivePosition))
                                {
                                    ((VG_PointWatchSeries)this.Series[i]).Points.Add(new VG_PWPoint(PerspectivePosition[0], PerspectivePosition[1]));
                                }
                            }
                        }
                        else //Otherwise
                        {
                            for (int j = ((VG_PointWatchSeries)this.Series[i]).VG_PWPositions.Count - 1; j >= 0; j -= this.VG_PointWatcherTrailFrequency)
                            {
                                if (j == 0) PlottedZero = true;

                                //Make sure the vector is large enough
                                if (((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[j].Capacity < 2) break;

                                //Add the point
                                ((VG_PointWatchSeries)this.Series[i]).Points.Add(new VG_PWPoint(((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[j][this.VG_XIndex], ((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[j][this.VG_YIndex]));
                            }
                        }

                        if (!PlottedZero)
                        {
                            //If we are in 3D mode:
                            if (this.VG_3DMode)
                            {
                                //Make sure the vector is large enough
                                if (((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[0].Capacity < 3) break;

                                //Obtain the 2D projected coordinates
                                Vector Results = VG_ProjectTo2D(((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[0], 0);
                                if (Results == null) continue;
                                Vector PerspectivePosition = new Vector();
                                PerspectivePosition[0] = Results[0];
                                PerspectivePosition[1] = Results[1];

                                //Add the point
                                ((VG_PointWatchSeries)this.Series[i]).Points.Add(new VG_PWPoint(PerspectivePosition[0], PerspectivePosition[1]));
                            }
                            else //Otherwise:
                            {
                                //Make sure the vector is large enough
                                if (((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[0].Capacity < 2) break;

                                //Add the point
                                ((VG_PointWatchSeries)this.Series[i]).Points.Add(new VG_PWPoint(((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[0][this.VG_XIndex], ((VG_PointWatchSeries)this.Series[i]).VG_PWPositions[0][this.VG_YIndex]));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds a point watcher to the grid with a specified particle to watch and the number of positions to record.
        /// </summary>
        /// <param name="ParticleIndex">A reference particle we want to watch</param>
        /// <param name="PositionHistoryCount">The number of previous positions to keep track of</param>
        /// <param name="HD">Whether to render the point watcher in HD</param>
        public void VG_AddPointWatcher(Physics.Particle WatchParticle, int PositionHistoryCount, bool HD)
        {
            //Determine if that point watcher already exists
            if (this.Series.Count > 1)
            {
                //For each series:
                for (int i = 0; i < this.Series.Count; i++)
                {
                    //If it is a point watch series:
                    if (this.Series[i] is VG_PointWatchSeries)
                    {
                        //If it already watches this particle, we are done
                        if (((VG_PointWatchSeries)this.Series[i]).VG_WatchParticle == WatchParticle.ID) return;
                    }
                }
            }

            //If not, create it
            VG_PointWatchSeries NewSeries = new VG_PointWatchSeries(WatchParticle.ID, PositionHistoryCount, this.ChartAreas[0].Name);
            NewSeries.VG_HighDefinition = HD;
            this.Series.Add(NewSeries);
        }

        /// <summary>
        /// Removes all point watchers from the grid
        /// </summary>
        public void VG_ClearPointWatchers()
        {
            //If we have more than one series:
            if (this.Series.Count > 1)
            {
                List<System.Windows.Forms.DataVisualization.Charting.Series> remove = new List<System.Windows.Forms.DataVisualization.Charting.Series>();
                //For each series:
                foreach (var series in this.Series)
                {
                    //If it is a point watch series:
                    if (series is VG_PointWatchSeries)
                    {
                        remove.Add(series);
                    }
                }

                foreach (var series in remove)
                {
                    this.Series.Remove(series);
                }
            }
        }

        /// <summary>
        /// Removes any point watchers from the grid given a reference list of particles
        /// </summary>
        /// <param name="ParticleList">The reference list of particles</param>
        public void VG_ClearPointWatchers(List<Physics.Particle> ParticleList)
        {
            //If we have more than one series:
            if (this.Series.Count > 1)
            {
                //For each particle in the list:
                foreach (Physics.Particle P in ParticleList)
                {
                    //Clear the point watcher associated with that particle
                    this.VG_ClearPointWatcher(P.ID);
                }
            }
        }

        /// <summary>
        /// Clears a point watcher from the grid based on the ID of the particle it is watching
        /// </summary>
        /// <param name="ReferenceID">The reference ID of the particle watcher to clear</param>
        public void VG_ClearPointWatcher(string ReferenceID)
        {
            //If we have more than one series:
            if (this.Series.Count > 1)
            {
                //For each series:
                for (int i = 0; i < this.Series.Count; i++)
                {
                    //If it is a point watch series:
                    if (this.Series[i] is VG_PointWatchSeries)
                    {
                        //If they have the same reference ID:
                        if (((VG_PointWatchSeries)(this.Series[i])).VG_WatchParticle == ReferenceID)
                        {
                            //Remove that series and exit the function
                            this.Series.RemoveAt(i);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Whether to plot point watcher trails when updating them
        /// </summary>
        public bool VG_PlotPointWatcherTrails
        {
            get;
            set;
        }

        /// <summary>
        /// The frequency to plot point watcher trails (number of positions to increment when plotting)
        /// Increase this value to improve performance and decrease trail accuracy
        /// </summary>
        public int VG_PointWatcherTrailFrequency
        {
            get;
            set;
        }

        /// <summary>
        /// The previously clicked location used for drag-pan
        /// </summary>
        private int[] VG_DragPanPreviousClickLocation_Field;

        /// <summary>
        /// Whether we are in the middle of a panning operation
        /// </summary>
        private bool VG_Panning_Field;

        /// <summary>
        /// Plots the topmost level of particles from a list of particles in 3D
        /// </summary>
        /// <param name="ParticleList">The list of particles to plot</param>
        public void VG_PlotList_3D(List<Physics.Particle> ParticleList)
        {
            //Clear the top list of particles
            this.Series[0].Points.Clear();

            //Store all of the VG_Points
            List<VG_Point> PointList = new List<VG_Point>();

            //If we are in point mode:
            if (((VG_Series)(this.Series[0])).VG_PointMode)
            {
                //For each particle:
                Parallel.ForEach(ParticleList, P =>
                {
                    //We don't care about size
                    Vector PerspectivePosition = VG_ProjectTo2D(P.Position);
                    if (PerspectivePosition == null) return;

                    VG_Point newpoint = new VG_Point(PerspectivePosition[0], PerspectivePosition[1], ((VG_Series)(this.Series[0])).MarkerSize, true);
                    lock (PointList)
                    {
                        PointList.Add(newpoint);
                    }
                });
            }
            else //Otherwise if we aren't in point mode:
            {
                //For each particle:
                Parallel.ForEach(ParticleList, P =>
                {
                    //Obtain the 2D projected coordinates
                    Vector Results = VG_ProjectTo2D(P.Position, P.Radius);
                    if (Results == null) return;
                    Vector PerspectivePosition = new Vector();
                    PerspectivePosition[0] = Results[0];
                    PerspectivePosition[1] = Results[1];

                    //Obtain the size of the particle
                    double PerspectiveRadius = Results[2];
                    if (PerspectiveRadius <= 0) return;

                    //Continue plotting the new perspective particle as if it were 2D
                    int EffectiveRadius = VG_RadiusToMarkerSize_2D(PerspectiveRadius);
                    if (EffectiveRadius <= 0) return;
                    VG_Point newpoint = new VG_Point(PerspectivePosition[0], PerspectivePosition[1], EffectiveRadius, true);
                    lock (PointList)
                    {
                        PointList.Add(newpoint);
                    }
                });
                
            }

            foreach (VG_Point x in PointList)
            {
                this.Series[0].Points.Add(x);
            }
        }

        /// <summary>
        /// Gets or sets whether this visualization grid is in high definition
        /// </summary>
        public bool VG_HighDefinition
        {
            get
            {
                if (this.TextAntiAliasingQuality == System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.High) return true;
                else return false;
            }
            set
            {
                if (value == true)
                {
                    this.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.High;
                    this.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.All;
                }
                else
                {
                    this.TextAntiAliasingQuality = System.Windows.Forms.DataVisualization.Charting.TextAntiAliasingQuality.Normal;
                    this.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
                }

                foreach (var S in this.Series)
                {
                    if (S is VG_PointWatchSeries)
                    {
                        (S as VG_PointWatchSeries).VG_HighDefinition = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the primary point series associated with this visualization grid
        /// </summary>
        public VG_Series VG_PrimarySeries
        {
            get
            {
                if (this.Series != null)
                {
                    if (this.Series.Count > 0)
                    {
                        if (this.Series[0] is VG_Series)
                        {
                            return (this.Series[0] as VG_Series);
                        }
                    }
                }
                return null;
            }
            set
            {
                if (this.Series != null)
                {
                    if (this.Series.Count > 0)
                    {
                        if (this.Series[0] is VG_Series)
                        {
                            this.Series[0] = value;
                        }
                        else
                        {
                            this.Series.Insert(0, value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The metro theme (dark or light) of this grid
        /// </summary>
        public MetroFramework.MetroThemeStyle VG_Theme
        {
            get
            {
                return this.VG_Theme_Field;
            }
            set
            {
                System.Drawing.Color BC = MetroFramework.Drawing.MetroPaint.BackColor.Form(value);
                System.Drawing.Color FC = MetroFramework.Drawing.MetroPaint.ForeColor.Title(value);
                this.BackColor = BC;
                this.ForeColor = FC;
                this.Titles[0].BackColor = BC;
                this.Titles[0].ForeColor = FC;
                this.ChartAreas[0].BackColor = BC;
                this.ChartAreas[0].AxisX.TitleForeColor = FC;
                this.ChartAreas[0].AxisY.TitleForeColor = FC;
                this.ChartAreas[0].AxisX.MajorTickMark.LineColor = FC;
                this.ChartAreas[0].AxisX.MinorTickMark.LineColor = FC;
                this.ChartAreas[0].AxisY.MajorTickMark.LineColor = FC;
                this.ChartAreas[0].AxisY.MinorTickMark.LineColor = FC;
                this.ChartAreas[0].AxisX.MajorGrid.LineColor = FC;
                this.ChartAreas[0].AxisX.MinorGrid.LineColor = FC;
                this.ChartAreas[0].AxisY.MajorGrid.LineColor = FC;
                this.ChartAreas[0].AxisY.MinorGrid.LineColor = FC;
                this.ChartAreas[0].AxisX.LabelStyle.ForeColor = FC;
                this.ChartAreas[0].AxisY.LabelStyle.ForeColor = FC;
                this.ChartAreas[0].AxisX.LineColor = FC;
                this.ChartAreas[0].AxisY.LineColor = FC;
                this.VG_Theme_Field = value;
            }
        }

        /// <summary>
        /// The metro color style of this grid
        /// </summary>
        public MetroFramework.MetroColorStyle VG_ColorStyle
        {
            get
            {
                return this.VG_ColorStyle_Field;
            }
            set
            {
                System.Drawing.Color color = MetroFramework.Drawing.MetroPaint.GetStyleColor(value);
                this.Series[0].MarkerColor = color;
                this.VG_ColorStyle_Field = value;
            }
        }

        /// <summary>
        /// The private (actual) theme variable for this grid
        /// </summary>
        private MetroFramework.MetroThemeStyle VG_Theme_Field;

        /// <summary>
        /// The private (actual) color style variable for this grid
        /// </summary>
        private MetroFramework.MetroColorStyle VG_ColorStyle_Field;

    }
}
