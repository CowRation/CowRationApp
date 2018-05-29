﻿using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels;
using MaterialWpfApp.ViewModels.Economy;
using MaterialWpfApp.ViewModels.Helper;
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

namespace MaterialWpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для UserControlExpenses.xaml
    /// </summary>
    public partial class UserControlGeneral : UserControl
    {
        public UserControlGeneral(TransitionEffectKind transition, DataMilk date)
        {
            InitializeComponent();
            this.DataContext = new GeneralViewModel(date);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0,800));

        }
    }
}
