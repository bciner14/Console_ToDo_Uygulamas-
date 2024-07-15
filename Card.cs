public enum Size
{
    XS = 1,
    S,
    M,
    L,
    XL
}

public class Card
{
    public string Title { get; set; }
    public string Content { get; set; }
    public TeamMember AssignedMember { get; set; }
    public Size CardSize { get; set; }
    public string Line { get; set; }

    public Card(string title, string content, TeamMember assignedMember, Size size, string line)
    {
        Title = title;
        Content = content;
        AssignedMember = assignedMember;
        CardSize = size;
        Line = line;
    }

    public override string ToString()
    {
        return $"Başlık: {Title}, İçerik: {Content}, Atanan Kişi: {AssignedMember.Name}, Büyüklük: {CardSize}";
    }
}
