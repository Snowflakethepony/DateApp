using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Models
{
    public class Person
    {
        public int personID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string mailAddress { get; set; }
        public char gender { get; set; }
        public string birthday { get; set; }
        public string profession { get; set; }
        public int area { get; set; }
        public int status { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{personID}, {firstname} {lastname}";
            }
        }
    }
}
