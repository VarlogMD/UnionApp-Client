using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
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

namespace UnionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin_Reg.Text.Trim();
            string pass = passBox_Reg.Password.Trim();
            string pass_2 = passBox_2_Reg.Password.Trim();
            string email = textBoxEmail_Reg.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin_Reg.ToolTip = "Login must be atleast 5 symbols long";
                textBoxLogin_Reg.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox_Reg.ToolTip = "Password must be atleast 5 symbols long";
                passBox_Reg.Background = Brushes.DarkRed;
            }
            else if (pass != pass_2) 
            {
                passBox_2_Reg.ToolTip = "Passwords are not equal";
                passBox_2_Reg.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains('@') || !email.Contains('.'))
            {
                textBoxEmail_Reg.ToolTip = "Email is not correct";
                textBoxEmail_Reg.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin_Reg.ToolTip = "";
                textBoxLogin_Reg.Background = Brushes.Transparent;
                passBox_Reg.ToolTip = "";
                passBox_Reg.Background = Brushes.Transparent;
                passBox_2_Reg.ToolTip = "";
                passBox_2_Reg.Background = Brushes.Transparent;
                textBoxEmail_Reg.ToolTip = "";
                textBoxEmail_Reg.Background = Brushes.Transparent;

                //MessageBox.Show("Everything is ok");
                
            }
        }

       
    }
}
