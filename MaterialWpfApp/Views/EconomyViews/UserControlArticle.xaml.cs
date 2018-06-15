using MaterialWpfApp.ViewModels.Economy;
using MaterialWpfApp.ViewModels.Helper;
using System;
using System.Windows.Controls;

namespace MaterialWpfApp.Views.EconomyViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlArticle.xaml
    /// </summary>
    public partial class UserControlArticle : UserControl
    {
        public UserControlArticle(TransitionEffectKind transition, DataMilk date)
        {
            InitializeComponent();
            this.DataContext = new ArticleViewModel(date);


            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));


        }
    }
}
