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
using System.Diagnostics;
using Newtonsoft.Json;

namespace UnionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
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
                string username = login;
                string password = pass;
                string mail = email;
                var data = Task.Run(() => LoginToApp(username, password, mail));
                data.Wait();

                if (data.Result.Length > 0)
                {
                    string response = data.Result;
                    Debug.WriteLine(response);
                    if (string.Compare(response, "true") == 0)
                    {
                        //Debug.WriteLine("Login OK");
                        MessageBox.Show("Something went wrong");
                    }
                    else
                    {
                        MessageBox.Show("User Created");
                        LogInWindow objecLogInWindow = new LogInWindow();
                        objecLogInWindow.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong");

                }

            }
            static async Task<string> LoginToApp(string u, string p, string e)
            {
                var userName = "admin";
                var passwd = "1234";
                var email = "1234";
                var authData = Encoding.ASCII.GetBytes($"{userName}:{passwd}:{email}");

                string base_url = MyEnvironment.GetBaseUrl();
                var response = string.Empty;
                var url = base_url + "/user";
                RegisterUser objectRegisterUser = new RegisterUser(u, p, e);

                var json = JsonConvert.SerializeObject(objectRegisterUser);
                var postData = new StringContent(json, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));
                HttpResponseMessage result = await client.PostAsync(url, postData);
                response = await result.Content.ReadAsStringAsync();
                return response;
            }

        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow objecLogInWindow = new LogInWindow();
            objecLogInWindow.Show();
            this.Close();

        }
    }
}
