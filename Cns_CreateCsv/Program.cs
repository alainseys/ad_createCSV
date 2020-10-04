using log4net;
using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace Cns_CreateCsv
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);



        static void Main(string[] args)
        {
            string PROGRAM_SPACER = "--------------------------------------------------------------------------";
            string PROGRAM_STARTUP = "============================PROGRAM STARTUP INITIATED============================";
            string PROGRAM_SHUTDOWN = "============================PROGRAM SHUTDOWN INITIATED============================";
            string CSV_PATH = ConfigurationManager.AppSettings["CSV_PATH"];

            _log.Info(PROGRAM_STARTUP);
            _log.Info("Csv Path is : " + CSV_PATH);
            _log.Info(PROGRAM_SHUTDOWN);

            Console.WriteLine("Enter Firstname:");
            string FIRSTNAME = Console.ReadLine();
            Console.WriteLine("Enter Lastname:");
            string LASTNAME = Console.ReadLine();
            string PASSWORD = "abc12345%";


            var records = new List<ADUSER>
            {
                new ADUSER { Firstname = FIRSTNAME, Lastname = LASTNAME, Password = PASSWORD},
                //new Foo {Lastname = LASTNAME},
                //new Foo {Password = PASSWORD}
            };

            using (var writer = new StreamWriter(CSV_PATH + @"\test.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) 
            {
                csv.WriteRecords(records);
            }
        }
        //this is the binding
        public class ADUSER 
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public string Password { get; set; }
        }
        public class ADUSERMap : ClassMap<ADUSER>
        {
            public ADUSERMap()
            {
                Map(m => m.Firstname).Index(0).Name("Firstname");
                Map(m => m.Lastname).Index(1).Name("Lastname");
                Map(m => m.Password).Index(2).Name("Password");

            }
        }



    }
}
