using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        string CSV_PATH = ConfigurationManager.AppSettings["CSV_PATH"].ToString();

            _log.Info(PROGRAM_STARTUP);
            _log.Info("Csv Path is : " + CSV_PATH);
            _log.Info(PROGRAM_SHUTDOWN);

    }
}
}
