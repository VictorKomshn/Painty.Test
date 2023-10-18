using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painty.Test.Database.Options
{
    public class DatabaseOptions
    {

        public const string SectionName = "Database";

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Database { get; set; }
    }

}
