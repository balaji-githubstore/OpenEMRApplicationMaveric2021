using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenEMRApplication.OpenEMRUtilities
{
    class JsonUtils
    {
        public static string GetValue(string fileDetail, string key)
        {
            StreamReader reader = new StreamReader(fileDetail);
            string text = reader.ReadToEnd();
            // Console.WriteLine(text);
            dynamic json = JsonConvert.DeserializeObject(text);
            string value = Convert.ToString(json[key]);

            return value;
        }

        public static object[] GetJSONArrayAsObject(string fileDetail, string key)
        {
            StreamReader reader = new StreamReader(fileDetail);
            string text = reader.ReadToEnd();
            // Console.WriteLine(text);

            dynamic json = JsonConvert.DeserializeObject(text);
            //Console.WriteLine(json[key][0][1]);
            //Console.WriteLine(json[key].Count);

            object[] testCaseArray = new object[json[key].Count];

            for (int i = 0; i < testCaseArray.Length; i++)
            {
                object[] temp = new object[json[key][i].Count];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = Convert.ToString(json[key][i][j]);
                }
                testCaseArray[i] = temp;
            }

            return testCaseArray;
        }
    }
}
