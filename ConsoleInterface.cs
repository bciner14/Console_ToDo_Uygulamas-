using System;

public class ConsoleInterface
{
    private CardOperations cardOperations;

    public ConsoleInterface(CardOperations operations)
    {
        cardOperations = operations;
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("(5) Çıkış");
            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    cardOperations.ListBoard();
                    break;
                case "2":
                    AddCard();
                    break;
                case "3":
                    RemoveCard();
                    break;
                case "4":
                    MoveCard();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyiniz.");
                    break;
            }
        }
    }

    private void AddCard()
    {
        Console.Write("Başlık Giriniz: ");
        string title = Console.ReadLine();
        Console.Write("İçerik Giriniz: ");
        string content = Console.ReadLine();
        Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
        Size size;
        Enum.TryParse(Console.ReadLine(), out size);
        Console.Write("Kişi ID'si Seçiniz (1-Ahmet, 2-Mehmet, 3-Ayşe): ");
        int personId;
        int.TryParse(Console.ReadLine(), out personId);
        Console.Write("Line Seçiniz (TODO, IN PROGRESS, DONE): ");
        string line = Console.ReadLine();

        cardOperations.AddCard(title, content, size, personId, line);
    }

    private void RemoveCard()
    {
        Console.Write("Lütfen kart başlığını yazınız: ");
        string title = Console.ReadLine();

        if (!cardOperations.RemoveCard(title))
        {
            Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            string choice = Console.ReadLine();
            if (choice == "2")
            {
                RemoveCard();
            }
        }
    }

    private void MoveCard()
    {
        Console.Write("Lütfen taşımak istediğiniz kartın başlığını yazınız: ");
        string title = Console.ReadLine();

        if (!cardOperations.MoveCard(title, "TODO"))
        {
            Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* İşlemi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            string choice = Console.ReadLine();
            if (choice == "2")
            {
                MoveCard();
            }
        }
    }
}
