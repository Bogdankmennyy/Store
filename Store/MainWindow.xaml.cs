using Store.Views;
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

namespace Store
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void TBShow(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 0.5;

        }

        private void TBHide(object sender, RoutedEventArgs e)
        {
            GridContent.Opacity = 1;
        }

        private void PreviewMouseleftBottonDownBG(object sender, MouseButtonEventArgs e)
        { 
            BtnShowHide.IsChecked = false;
        }

        private void Collapse(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Users();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
