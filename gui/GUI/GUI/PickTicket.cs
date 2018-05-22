using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace GUI
{
    public partial class PickTicket : Form
    {
        private static readonly HttpClient client = new HttpClient();
        List<Ticket> tickets;
        User user;
        public PickTicket(User u)
        {
            InitializeComponent();
            unassignedLV.MouseDoubleClick += new MouseEventHandler(unassignedLV_DoubleClick);
            user = u;
            this.Text = "Choose a new Ticket";
            tickets = new List<Ticket>();
            GetUnassignedTickets();
        }

        public async Task  GetUnassignedTickets()
        {
            var responseString = await client.GetStringAsync("http://localhost:3000/tickets/unassigned");
            JArray json = JArray.Parse(responseString);
           
            for(int i = 0; i < json.Count; i++)
            {
                dynamic ticket = JObject.Parse(json[i].ToString());
                var id = ticket._id;
                var userId = ticket.userId;
                var solverId = ticket.solverId;
                var name = ticket.name;
                var email = ticket.email;
                var title = ticket.title;
                var description = ticket.description;
                var status = ticket.status;
                Ticket t = new Ticket(id.Value, userId.Value, solverId.Value, name.Value, email.Value, title.Value, description.Value, status.Value);
                tickets.Add(t);

                ListViewItem item = new ListViewItem(title.Value);
                item.SubItems.Add(email.Value);
                unassignedLV.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new ITHomepage(user).Show();
        }

       public async Task AssignTicket(Ticket ticket)
        {
            var values = new Dictionary<string, string>
                {
                   { "userId", ticket.userId },
                   { "solverId", user.getID()},
                   { "name", ticket.name },
                   { "email", ticket.email},
                   { "title", ticket.title },
                   { "description", ticket.description },
                   { "status", "assigned" }
                };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PutAsync("http://localhost:3000/ticket/"+ticket.id, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void unassignedLV_DoubleClick(object sender, EventArgs e)
        {
            int index = unassignedLV.Items.IndexOf(unassignedLV.SelectedItems[0]);
            AssignTicket(tickets[index]);
            unassignedLV.Items[index].Remove();
            tickets.RemoveAt(index);            
        }
    }
}
