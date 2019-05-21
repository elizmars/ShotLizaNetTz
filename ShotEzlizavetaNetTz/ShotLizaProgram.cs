using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShotEzlizavetaNetTz.DataModels;
using ShotEzlizavetaNetTz.DataStorage;
using ShotEzlizavetaNetTz.UI;

namespace ShotEzlizavetaNetTz
{
    class ShotLizaProgram
    {
        public static object Id { get; private set; }

        static void Main(string[] args)
        {
            LisaShotSelectAction action;

            do
            {
                action = LisaShotMainUi.SelectUserAction();

                switch (action)
                {
                    case LisaShotSelectAction.AddBook:
                        AddNewBook();
                        break;
                    case LisaShotSelectAction.Showbooks:
                        ShowAllBooks();
                        break;
                    case LisaShotSelectAction.ShowAuthors:
                        ShowAllAuthors();
                        break;

                        /*case LisaShotSelectAction.RemoveBook:
                            RemoveBook();
                            break;*/
                }
            }

            while (action != LisaShotSelectAction.Exit);
            Console.WriteLine("Prese any key");
            Console.ReadLine();

        }

        private static void ShowAllAuthors() // авторы по номерам
        {
            var repo = new ShotLizaAuthorRepository();
            var authors = repo.GetAll();

            for (int i = 0; i < authors.Count; i++)
            {
                Console.WriteLine($"{i} - {authors[i].Name} Books: {authors[i].Books.Count}");
            }
            string command;
            do
            {
                Console.WriteLine("Show author - 1, Exit - 0");
                command = Console.ReadLine();
                if (command == "1" && command != "0")
                {
                    ShowAuthorBooks(authors);
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }

            } while (command != "0");
        }

        private static void ShowAuthorBooks(List<ShotLizaAuthor> authors)
        {

            Console.WriteLine("Enter author number: ");
            string userInput = Console.ReadLine();
            int authorNumber;
            bool convertResult = int.TryParse(userInput, out authorNumber);
            if (!convertResult)
            {
                Console.WriteLine("Wrong input");
                return;
            }

            if (authorNumber < 0 || authorNumber >= authors.Count)
            {
                Console.WriteLine("Index out of diapason");
                return;
            }
            var selectedAuthor = authors[authorNumber];
            string authorBooks = "";
            foreach (var book in selectedAuthor.Books)
            {
                authorBooks += book.Title + ";";
            }
            Console.WriteLine($" {selectedAuthor.Name} Books: {authorBooks}");

        }

        private static void ShowAllBooks()
        {
            var repo = new ShotLizaBookRepository();
            var books = repo.GetAll();

            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i} - {books[i].Title} {books[i].Yearh} Authors: {string.Concat(books[i].Authors.Select(x => x.Name))}");
            }

            string command;
            do
            {
                Console.WriteLine("Remove book - 1, Exit - 0");
                command = Console.ReadLine();
                if (command == "1" && command != "0")
                {
                    RemoveBookByIndex(books);
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }

            } while (command != "0");
        }

        private static void RemoveBookByIndex(List<ShotLizaBook> books)
        {
            Console.WriteLine("Enter book number for remove: ");
            string userInput = Console.ReadLine();
            int bookIndex;
            bool convertResult = int.TryParse(userInput, out bookIndex);
            if (!convertResult)
            {
                Console.WriteLine("Wrong input");
                return;
            }

            if (bookIndex < 0 || bookIndex >= books.Count)
            {
                Console.WriteLine("Index out of diapason");
                return;
            }
            var selectedBook = books[bookIndex];
            var repo = new ShotLizaBookRepository();
            repo.RemoveBook(selectedBook);
            books.Remove(selectedBook);



        }

        private static void AddNewBook()
        {
            Console.WriteLine("Enter name book:");
            string nameBook = Console.ReadLine();

            if (nameBook.Count() > 30 || nameBook.Count() == 0) {
                Console.WriteLine("Maximum size 30 sibols");
                return;
            }

            Console.WriteLine("Enter year book:");
            string yearBook = Console.ReadLine();

            if (yearBook.Count() == 0)
            {
                Console.WriteLine("Cannot to be empty");
                return;
            }

            Console.WriteLine("Enter Lastname authors by the next template : Authorname1; Authorname1; ...  ");
            var authors = Console.ReadLine().Split(';');
            foreach (var author in authors) {
                if (author.Count() > 20 || author.Count() == 0)
                {
                    Console.WriteLine("Maximum size 20 sibols");
                    return;
                }
            }

            


            var repo = new ShotLizaBookRepository();
            
            repo.AddBook(new ShotLizaBook
            {
             
                Title = nameBook,
                Yearh = yearBook,
                Authors = authors.Select(x => new ShotLizaAuthor { Name = x}).ToList()   });
            Console.WriteLine("Add sucsess full");
        }




    }
}

