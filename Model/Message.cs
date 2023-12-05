namespace MyProject.Model;

public class Message : BaseClass
{
    public string MessageChat { get; set; }
    public int ChatId { get; set; }
    public string SenderEmail { get; set; }
    public DateTime DateCreated { get; set; }

    public Message(int id, string messageChat, int chatId, string senderEmail, DateTime dateCreated, bool isDeleted) : base(id, isDeleted)
    {
        MessageChat = messageChat;
        ChatId = chatId;
        SenderEmail = senderEmail;
        DateCreated = dateCreated;
    }
}