using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels;
using MaterialWpfApp.Views;
using MaterialWpfApp.Views.LogicViews;
using MaterialWpfApp.Views.RationViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace MaterialWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private async void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;


            switch (index)
            {
                case 0:
                    MoveCursorMenu(index);

                    MainWindowViewModel.Price = 0;
                    MainWindowViewModel.Rations = null;
                    MainWindowViewModel.QuantityCow = 0;
                    MainWindowViewModel.Quantity = 0;
                    indicators.IsIndeterminate = true;
                    await MovePage(new UserControlRationFeed(TransitionEffectKind.SlideInFromLeft), "Рацион");
                    indicators.IsIndeterminate = false;
                    break;

                case 1:

                    if (MainWindowViewModel.Price != 0)
                    {
                        MoveCursorMenu(index);
                        indicators.IsIndeterminate = true;
                        await MovePage(new UserControlLogic(TransitionEffectKind.SlideInFromLeft), "Логистика");
                        indicators.IsIndeterminate = false;
                    }
                    else
                    {
                        dialog.IsOpen = true;
                        var item = ListViewMenu.SelectedItem as ListViewItem;
                        item.IsSelected = false;

                       

                        item = ListViewMenu.Items[0] as ListViewItem;
                        item.IsSelected = true;
                    }


                    break;
                case 2:
                    if (MainWindowViewModel.Price != 0)
                    {
                        MoveCursorMenu(index);
                        indicators.IsIndeterminate = true;
                        await MovePage(new UserControlGeneral(TransitionEffectKind.SlideInFromLeft, null), "Экономика");
                        indicators.IsIndeterminate = false;


                    }
                    else
                    {
                        dialog.IsOpen = true;
                        var item = ListViewMenu.SelectedItem as ListViewItem;
                        item.IsSelected = false;


                      

                        item = ListViewMenu.Items[0] as ListViewItem;
                        item.IsSelected = true;
                    }

                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
        public Task MovePage(UserControl control, string name)
        {
            GridPrincipal.Children.Clear();
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.8));
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    (ThreadStart)delegate ()
                    {


                        GridPrincipal.Children.Add(control);
                        txtNamePage.Text = name;
                    });
            });



        }

        public async Task MoveNextAsync(UserControl control)
        {
            indicators.IsIndeterminate = true;
            await MovePage(control);
            indicators.IsIndeterminate = false;
        }

        public Task MovePage(UserControl control)
        {
            GridPrincipal.Children.Clear();
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.8));
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                            (ThreadStart)delegate ()
                            {


                                GridPrincipal.Children.Add(control);

                            });
            });

        }

        //private void ListViewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var item = sender as ListViewItem;
        //    if (MainWindowViewModel.Price==0)
        //    {
        //        item.IsSelected = false;
        //    }
        //}
    }
}
