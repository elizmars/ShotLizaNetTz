using System;

namespace ShotEzlizavetaNetTz.UI
{
    public enum LisaShotSelectAction
    {
        AddBook,
        Showbooks,
        ShowAuthors,
        RemoveBook,
        Exit
    }

    public static class LisaShotMainUi
    {
        public static LisaShotSelectAction SelectUserAction()
        {
            do
            {
                Console.WriteLine(
                    "Please enter: \n  1 for add a new book\n  2 for show list of books\n  3 for show list of authors");
                var key = Console.ReadLine();
                switch (key)
                {
                    case "0": return LisaShotSelectAction.Exit;
                    case "1": return LisaShotSelectAction.AddBook;
                    case "2": return LisaShotSelectAction.Showbooks;
                    case "3": return LisaShotSelectAction.ShowAuthors;
                    
                    default:
                        Console.WriteLine("Wrong input. try again...");
                        break;
                }
            } while (true);
        }
    }
}