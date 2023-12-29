using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Communication.Instance.Connection())
            {
                Common.Message msg = new Common.Message
                {
                    Username = txtUsername.Text,
                    Operation = Common.Operation.Login
                };
                Communication.Instance.Send(msg);
                Common.Message message = Communication.Instance.Receive();
                if (message.IsSuccessful)
                {
                    MessageBox.Show("Uspesna prijava");
                    txtUsername.Enabled = false;
                    btnLogin.Enabled = false;
                    txtMessage.Enabled = true;
                    btnSend.Enabled = true;
                    Thread thread = new Thread(ReadMessage);
                    thread.Start();

                    Common.Message getAllClients = new Common.Message
                    {
                        Operation = Common.Operation.GetAll
                    };
                    Communication.Instance.Send(getAllClients);
                    // AKO JE POKRENUTA NIT KOJA CEKA ODGOVORE ONDA SAMO ONA SME DA POZIVA RECEIVE
                    ////Common.Message response = Communication.Instance.Receive();
                    //listKorisnici.DataSource = response;

                }
                else
                {
                    MessageBox.Show(message.ErrorText);
                }
            }
            else
            {
                MessageBox.Show("Nije uspeo da se poveze sa serverom!");
            }
        }

        public void ReadMessage()
        {
            try
            {
                while (true)
                {
                    Common.Message message = Communication.Instance.Receive();
                    switch (message.Operation)
                    {
                        case Common.Operation.Login:
                            break;
                        case Common.Operation.SendToAll:
                            this.Invoke(new Action(() =>
                            {
                                rtbChat.Text = $"{rtbChat.Text} \n {message.Username}: {message.MessageText}";
                            }));
                            break;
                        case Common.Operation.GetAll:
                            this.Invoke(new Action(() =>
                            {
                                listKorisnici.DataSource = message.Clients;
                            }));

                            break;
                        case Common.Operation.End:
                            this.Invoke(new Action(() =>
                            {
                                MessageBox.Show("Izbaceni ste sa servera!");
                                Close();
                            }));
                            break;
                    }

                }
            }
            catch (IOException se)
            {
                Debug.WriteLine(">>>" + se.Message);
            }
            catch (SerializationException se)
            {
                Debug.WriteLine(">>>" + se.Message);
                this.Invoke(new Action(() =>
                {
                    btnLogin.Enabled = true;
                    btnSend.Enabled = false;
                }));
                Communication.Instance.CloseConnection();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Common.Message message = new Common.Message
            {
                Operation = Common.Operation.SendToAll,
                MessageText = txtMessage.Text,
            };
            Communication.Instance.Send(message);
        }

        private void FrmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Message message = new Common.Message
            {
                Operation = Common.Operation.Finalize,
            };
            Communication.Instance.Send(message);
        }

        private void btnIzbaciKorisnika_Click(object sender, EventArgs e)
        {
            Common.Message message = new Common.Message
            {
                Operation = Common.Operation.End,
                Username = (string)listKorisnici.Items[listKorisnici.SelectedIndex]
            };
            Communication.Instance.Send(message);
        }
    }
}
