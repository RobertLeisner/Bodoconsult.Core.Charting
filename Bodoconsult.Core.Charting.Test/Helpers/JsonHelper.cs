using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Bodoconsult.Core.Charting.Test.Helpers
{
    /// <summary>
    /// Helper class to handle JSON strings and files
    /// </summary>
    public class JsonXmlHelper
    {
        /// <summary>
        /// Load a object from a JSON file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T LoadJsonFile<T>(string fileName)
        {
            T job;

            using (var file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                };

                job = (T)serializer.Deserialize(file, typeof(T));

            }

            return job;
        }


        /// <summary>
        /// Load a object from a JSON resource
        /// </summary>
        /// <param name="resourceName">Fully qualified resource name</param>
        /// <returns>object of type T or null</returns>
        public static T LoadJsonFromResource<T>(string resourceName)
        {
            T job;

            var ass = Assembly.GetExecutingAssembly();
            var str = ass.GetManifestResourceStream(resourceName);

            if (str == null) return default(T);

            using (var file = new StreamReader(str))
            {
                var serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,
                };

                job = (T)serializer.Deserialize(file, typeof(T));

            }

            return job;
        }

        /// <summary>
        /// Load a object from a JSON string
        /// </summary>
        /// <param name="json">Fully qualified resource name</param>
        /// <returns>object of type T or null</returns>
        public static T LoadJsonFromString<T>(string json)
        {
            var job = JsonConvert.DeserializeObject<T>(json);

            return job;
        }


        /// <summary>
        /// Serialize a object to JSON
        /// </summary>
        /// <param name="value">object to convert</param>
        /// <typeparam name="T">type of object to convert</typeparam>
        /// <returns></returns>
        public static string SerializeObject<T>(T value)
        {

            return JsonConvert.SerializeObject(value);
            //var sb = new StringBuilder();
            //var sw = new StringWriter(sb, CultureInfo.InvariantCulture);

            //var jsonSerializer = new JsonSerializer
            //{
            //    Formatting = Formatting.Indented,
            //    TypeNameHandling = TypeNameHandling.Objects,
            //    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full,

            //};


            ////jsonSerializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            //using (var jsonWriter = new JsonTextWriter(sw))
            //{
            //    jsonWriter.Formatting = Formatting.Indented;
            //    jsonWriter.IndentChar = '\t';
            //    jsonWriter.Indentation = 1;

            //    jsonSerializer.Serialize(jsonWriter, value, typeof(T));
            //}

            //return sw.ToString();
        }


        /// <summary>
        /// Save an object of type T as JSON to a file
        /// </summary>
        /// <param name="fileName">full path for the JSON file</param>
        /// <param name="data">object to serialize to JSON</param>
        /// <typeparam name="T">type of the object to serialize to JSON</typeparam>
        /// <returns>JSON string</returns>
        public static string SaveAsFile<T>(string fileName, T data)
        {

            var json = SerializeObject(data);

            File.WriteAllText(fileName, json, Encoding.UTF8);

            return json;
        }



        public static void SaveDataTableAsXml(string fileName, DataTable data)
        {

            var strXML = new StringWriter();


            if (string.IsNullOrEmpty(data.TableName)) data.TableName = "Data";

            data.WriteXml(strXML, XmlWriteMode.WriteSchema, false);
            var xml = strXML.ToString();

            File.WriteAllText(fileName, xml, Encoding.UTF8);


        }


        public static DataTable GetDataTableFromXml(string fileName)
        {

            var dt = new DataTable();
            dt.ReadXml(fileName);

            return dt;
        }
    }
}
