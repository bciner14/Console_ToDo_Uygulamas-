class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        CardOperations operations = new CardOperations(board);
        ConsoleInterface consoleInterface = new ConsoleInterface(operations);

        consoleInterface.ShowMenu();
    }
}
