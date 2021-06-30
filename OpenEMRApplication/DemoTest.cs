using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenEMRApplication
{
    class DemoTest
    {
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
