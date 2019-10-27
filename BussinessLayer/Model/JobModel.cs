using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public class JobModel//We can say it viewmodels
    {
        public int ID { get; set; }
        public string Job { get; set; }
        public Nullable<decimal> MinSalary { get; set; }
        public Nullable<decimal> MaxSalary { get; set; }
    }
}
