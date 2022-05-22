using MSDT.MVVM.ViewModel;
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
using System.Windows.Shapes;

namespace MSDT.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для WindowAllUser.xaml
    /// </summary>
    public partial class WindowAllUser : Window
    {
        public WindowAllUser()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainViewModel.AllUserActivated = false;
        }
    }
}
