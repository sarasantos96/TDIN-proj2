using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace GUI
{
    public partial class ITHomepage : Form
    {
        private static readonly HttpClient client = new HttpClient();
        List<Ticket> tickets;
        List<Question> questions;
        User user;
        public ITHomepage(User u)
        {
            InitializeComponent();
            this.user = u;
            this.Text = "Trouble Tickets - IT Department";
            this.tabPage1.Text = "Assigned Tickets";
            this.tabPage2.Text = "Questions";
            tickets = new List<Ticket>();
            questions = new List<Question>();
            solverTicketsLV.MouseDoubleClick += new MouseEventHandler(solverTicketsLV_DoubleClick);
            questionsLV.MouseDoubleClick += new MouseEventHandler(questionsLV_DoubleClick);
            GetSolverTickets();
            GetSolverQuestions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PickTicket pt = new PickTicket(user);
            pt.StartPosition = FormStartPosition.CenterParent;
            pt.Show();
            this.Close();
        }

        public async Task GetSolverTickets()
        {
            var responseString = await client.GetStringAsync("http://localhost:3000/ticket/solver/"+user.getID());
            JArray json = JArray.Parse(responseString);

            for (int i = 0; i < json.Count; i++)
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
                if (status != "solved")
                {
                    tickets.Add(t);

                    ListViewItem item = new ListViewItem(title.Value);
                    item.SubItems.Add(email.Value);
                    solverTicketsLV.Items.Add(item);
                }
                
            }
        }

        private void solverTicketsLV_DoubleClick(object sender, EventArgs e)
        {
            int index = solverTicketsLV.Items.IndexOf(solverTicketsLV.SelectedItems[0]);
            Ticket t = tickets[index];
            this.Close();
            new TicketPage(user, t).Show();
        }

        public async Task GetSolverQuestions()
        {
            var responseString = await client.GetStringAsync("http://localhost:3000/question/solver/" + user.getID());
            JArray json = JArray.Parse(responseString);

            for (int i = 0; i < json.Count; i++)
            {
                dynamic question = JObject.Parse(json[i].ToString());
                var id = question._id;
                var otherId = question.otherId;
                var solverId = question.solverId;
                var title = question.title;
                var q = question.question;
                var ticketId = question.ticketId;
                var response = question.response;
                Question qt = new Question(id.Value,solverId.Value, otherId.Value, title.Value, q.Value, ticketId.Value, response.Value);
                questions.Add(qt);

                ListViewItem item = new ListViewItem(title.Value);
                if( question.response == null)
                {
                    item.SubItems.Add("Waiting response");
                }
                else
                {
                    item.SubItems.Add("Solved");
                }
                
                questionsLV.Items.Add(item);
            }
        }

        private void questionsLV_DoubleClick(object sender, EventArgs e)
        {
            int index = questionsLV.Items.IndexOf(questionsLV.SelectedItems[0]);
            Question t = questions[index];
            this.Close();
            new QuestionPage(t,user).Show();
        }
    }
}
