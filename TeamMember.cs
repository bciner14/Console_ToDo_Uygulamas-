public class TeamMember
{
    public int ID { get; set; }
    public string Name { get; set; }

    public TeamMember(int id, string name)
    {
        ID = id;
        Name = name;
    }
}
