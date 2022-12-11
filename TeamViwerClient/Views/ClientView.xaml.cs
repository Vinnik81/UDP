using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeamViwerClient.ViewModels;

namespace TeamViwerClient.Views
{
    /// <summary>
    /// Interaction logic for ClientView.xaml
    /// </summary>
    public partial class ClientView : Window
    {
        public ClientView()
        {
            InitializeComponent();
            DataContext = new ClientViewModel();
        }
    }
}
