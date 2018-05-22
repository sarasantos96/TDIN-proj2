using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using GUI;

namespace OtherDepartments
{
    public partial class TroubleTickets : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public TroubleTickets()
        {
            InitializeComponent();
            this.Text = "Trouble Tickets - Other Department";
            this.tabPage1.Text = "Login";
            this.tabPage2.Text = "Register";

            passLBox.PasswordChar = '*';
            passRBox.PasswordChar = '*';
        }

        public async Task Login(string email, string password)
        {
            var values = new Dictionary<string, string>
                {
                   { "email", email },
                   { "password", password }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:3000/solver/auth", content);
            var responseString = await response.Content.ReadAsStringAsync();
            dynamic responseJson = JObject.Parse(responseString);
            var error = responseJson.error;

            if (error == null)
            {
                if (!responseJson.user.isIT.Value)
                {
                    User user = new User(responseJson.user.id.Value, responseJson.user.email.Value, false);
                    this.Close();
                    Console.WriteLine(user.getEmail());
                    new Homepage(user).Show();
                }
                else
                {
                    emailLbox.Text = "";
                    passLBox.Text = "";
                }

            }
            else
            {
                emailLbox.Text = "";
                passLBox.Text = "";
            }

        }

        public async Task Register(string name, string email, string password)
        {
            var values = new Dictionary<string, string>
                {
                   { "name", name },
                   { "email", email },
                   { "password", password },
                   { "isIT", "false"}
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:3000/solver/create", content);
            var responseString = await response.Content.ReadAsStringAsync();
            dynamic responseJson = JObject.Parse(responseString);
            var error = responseJson.error;

            if (error == null)
            {
                //TODO: Show message of success           
            }
            else
            {
                //TODO: show message of error

            }
            emailRBox.Text = "";
            nameRBox.Text = "";
            passRBox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = nameRBox.Text,
                   email = emailRBox.Text,
                   password = passRBox.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name))
                return;

            if (password.Length < 6)
            {
                //TODO: show error
                return;
            }

            Register(name, email, password);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = this.emailLbox.Text,
                   password = this.passLBox.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return;

            Login(email, password);
        }
    }
}
