using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTesting
{
    class Program
    {
        static void Main(string[] args)
        {
                DataTable dt;
                dt = CSVFile.ReadCSV(@"C:\Users\y0019.SYNTHFLEX\Desktop\test1.csv");

              //CSVFile.DeleteColumn(dt, @"C:\Users\y0019.SYNTHFLEX\Desktop\test.csv");


            CSVFile.ReturnMergeData(dt, 4);


            CSVFile.SaveCSV(dt, @"C:\Users\y0019.SYNTHFLEX\Desktop\yuan1.csv");

        }
    }
}
