using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace GUI
{
    public partial class SendQuestion : Form
    {
        private Ticket ticket;
        private User user;
        private string otherId = "5afd9c6610a56c04bce72c00";
        private static readonly HttpClient client = new HttpClient();

        public SendQuestion(Ticket ticket, User user)
        {
            InitializeComponent();
            this.Text = "Send Question";

            this.user = user;
            this.ticket = ticket;

            idBox.Text = ticket.id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new TicketPage(user, ticket).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = titleBox.Text,
                   question = questionBox.Text;

            if(string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(question))
            {
                MessageBox.Show("Title or Question cannot be blank");
                return;
            }
            PostQuestion(title, question);
            ChangeTicketStatus(ticket);
            this.Close();
            new TicketPage(user, ticket).Show();
        }

        public async Task PostQuestion(string title, string question)
        {
            var values = new Dictionary<string, string>
                {
                   { "solverId", user.getID() },
                   { "otherId", otherId },
                   { "title", title },
                   { "question", question},
                   { "ticketId", ticket.id }
                };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://localhost:3000/question", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async Task ChangeTicketStatus(Ticket ticket)
        {
            ticket.status = "waiting";
            var values = new Dictionary<string, string>
                {
                   { "userId", ticket.userId },
                   { "solverId", user.getID()},
                   { "name", ticket.name },
                   { "email", ticket.email},
                   { "title", ticket.title },
                   { "description", ticket.description },
                   { "status", "waiting" }
                };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PutAsync("http://localhost:3000/ticket/" + ticket.id, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }
    }
}
