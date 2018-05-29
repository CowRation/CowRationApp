using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.ViewModels.Ration;
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

namespace MaterialWpfApp.Views.RationViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlResultRation.xaml
    /// </summary>
    public partial class UserControlResultRation : UserControl
    {
        public UserControlResultRation(TransitionEffectKind transition, DataRation ration)
        {
            InitializeComponent();
            this.DataContext = new ResultRationViewModel(ration);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));
        }
    }
}
