using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_jud_GoodFood
{
    class Services
    {
        private static string dbPath = Environment.CurrentDirectory.Replace(@"\bin\Debug", @"\GOOD_FOOD.mdf");

        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbPath + ";Integrated Security=True";
    }
}
