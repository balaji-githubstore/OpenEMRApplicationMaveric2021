using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using Newtonsoft.Json;

namespace OpenEMRApplication
{
    class DemoTest
    {
        [Test]
        public void JSONRead()
        {
            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Maveric 2021\OpenEMRApplication\OpenEMRApplication\TestData\data.json");
            string text=reader.ReadToEnd();
           // Console.WriteLine(text);

            dynamic json=  JsonConvert.DeserializeObject(text);
            Console.WriteLine(json["browser"]);

        }

        [Test]
        public void JSONRead2()
        {
            StreamReader reader = new StreamReader(@"D:\B-Mine\Company\Company\Maveric 2021\OpenEMRApplication\OpenEMRApplication\TestData\data.json");
            string text = reader.ReadToEnd();
            // Console.WriteLine(text);

            dynamic json = JsonConvert.DeserializeObject(text);
            Console.WriteLine(json["validcredentialdata"][0][1]);
            Console.WriteLine(json["validcredentialdata"].Count);

            object[] testCaseArray = new object[json["validcredentialdata"].Count];

            for (int i=0; i < testCaseArray.Length; i++)
            {
                object[] temp = new object[json["validcredentialdata"][i].Count];
                for (int j = 0; j < temp.Length; j++)
                {
                    temp[j] = Convert.ToString(json["validcredentialdata"][i][j]);
                }
                testCaseArray[i] = temp;
            }
        }


        [Test]
        public void ExcelRead()
        {
            IXLWorkbook book = new XLWorkbook(@"C:\Users\JiDi\Desktop\EMRData.xlsx");
            IXLWorksheet sheet = book.Worksheet("InvalidCredentialTest");
            IXLRange range= sheet.RangeUsed();
            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);

            object[] testCaseArray = new object[rowCount-1];

            for(int r=2;r<=rowCount;r++)
            {
                object[] temp = new object[colCount];
                for(int c=1;c<=colCount;c++)
                {
                    Console.WriteLine(r+" "+c);
                    string cellValue = Convert.ToString(range.Cell(r, c).Value);
                    Console.WriteLine(cellValue);
                    temp[c - 1] = cellValue;
                }
                testCaseArray[r-2] = temp;
            }

            book.Dispose();
            //convert sheet into object[] 
        }

        //John,John123
        //Peter,Peter123
        //bala,bala123

        public static object[] ValidData()
        {
            object[] temp1 = new object[2]; //number of parameter
            temp1[0] = "John";
            temp1[1] = "45";

            object[] temp2 = new object[2];  //number of parameter
            temp2[0] = "Peter";
            temp2[1] = "Peter123";

            object[] temp3 = new object[2];   //number of parameter
            temp3[0] = "bala";
            temp3[1] = "bala123";

            object[] main = new object[3]; //number of test case
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;

            return main;
        }



        [Test]
        [TestCaseSource("ValidData")]
        public void ValidTest(string username,string password)
        {
            Console.WriteLine(username+password);
        }
    }
}
