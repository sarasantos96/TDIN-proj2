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

namespace GUI
{
    public partial class TicketPage : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private Ticket ticket;
        private User user;

        public TicketPage(User user, Ticket ticket)
        {
            InitializeComponent();
            this.Text = "Ticket";

            this.user = user;
            this.ticket = ticket;

            titleBox.Text = ticket.title;
            userBox.Text = ticket.email;
            descBox.Text = ticket.description;
            this.ActiveControl = responseBox;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
            new ITHomepage(user).Show();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            if(ticket.status == "waiting")
            {
                MessageBox.Show("A question was already sent to another solver. Please check your responses.");
            }
            else
            {
                this.Close();
                new SendQuestion(ticket, user).Show();
            }
        }
        public async Task Email(string to, string subject, string body )
        {
            var values = new Dictionary<string, string>
                {
                   { "to", to },
                   { "subject", subject },
                   { "body", body },
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:3000/ticket/sendemail", content);
            var responseString = await response.Content.ReadAsStringAsync();
            this.Close();
            new ITHomepage(user).Show();
        }
            private void sendEmail_Click(object sender, EventArgs e)
        {
            string body = responseBox.Text;

            if (string.IsNullOrWhiteSpace(body))
            {
                MessageBox.Show("Response cannot be empty");
                return;
            }

            Email(ticket.email, ticket.title, body);
        }
    }
}
