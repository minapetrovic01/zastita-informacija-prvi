namespace Chat
{
    public class Message
    {
        public string Content { get; set; }
        //public string Sender { get; set; }
        public string EncryptedContent { get; set; }

        public Message(string content, string encryptedContent)
        {
            Content = content;
            //Sender = sender;
            EncryptedContent = encryptedContent;
        }
    }
}
