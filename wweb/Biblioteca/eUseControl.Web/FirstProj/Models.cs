namespace FirstProj
{
    public class Models
    {
        public class Mail
        {
            public string From { get; internal set; }
            public string To { get; internal set; }
            public string Subject { get; internal set; }
            public string Body { get; internal set; }
        }
    }
}