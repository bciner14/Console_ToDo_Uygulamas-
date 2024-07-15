using System;
using System.Linq;
using System.Collections.Generic;

public class CardOperations
{
    private Board board;
    private List<TeamMember> teamMembers;

    public CardOperations(Board board)
    {
        this.board = board;
        teamMembers = new List<TeamMember>
        {
            new TeamMember(1, "Ahmet"),
            new TeamMember(2, "Mehmet"),
            new TeamMember(3, "Ayşe")
        };
    }

    public void AddCard(string title, string content, Size size, int assignedMemberID, string line)
    {
        TeamMember assignedMember = teamMembers.FirstOrDefault(m => m.ID == assignedMemberID);
        if (assignedMember == null)
        {
            Console.WriteLine("Hatalı girişler yaptınız!");
            return;
        }

        Card newCard = new Card(title, content, assignedMember, size, line);
        switch (line.ToUpper())
        {
            case "TODO":
                board.ToDo.Add(newCard);
                break;
            case "IN PROGRESS":
                board.InProgress.Add(newCard);
                break;
            case "DONE":
                board.Done.Add(newCard);
                break;
            default:
                Console.WriteLine("Geçersiz line adı.");
                break;
        }
    }

    public bool RemoveCard(string title)
    {
        var card = FindCard(title);
        if (card != null)
        {
            board.ToDo.Remove(card);
            board.InProgress.Remove(card);
            board.Done.Remove(card);
            return true;
        }
        return false;
    }

    public bool UpdateCard(string title, string newTitle, string newContent, int newAssignedMemberID, Size newSize)
    {
        var card = FindCard(title);
        if (card != null)
        {
            card.Title = newTitle;
            card.Content = newContent;
            card.AssignedMember = teamMembers.FirstOrDefault(m => m.ID == newAssignedMemberID);
            card.CardSize = newSize;
            return true;
        }
        return false;
    }

    public bool MoveCard(string title, string newLine)
    {
        var card = FindCard(title);
        if (card != null)
        {
            RemoveCard(title);
            AddCard(card.Title, card.Content, card.CardSize, card.AssignedMember.ID, newLine);
            return true;
        }
        return false;
    }

    private Card FindCard(string title)
    {
        return board.ToDo.FirstOrDefault(c => c.Title == title) ??
               board.InProgress.FirstOrDefault(c => c.Title == title) ??
               board.Done.FirstOrDefault(c => c.Title == title);
    }

    public void ListBoard()
    {
        Console.WriteLine("TODO Line\n************************");
        foreach (var card in board.ToDo)
        {
            Console.WriteLine(card);
            Console.WriteLine("-");
        }

        Console.WriteLine("IN PROGRESS Line\n************************");
        foreach (var card in board.InProgress)
        {
            Console.WriteLine(card);
            Console.WriteLine("-");
        }

        Console.WriteLine("DONE Line\n************************");
        foreach (var card in board.Done)
        {
            Console.WriteLine(card);
            Console.WriteLine("-");
        }
    }
}

