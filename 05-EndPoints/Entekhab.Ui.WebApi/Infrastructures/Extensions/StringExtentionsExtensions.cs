

using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Entekhab.Ui.WebApi.Infrastructures.Extensions
{
    public static class StringExtentions
    {
        //********************************************************************************************************************
        /// <summary>
        /// Check Custom Data is Valid For Deserialization
        /// </summary>
        /// <param name="data">Employee Salary Data</param>
        /// <returns></returns>
        public static bool ValidateCustomData(this string data)
        {
            // Parse the custom data format into individual values
            string[] lines = data.Split('\n');
            if (lines.Length != 2)
            {
                return false;
            }

            string[] titles = lines[0].Split('/');
            string[] values = lines[1].Split('/');

            if (titles.Length != values.Length)
            {
                return false;
            }

            return true;
        }
        //********************************************************************************************************************
        /// <summary>
        /// Deserialize Custom Data To Dictionary
        /// </summary>
        /// <param name="data">Employee Salary Data</param>
        /// <returns></returns>
        public static Dictionary<string, string> DeserializeCustomData(this string data)
        {
            string[] lines = data.Split('\n');
            if (lines.Length != 2)
            {
                return new Dictionary<string, string>();
            }

            string[] titles = lines[0].Split('/');
            string[] values = lines[1].Split('/');

            if (titles.Length != values.Length)
            {
                return new Dictionary<string, string>();
            }

            var employeeData = new Dictionary<string, string>();
            for (int i = 0; i < titles.Length; i++)
            {
                employeeData[titles[i].Trim()] = values[i].Trim();
            }

            return employeeData;
        }
        //********************************************************************************************************************
        /// <summary>
        /// Deserialize Json Data To Model
        /// </summary>
        /// <param name="data">Employee Salary Data</param>
        /// <returns></returns>
        public static T? DeserializeJsonData<T>(this string data) => JsonConvert.DeserializeObject<T>(data);
        //********************************************************************************************************************
        /// <summary>
        /// Deserialize Xml Data To Model
        /// </summary>
        /// <param name="data">Employee Salary Data</param>
        /// <returns></returns>
        public static T? DeserializeXmlData<T>(this string data)
        {
            using (StringReader stringReader = new(data))
            {
                XmlSerializer serializer = new(typeof(T));
                return (T?)serializer.Deserialize(stringReader);
            }
        }
        //********************************************************************************************************************
    }
}
