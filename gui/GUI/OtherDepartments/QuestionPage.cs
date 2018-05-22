using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace OtherDepartments
{
    public partial class QuestionPage : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private Question question;
        private User user;
        public QuestionPage(Question question, User user)
        {
            InitializeComponent();
            this.question = question;
            this.user = user;

            this.Text = "Question";

            titleBox.Text = question.title;
            questionBox.Text = question.question;

            if(question.response != null)
            {
                responseBox.Text = question.response;
                sendResponseButton.Visible = false;
                responseBox.ReadOnly = true;
                responseBox.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        public async Task ChangeResponse(Question question, string r)
        {
            var values = new Dictionary<string, string>
                {
                   { "solverId", question.solverId},
                   { "otherId", question.otherId},
                   { "title", question.title },
                   { "question", question.question},
                   { "response", r },
                   { "ticketId", question.ticketId }
                };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PutAsync("http://localhost:3000/question/" + question.id, content);
            var responseString = await response.Content.ReadAsStringAsync();
        }

        private void sendResponseButton_Click(object sender, EventArgs e)
        {
            string response = responseBox.Text;

            if (string.IsNullOrWhiteSpace(response))
            {
                MessageBox.Show("Response cannot be empty");
                return;
            }
            sendResponseButton.Visible = false;
            responseBox.ReadOnly = true;
            responseBox.BackColor = System.Drawing.SystemColors.Window;
            ChangeResponse(question, response);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Homepage(user).Show();
        }
    }
}
