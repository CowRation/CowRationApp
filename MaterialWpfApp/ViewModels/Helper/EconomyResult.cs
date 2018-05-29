using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialWpfApp.Infrastructure;
namespace MaterialWpfApp.ViewModels.Helper
{
    public class EconomyResult
    {
        public double TotalExpenses { get; set; }
        public double TotalIncome { get; set; }
        public double CostPrice { get; set; }
        public double UnitIncome { get; set; }
        public double Profitability { get; set; }
        public double UnitProfitability { get; set; }
    }
}
