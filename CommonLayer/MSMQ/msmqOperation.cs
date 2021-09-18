using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace CommonLayer.MSMQ
{
    public class msmqOperation
    {
        MessageQueue msmq = new MessageQueue();


        public  void sendingData(string token)
        {
            msmq.Path = @".\private$\tokenQueue";
            if(!MessageQueue.Exists(msmq.Path))
            {

                //if not Exists
                MessageQueue.Create(msmq.Path);


            }
            sendtoken(token);


        }

        public void sendtoken(string token)
        {
            //for adding XML formatter to msg
            msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
            //for sending token to the queue 
            msmq.Send(token);
            msmq.BeginReceive();
            msmq.Close();



        }

        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //getting token from receiver
                var msg = msmq.EndReceive(e.AsyncResult);

                string token = msg.Body.ToString();
                //sending a mail via SMTP
                mailSending(token);
                msmq.BeginReceive();
            }

            catch(MessageQueueException ex)
            {
                throw;

            }

            catch (Exception )
            {
                throw;

            }
        }

        private void mailSending(string token)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("tinku12poddar@gmail.com");
                message.To.Add(new MailAddress("prabal760@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "https://localhost:44365/User/forgetpassword"+token;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tinku12poddar@gmail.com", "tinku123456789");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
