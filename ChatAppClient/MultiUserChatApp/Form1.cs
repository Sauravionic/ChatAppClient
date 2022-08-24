using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiUserChatApp
{
    public partial class MainForm : Form
    {
        Server _server;
        public MainForm()
        {
            InitializeComponent();
            _server = new Server();
            MessageBox.Show(_server.message);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _server.connectUser(guna2TextBox3.Text);
            button1.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2TextBox2.Text))
            {
                string messageToDisplay = _server.messageTransaciton(guna2TextBox2.Text);
                MessageBox.Show(messageToDisplay);
                guna2TextBox1.Text = messageToDisplay;
            }
        }

























        /*
        Server _server = new Server();
        // _server.ConnectToServer(guna2TextBox3.Text);
        if (!string.IsNullOrWhiteSpace(guna2TextBox3.Text))
        {
            string ans = _server.connection(guna2TextBox3.Text);
            guna2TextBox4.Text = ans;
        }

        else
        {
            MessageBox.Show("Please Enter Your Name", "Error");
        }
        Refresh();
       // guna2TextBox3.Text = null;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        Server _server = new Server();
        if(!string.IsNullOrEmpty(guna2TextBox2.Text))
        {
            _server.sendMessage(guna2TextBox2.Text);
        }
    }
        */
    }
}
