using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialWpfApp.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public double Value { get; set; }
    }
}
