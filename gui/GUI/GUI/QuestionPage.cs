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
    public partial class QuestionPage : Form
    {
        private static readonly HttpClient client = new HttpClient();
        Question question;
        User user;
        public QuestionPage(Question question, User user)
        {
            InitializeComponent();
            this.Text = "Question";
            this.question = question;
            this.user = user;
            ticketIDBox.Text = question.ticketId;
            titleBox.Text = question.title;
            questionBox.Text = question.question;
            if (question.response != null)
                ResponseBox.Text = question.response;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            new ITHomepage(user).Show();
        }
    }
}
