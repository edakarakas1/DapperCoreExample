using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreExample.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
