using System;
using System.Linq;

namespace Products.mails
{
    public class Human
    {
        public event EventHandler<MailEventArgs> GetMailEvent;


        public void AddMail(Mail mail)
        {
            // встал с дивага
            // открыл дверь
            // положил письмо в ящик
            
            OnGetMailEvent(new MailEventArgs(mail));
        }
        
        protected virtual void OnGetMailEvent(MailEventArgs e)
        {

            // var1
            // if (GetMailEvent != null)
            // {
            //     GetMailEvent.Invoke(this, e);
            // }
         
            //var2
            GetMailEvent?.Invoke(this, e);
            
            // var1 == var2
        }

        public void PrintInvocationList()
        {
            Console.WriteLine(GetMailEvent.GetInvocationList().Length);
        }
    }

    public class MailEventArgs : EventArgs
    {
        public Mail Mail { get; set; }

        public MailEventArgs(Mail mail)
        {
            Mail = mail;
        }
    }

    public class Mail
    {
        public string Text { get; set; }
        public string Address { get; set; }
        public string Author { get; set; }

        public Mail(string text, string address, string author)
        {
            Text = text;
            Address = address;
            Author = author;
        }

        public override string ToString()
        {
            return $"Text: {Text}, Address: {Address}, Author: {Author}";
        }
    }
    
}