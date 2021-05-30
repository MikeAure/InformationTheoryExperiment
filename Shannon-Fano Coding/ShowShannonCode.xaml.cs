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

namespace Shannon_Fano_Coding
{
    /// <summary>
    /// Interaction logic for ShowShannonCode.xaml
    /// </summary>
    public partial class ShowShannonCode : Window
    {
        private List<ShannonCoding> resList;
        public ShowShannonCode(List<ShannonCoding> _resList)
        {
            resList = _resList;
            InitializeComponent();
            showShannonCodeGrid.ItemsSource = resList;

        }
    }
}
