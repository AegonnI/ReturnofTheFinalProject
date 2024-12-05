using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace CSharp_Labs_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkTheme = true; // 0 - light, 1 - dark

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists("data.dat"))
            {
                StreamReader f = new StreamReader("data.dat");
                try { isDarkTheme = bool.Parse(f.ReadLine()); }
                catch { isDarkTheme = true; }
                f.Close();
            }
            ChangeTheme();
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            StreamWriter f = new StreamWriter("data.dat");
            f.WriteLine(isDarkTheme);
            f.Close();
        }

        private void Show_Result_Click(object sender, RoutedEventArgs e)
        {
            if (LabChecker.IsUint(userValue1.Text, 9999999) && LabChecker.IsByte(userValue2.Text, 99) && LabChecker.IsUint(userValue3.Text, 9999999))
            {
                Money money = new Money(uint.Parse(userValue1.Text), byte.Parse(userValue2.Text));

                resultLabel.Content = "Answer: " + (money - uint.Parse(userValue3.Text)).ToString();

                resultLabel2.Content = "\noverload '+': " + (money + uint.Parse(userValue3.Text)).ToString();
                resultLabel2.Content += "\noverload '-' (Money - m): " + (money - uint.Parse(userValue3.Text)).ToString();
                resultLabel2.Content += "\noverload '-' (m - Money): " + (uint.Parse(userValue3.Text) - money).ToString();
                {
                    Random rand = new Random();
                    Money money2 = new Money((uint)rand.Next(0, 100), (byte)rand.Next(0, 99));
                    resultLabel2.Content += $"\noverload '-' (Money1 - Money2({money2.Rubles}, {money2.Kopeks})): " + (money - money2).ToString();
                }
                resultLabel2.Content += "\noverload '++': " + (++money).ToString();
                resultLabel2.Content += "\noverload '--': " + (--money).ToString();
                resultLabel2.Content += "\nexplicit uint: " + ((uint)money).ToString();
                resultLabel2.Content += "\nimplicit bool: " + (money == true).ToString();
            }
            else
            {
                resultLabel.Content = "Read the message below";
                resultLabel2.Content = "Incorrect input, try again!";
            }
        }

        private void DarkLightToggle_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;

            ChangeTheme();
        }

        private void ChangeTheme()
        {
            if (isDarkTheme)
            {
                Theme.Source = new Uri("Themes/Dark.xaml", UriKind.Relative);
            }
            else
            {
                Theme.Source = new Uri("Themes/Light.xaml", UriKind.Relative);
            }
        }
    }
}
