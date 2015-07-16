using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimplexUniverse.IO
{
    /// <summary>
    /// Contains static methods used to read and write objects to/from files.
    /// </summary>
    public class Serialization
    {
        /// <summary>
        /// Serializes an object of type "T" to a file.
        /// </summary>
        /// /// <typeparam name="T">The type to interpret the object as</typeparam>
        /// <param name="FileName">The file path to serialize the object to</param>
        /// <param name="ObjectToSerialize">The object to serialize</param>
        public static void SerializeObject<T>(string FileName, T ObjectToSerialize)
        {
            Stream stream = File.Open(FileName, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, ObjectToSerialize);
            stream.Close();
        }

        /// <summary>
        /// Deserializes an object of type "T" from a file.
        /// </summary>
        /// <typeparam name="T">The type to interpret the object as</typeparam>
        /// <param name="FileName">The file path to deserialize the object from</param>
        public static T DeserializeObject<T>(string FileName)
        {
            T ObjectToDeserialize;
            Stream stream = File.Open(FileName, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            ObjectToDeserialize = (T)bFormatter.Deserialize(stream);
            stream.Close();
            return ObjectToDeserialize;
        }

        /// <summary>
        /// Serializes a list of objects of type "T". Ensure that Count = Capacity.
        /// Using this method instead of serializing the entire object (by using SerializeObject) will run faster.
        /// </summary>
        /// <typeparam name="T">The type of list to interpret the object as</typeparam>
        /// <param name="FileName">The file path to serialize the list to</param>
        /// <param name="ListToSerialize">The list of objects to serialize</param>
        public static void SerializeList<T>(string FileName, List<T> ListToSerialize)
        {
            //Open the false and create a new binary formatter
            Stream stream = File.Open(FileName, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();

            //Serialize the capacity of the list
            bFormatter.Serialize(stream, ListToSerialize.Capacity);

            //Serialize the individual items
            for (int i = 0; i < ListToSerialize.Capacity; i++)
            {
                bFormatter.Serialize(stream, ListToSerialize[i]);
            }

            //Close the stream
            stream.Close();
        }


        /// <summary>
        /// Deserializes a list of objects of type "T". Ensure that Count = Capacity.
        /// Using this method instead of deserializing the entire object (by using DeserializeObject) will run faster.
        /// </summary>
        /// <typeparam name="T">The type of list to interpret the object as</typeparam>
        /// <param name="FileName">The file path to deserialize the list from</param>
        public static List<T> DeserializeList<T>(string FileName)
        {
            //Open the false and create a new binary formatter
            Stream stream = File.Open(FileName, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();

            //Deserialize the capacity of the list
            int Capacity = (int)bFormatter.Deserialize(stream);

            //Create a new list of that capacity
            List<T> ReturnList = new List<T>(Capacity);

            //Deserialize the individual items
            for (int i = 0; i < Capacity; i++)
            {
                ReturnList.Add((T)bFormatter.Deserialize(stream));
            }

            //Close the stream and return the list
            stream.Close();
            return ReturnList;
        }

        /// <summary>
        /// Performs a deep copy (clone) of an object by serializing and then deserializing the object.
        /// Taken from StackOverflow
        /// </summary>
        /// <typeparam name="T">The type of object to clone</typeparam>
        /// <param name="ObjectToClone">The object to clone</param>
        public static T CloneObject<T>(T ObjectToClone)
        {
            //If it isn't serializable, complain.
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The given type is not serializable.", "ObjectToClone");
            }

            //Don't serialize a null object.
            if (Object.ReferenceEquals(ObjectToClone, null))
            {
                return default(T);
            }

            //Serialize and then deserialize the object.
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, ObjectToClone);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
