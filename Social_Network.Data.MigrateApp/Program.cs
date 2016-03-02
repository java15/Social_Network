using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Network.Data.MigrateApp
{
    class Program
    {
        private const string _connectionstring = @"Server=WIN7X64\MSSQLSERVER12; Database=practicenetworkDb; User Id=admin;Password=admin;";
        
        static void Main(string[] args)
        {
            var migration = new Migration();
            Console.WriteLine("Enter migration version: ");
            int _version = Convert.ToInt32(Console.ReadLine());
            migration.MigtateTo(new[] { _connectionstring }, _version);

            Console.ReadLine();
        }
    }
}
