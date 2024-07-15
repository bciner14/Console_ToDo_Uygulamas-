using System.Collections.Generic;

public class Board
{
    public List<Card> ToDo { get; private set; }
    public List<Card> InProgress { get; private set; }
    public List<Card> Done { get; private set; }

    public Board()
    {
        ToDo = new List<Card>();
        InProgress = new List<Card>();
        Done = new List<Card>();

        // Varsayılan Kartlar
        ToDo.Add(new Card("Başlık1", "İçerik1", new TeamMember(1, "Ahmet"), Size.M, "TODO"));
        InProgress.Add(new Card("Başlık2", "İçerik2", new TeamMember(2, "Mehmet"), Size.L, "IN PROGRESS"));
        Done.Add(new Card("Başlık3", "İçerik3", new TeamMember(3, "Ayşe"), Size.S, "DONE"));
    }
}
