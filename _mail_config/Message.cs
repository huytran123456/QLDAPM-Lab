using System.Collections.Specialized;
using MailKit;
using MimeKit;

namespace myProject._mail_config;

public class Message
{
    public List<MailboxAddress> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<string> to, string subject, string content)
    {
        ListDictionary replacements = new ListDictionary();
        // replacements.Add("{name}", "Martin");
        // replacements.Add("{country}", "Denmark");
        
        To = new List<MailboxAddress>();
        To.AddRange(to.Select(x => MailboxAddress.Parse(x)));
        Subject = subject;
        Content = content;
    }
}