using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialWpfApp.ViewModels.Helper
{
    public class DataMilk
    {
        public int PreviewQuantityMilk { get; set; }
        public double PreviewAverage { get; set; }

        public int ExtraPercent { get; set; }
        public int HigherPercent { get; set; }
        public int FirstPercent { get; set; }

        public double ExtraPrice { get; set; }
        public double HigherPrice { get; set; }
        public double FirstPrice { get; set; }

        public double FatMilk { get; set; }
        public double FatMilkF { get; set; }

    }
}
