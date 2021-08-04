namespace SampleOutbox.Application.Configuration.Emails
{
    public struct EmailMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }

        public EmailMessage(string from, string to, string content)
        {
            this.From = from;
            this.To = to;
            this.Content = content;
        }
    }
}