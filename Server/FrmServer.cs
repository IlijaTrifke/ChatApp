using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {

        Server server;
        public FrmServer()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (s, a) =>
            {
                if (Server.Clients.Count > 0)
                {
                    dataGridView1.DataSource = new BindingList<ClientHandler>(Server.Clients);
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            };
            timer.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            txtStanje.Text = "Server je pokrenut";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            server.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            txtStanje.Text = "Server je zaustavljen";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            server.Stop();
        }
    }
}
