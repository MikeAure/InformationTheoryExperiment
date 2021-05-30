using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Shannon_Fano_Coding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ShannonCoding> calcShannon = new List<ShannonCoding>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void chooseFile_Click(object sender, RoutedEventArgs e)
        {
            calcShannon.Clear();
            // showText.Clear();
            if(fileSelection.IsChecked == true)
            { 
                showText.Text = "";
                List<string> res = new List<string>();
                OpenFileDialog openFile = new OpenFileDialog();
                // openFile.InitialDirectory = ".\\";
                openFile.Filter = "文本文件(*.txt)|*.txt|(*.rtf)|*.rtf";

                if (openFile.ShowDialog() == true)
                {
                    using (var sr = new StreamReader(openFile.FileName))
                    {
                        string temp = sr.ReadLine();
                        int listNum = 0;

                        // 固定读取两行
                        for (int i = 0; i < 2; i++)
                        {
                            showText.Text += temp + '\n';
                            if (temp.Length == 1)
                            {
                                listNum = Convert.ToInt32(temp);
                                temp = sr.ReadLine();
                                continue;
                            }
                            else
                            {
                                decimal[] inputData = Array.ConvertAll<string, decimal>(temp.Split(' '), decimal.Parse);
                                decimal sumTemp = 0;
                                foreach (var number in inputData)
                                {
                                    sumTemp += number;
                                }
                                if (sumTemp != 1) MessageBox.Show("Wrong input!\n Please check your innput file!", "Warning", MessageBoxButton.OK);
                                else
                                {
                                    foreach (var num in inputData)
                                    {
                                        calcShannon.Add(new ShannonCoding(num));
                                    }
                                }

                            }


                        }
                    }
                }

            }
            else
            {
                int listNum = Convert.ToInt32(numberInput.Text);
                decimal[] inputData = Array.ConvertAll<string, decimal>(dataInput.Text.Split(' '), decimal.Parse);
                decimal sumTemp = 0;
                foreach (var number in inputData)
                {
                    sumTemp += number;
                }
                if (sumTemp != 1) MessageBox.Show("Wrong input!\n Please check your innput file!", "Warning", MessageBoxButton.OK);
                else
                {
                    foreach (var num in inputData)
                    {
                        calcShannon.Add(new ShannonCoding(num));
                    }
                }


            }

        }

        private void convertFile_Click(object sender, RoutedEventArgs e)
        {
            calcShannon.Sort((x, y) => -x.Probability.CompareTo(y.Probability));
            for (int i = 0; i < calcShannon.Count; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    calcShannon[i].AccumulateProb += calcShannon[j].Probability;
                }
                calcShannon[i].LogProb = Convert.ToDecimal(-Math.Log(decimal.ToDouble(calcShannon[i].Probability), 2.0));
                
                calcShannon[i].CodeLength = Convert.ToInt32(Math.Ceiling(calcShannon[i].LogProb));
                calcShannon[i].BinaryCode = ShannonCoding.dec2bin(calcShannon[i].AccumulateProb);
                calcShannon[i].Code = calcShannon[i].BinaryCode.Substring(2, calcShannon[i].CodeLength);
               
            }

            showText.Clear();
            Window shannonGrid = new ShowShannonCode(calcShannon);
            shannonGrid.Show();
            
        }

/*        private void fileSelection_Click(object sender, RoutedEventArgs e)
        {
            if (fileSelection.IsChecked == true)
                chooseFile.IsEnabled = true;
            else
                chooseFile.IsEnabled = false;
                
        }*/
    }
}
