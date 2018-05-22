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
    public partial class Homepage : Form
    {
        private User user;
        private static readonly HttpClient client = new HttpClient();
        private List<Question> unanswered, old;

        public Homepage(User user)
        {
            InitializeComponent();
            this.user = user;
            unanswered = new List<Question>();
            old = new List<Question>();
            this.Text = "Trouble Tickets - Other Department";

            this.tabPage1.Text = "Unanswered";
            this.tabPage2.Text = "Old";

            unansweredLV.MouseDoubleClick += new MouseEventHandler(unanswerdLV_DoubleClick);
            oldLV.MouseDoubleClick += new MouseEventHandler(oldLV_DoubleClick);

            GetSolverQuestions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unansweredLV.Items.Clear();
            oldLV.Items.Clear();
            GetSolverQuestions();
        }

        public async Task GetSolverQuestions()
        {
            var responseString = await client.GetStringAsync("http://localhost:3000/question/other/" + user.getID());
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
                Question qt = new Question(id.Value, solverId.Value, otherId.Value, title.Value, q.Value, ticketId.Value, response.Value);
                
                if(response != null)
                {
                    old.Add(qt);
                    ListViewItem item = new ListViewItem(title.Value);
                    oldLV.Items.Add(item);
                }
                else
                {
                    unanswered.Add(qt);
                    ListViewItem item = new ListViewItem(title.Value);
                    unansweredLV.Items.Add(item);
                }

            }
        }

        private void unanswerdLV_DoubleClick(object sender, EventArgs e)
        {
            int index = unansweredLV.Items.IndexOf(unansweredLV.SelectedItems[0]);
            Question t = unanswered[index];
            this.Close();
            new QuestionPage(t,user).Show();
        }

        private void oldLV_DoubleClick(object sender, EventArgs e)
        {
            int index = oldLV.Items.IndexOf(oldLV.SelectedItems[0]);
            Question t = old[index];
            this.Close();
            new QuestionPage(t, user).Show();
        }
    }
}
