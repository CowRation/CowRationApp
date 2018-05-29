using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels.Logic;
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
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;

namespace MaterialWpfApp.Views.LogicViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlLogicResult.xaml
    /// </summary>
    public partial class UserControlLogicResult : UserControl
    {
        public UserControlLogicResult(TransitionEffectKind transition, ObservableCollection<ProductGrid> collection, int i)
        {
            InitializeComponent();
            this.DataContext = new LogicResultViewModel(collection, i);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));
        }
    }
}
