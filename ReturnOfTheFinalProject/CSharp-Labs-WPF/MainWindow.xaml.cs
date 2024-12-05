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
        string task;
        bool isDarkTheme = true; // 0 - light, 1 - dark

        public MainWindow()
        {
            InitializeComponent();

            VisualChanger.ChangeTheme(isDarkTheme, Theme);
        }

        private void Show_Result_Click(object sender, RoutedEventArgs e)
        {
            if (LabChecker.IsUint(userValue1.Text, 9999999) && LabChecker.IsByte(userValue2.Text, 99) && LabChecker.IsUint(userValue3.Text, 9999999))
            {
                Money money = new Money(uint.Parse(userValue1.Text), byte.Parse(userValue2.Text));

                resultLabel.Content = "ToString: " + money.ToString();

                resultLabel.Content += "\noverload '+': " + (money + uint.Parse(userValue3.Text)).ToString();
                resultLabel.Content += "\noverload '-' (Money - m): " + (money - uint.Parse(userValue3.Text)).ToString();
                resultLabel.Content += "\noverload '-' (m - Money): " + (uint.Parse(userValue3.Text) - money).ToString();
                {
                    Random rand = new Random();
                    Money money2 = new Money((uint)rand.Next(0, 100), (byte)rand.Next(0, 99));
                    resultLabel.Content += $"\noverload '-' (Money1 - Money2({money2.Rubles}, {money2.Kopeks})): " + (money - money2).ToString();
                }
                resultLabel.Content += "\noverload '++': " + (++money).ToString();
                resultLabel.Content += "\noverload '--': " + (--money).ToString();
                resultLabel.Content += "\nexplicit uint: " + ((uint)money).ToString();
                resultLabel.Content += "\nimplicit bool: " + (money == true).ToString();
            }
            else
            {
                resultLabel.Content = "Incorrect input, try again!";
            }
        }


        void ResultText(Func<bool> checkFunc, Func<string> resultFunc)
        {
            resultLabel.Content = LabMath.ResultText(
                () => checkFunc(),
                () => resultFunc());
        }

        private void DarkLightToggle_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            VisualChanger.ChangeTheme(isDarkTheme, Theme);
        }

        //private void showHideTaskText_Click(object sender, RoutedEventArgs e)
        //{
        //    TaskBox.Visibility = VisualChanger.VisibleReverse(TaskBox.Visibility);
        //}
    }
}
