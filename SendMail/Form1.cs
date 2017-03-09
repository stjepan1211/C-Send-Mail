using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SendMail_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("saljem1");
                Send();
                MessageBox.Show("saljem2");
            }
            catch(Exception exception)
            {
                //MessageBox.Show(exception.InnerException.ToString());
            }
        }

        protected void Send()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "tournamentapp1@gmail.com"; //TODO: add your email
            // any address where the email will be sending
            var toAddress ="stjepanbaricevic1211@gmail.cm";
            //Password of your gmail address
            //read password from text file
            string fromPassword = System.IO.File.ReadAllText(@"E:\Visual studio projekti\SendMail\password.txt");
            // Passing the values and make a email formate to display
            string subject = "Hello from Tournaments application";
            string body = "From: " + "Stjepan Baricevic" + "\n";
            body += "Email: " + "Hi, log in and check application features." + "\n";
            body += "Questions: \n" + "stjepanbaricevic1211@gmail.com" + "\n";
            // smtp settings
            var smtp = new SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }
    }
}
