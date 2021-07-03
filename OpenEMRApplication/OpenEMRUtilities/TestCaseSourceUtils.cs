using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication.OpenEMRUtilities
{
    public class TestCaseSourceUtils
    {
        public static object[] InvalidCredentialData()
        {
            object[] main=  ExcelUtils.GetSheetIntoTestCaseSourceArray(@"C:\Users\JiDi\Desktop\EMRData.xlsx", "InvalidCredentialTest");
            return main;
        }

        //public static object[] InvalidCredentialData()
        //{
        //    object[] temp1 = new object[4];
        //    temp1[0] = "Peter";
        //    temp1[1] = "Peter123";
        //    temp1[2] = "English (Indian)";
        //    temp1[3] = "Invalid username or password";

        //    object[] temp2 = new object[4];
        //    temp2[0] = "King";
        //    temp2[1] = "King123";
        //    temp2[2] = "Dutch";
        //    temp2[3] = "Invalid username or password";


        //    object[] main = new object[2];
        //    main[0] = temp1;
        //    main[1] = temp2;

        //    return main;
        //}

        public static object[] AddPatientData()
        {
            object[] temp1 = new object[8];
            temp1[0] = "admin";
            temp1[1] = "pass";
            temp1[2] = "English (Indian)";
            temp1[3] = "peter";
            temp1[4] = "paul";
            temp1[5] = "2021-07-02";
            temp1[6] = "Male";
            temp1[7] = "Medical Record Dashboard - Peter Paul";

            object[] temp2 = new object[8];
            temp2[0] = "accountant";
            temp2[1] = "accountant";
            temp2[2] = "English (Indian)";
            temp2[3] = "john";
            temp2[4] = "ken";
            temp2[5] = "2021-07-01";
            temp2[6] = "Female";
            temp2[7] = "Medical Record Dashboard - John Ken";

            object[] main = new object[2];
            main[0] = temp1;
            main[1] = temp2;

            return main;
        }
    }
}
