using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace GUI
{
    public partial class TroubleTickets : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public TroubleTickets()
        {
            InitializeComponent();
            this.Text = "Trouble Tickets - IT Department";
            this.tabPage1.Text = "Login";
            this.tabPage2.Text = "Register";

            string emailTextBoxName = "emailTextBox";
            string passwordTextBoxName = "passwordTextBox";
            TextBox passwordTextBox = this.Controls.Find(passwordTextBoxName, true).FirstOrDefault() as TextBox;
            TextBox emailTextBox = this.Controls.Find(emailTextBoxName, true).FirstOrDefault() as TextBox;

            passwordTextBox.PasswordChar = '*';
            registerPasswordBox.PasswordChar = '*';
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

            if(error == null)
            {
                if (responseJson.user.isIT.Value){
                    User user = new User(responseJson.user.id.Value, responseJson.user.email.Value,true);
                    this.Close();
                    new ITHomepage(user).Show();
                }

            }
            else
            {
                emailTextBox.Text = "";
                passwordTextBox.Text = "";
            }
           
        }

        public async Task Register(string name, string email, string password)
        {
            var values = new Dictionary<string, string>
                {
                   { "name", name },
                   { "email", email },
                   { "password", password },
                   { "isIT", "true"}
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
            registerEmailBox.Text = "";
            registerNameBox.Text = "";
            registerPasswordBox.Text = "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = this.emailTextBox.Text , 
                   password = this.passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return;

            Login(email, password);          
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string name = this.registerNameBox.Text,
                   email = this.registerEmailBox.Text,
                   password = this.registerPasswordBox.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(name))
                return;

            if(password.Length < 6)
            {
                //TODO: show error
                return;
            }

            Register(name, email, password);
        }
    }
}
