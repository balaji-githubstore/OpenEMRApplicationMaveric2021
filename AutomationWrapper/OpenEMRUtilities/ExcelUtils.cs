using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRUtilities
{
    class ExcelUtils
    {
        public static object[] GetSheetIntoTestCaseSourceArray(string fileDetail,string sheetName)
        {
            IXLWorkbook book = new XLWorkbook(fileDetail);
            IXLWorksheet sheet = book.Worksheet(sheetName);
            IXLRange range = sheet.RangeUsed();
            int rowCount = range.RowCount();
            int colCount = range.ColumnCount();

            //Console.WriteLine(rowCount);
            //Console.WriteLine(colCount);

            object[] testCaseArray = new object[rowCount - 1];

            for (int r = 2; r <= rowCount; r++)
            {
                object[] temp = new object[colCount];
                for (int c = 1; c <= colCount; c++)
                {
                    //Console.WriteLine(r + " " + c);
                    string cellValue = Convert.ToString(range.Cell(r, c).Value);
                    //Console.WriteLine(cellValue);
                    temp[c - 1] = cellValue;
                }
                testCaseArray[r - 2] = temp;
            }

            book.Dispose();

            return testCaseArray;
        }
    }
}
