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
using TeamViewerSerever.ViewModels;

namespace TeamViewerSerever.Views
{
    /// <summary>
    /// Interaction logic for ServerView.xaml
    /// </summary>
    public partial class ServerView : Window
    {
        public ServerView()
        {
            InitializeComponent();
            DataContext = new ServerViewModel();
        }
    }
}
