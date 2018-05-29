using MaterialDesignThemes.Wpf.Transitions;
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

namespace MaterialWpfApp.Views.LogicViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlLogic.xaml
    /// </summary>
    public partial class UserControlLogic : UserControl
    {
        public UserControlLogic(TransitionEffectKind transition)
        {
            InitializeComponent();
            this.DataContext = new LogicViewModel();
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));
        }
    }
}
