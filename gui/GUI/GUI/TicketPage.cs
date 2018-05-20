using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TicketPage : Form
    {
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
    }
}
