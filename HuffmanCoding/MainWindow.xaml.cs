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

namespace HuffmanCoding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Huffman calcHuffman = new Huffman();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(inputTextBox.Text != null)
            {
                Dictionary<char, string> key = new Dictionary<char, string>();
                List<Huffman.HuffmanTree> hfTreeLs = new List<Huffman.HuffmanTree>();
                // this.showHuffmanTree.SetBinding(new Binding() { Source = key });
                var res = calcHuffman.StringToHuffmanCode(out key, inputTextBox.Text);
                
                resultTextBox.Text = res; 
                foreach(var item in key)
                {
                    hfTreeLs.Add(new Huffman.HuffmanTree(item.Key, item.Value));
                }
                hfTreeLs.Sort();
                showHuffmanTree.DataContext = hfTreeLs;
            }
        }
    }
}
