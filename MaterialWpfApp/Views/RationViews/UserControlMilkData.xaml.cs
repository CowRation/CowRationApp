using MaterialWpfApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels.Ration;
using MaterialWpfApp.ViewModels.Helper;

namespace MaterialWpfApp.Views
{
 
    public partial class UserControlMilkData : UserControl
    {
        public UserControlMilkData(TransitionEffectKind transition, DataRation date)
        {
            InitializeComponent();
            this.DataContext = new MilkDataViewModel(date);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));


        }
    }
}
