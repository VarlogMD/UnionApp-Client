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
using System.Windows.Shapes;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace UnionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Room> roomsCollection;
        private List<User> usersCollection;

        internal class Room
        {  
            public string Name { get; set; }

        }

        internal class User
        {
            public string Name { get; set; }

        }

        public MainWindow()
        {
            InitializeComponent();
            ShowRooms();
            ShowUsers();
        }



        private void ShowRooms() 
        {
            var data = Task.Run(() => GetRoomsList());
            data.Wait();
            Debug.WriteLine(data.Result);
            if (data.Result.Length > 3) //Result is not []
            {
                dynamic rooms = JsonConvert.DeserializeObject(data.Result);

                roomsCollection = new List<Room>();

                List room_data = new List();
                foreach (var room in rooms)
                {
                    roomsCollection.Add(new Room { Name = room.name });
                    
                }
                Debug.WriteLine(room_data);
                Roomlist.ItemsSource = roomsCollection;
                

            }
            else
            {
                MessageBox.Show("There is no rooms");
            }

        }

        private void ShowUsers()
        {
            var data = Task.Run(() => GetUsersList());
            data.Wait();
            Debug.WriteLine(data.Result);
            if (data.Result.Length > 3) //Result is not []
            {
                dynamic users = JsonConvert.DeserializeObject(data.Result);

                usersCollection = new List<User>();

                List user_data = new List();
                foreach (var user in users)
                {
                    usersCollection.Add(new User { Name = user.login });

                }
                Debug.WriteLine(user_data);
                Userlist.ItemsSource = usersCollection;


            }
            else
            {
                MessageBox.Show("There is no users");
            }

        }


        static async Task<string> GetRoomsList()
        {
            var userName = "admin";
            var passwd = "1234";
            string base_url = MyEnvironment.GetBaseUrl();
            var authData = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            var response = string.Empty;
            var url = base_url + "/room";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));
            HttpResponseMessage result = await client.GetAsync(url);
            response = await result.Content.ReadAsStringAsync();
            //Debug.WriteLine(result);
            return response;
        }

        static async Task<string> GetUsersList()
        {
            var userName = "admin";
            var passwd = "1234";
            string base_url = MyEnvironment.GetBaseUrl();
            var authData = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            var response = string.Empty;
            var url = base_url + "/user";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authData));
            HttpResponseMessage result = await client.GetAsync(url);
            response = await result.Content.ReadAsStringAsync();
            //Debug.WriteLine(result);
            return response;
        }


    }

}
