using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Common
{
    public static class SerializerHelper
    {
        /// <summary>
        /// Allows to serialize object
        /// </summary>
        /// <param name="o">object to serialize</param>
        /// <param name="sw">writer</param>
        public static void Serialize(this Object o, StreamWriter sw)
        {
            new XmlSerializer(o.GetType(), GetTypes(o)).Serialize(sw, o);
        }

        /// <summary>
        /// Allows to deserialize file to object/collection
        /// </summary>
        /// <typeparam name="T">item Type to deserialize</typeparam>
        /// <param name="o">item to deserialize to</param>
        /// <param name="sr">reader</param>
        /// <param name="types">additional types</param>
        /// <returns>typeof(T) item</returns>
        public static T Deserialize<T>(StreamReader sr, params Type[] types)
        {
            return (T) new XmlSerializer(typeof (T), types).Deserialize(sr);
        }

        /// <summary>
        /// Allows to get all types of object
        /// </summary>
        /// <param name="o">object</param>
        /// <returns>Type collection</returns>
        private static Type[] GetTypes(this Object o)
        {
            if (o is IEnumerable)
                return ((o as IEnumerable).Cast<object>().Select(x => x.GetType())).ToArray();
            return new[] {o.GetType()};
        }
    }
}