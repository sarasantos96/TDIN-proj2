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
    public partial class ITHomepage : Form
    {
        User user;
        public ITHomepage(User u)
        {
            InitializeComponent();
            this.user = u;
            this.Text = "Trouble Tickets - IT Department";
            this.tabPage1.Text = "Assigned Tickets";
            this.tabPage2.Text = "Responses";
        }
    }
}
