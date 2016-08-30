using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Library_Card_Catalog
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int userChoice, year, pages;
            string title, author, genre, fileName;
             
            // Stores the current path string into the path variable
            string path = Directory.GetCurrentDirectory() + "\\";

            //Ask user for a file name
            Console.Write("Please enter the filename: ");

            // Read user input and store into the string variable 'fileName'
            fileName = Console.ReadLine();

            //Create a new instance of the CardCatalog class called 'currentCatalog'
            CardCatalog currentCatalog = new CardCatalog(fileName);

            // Creat a new instance of a BinaryFormatter called 'formatter'
            IFormatter formatter = new BinaryFormatter();

            //Pass the path and the file name to the CardCatalog's Load method
            currentCatalog.Load(path + fileName, formatter);

            while (true)
            { 
                //Ask User to input a number 1 - 3 based on which option they choose
                Console.WriteLine("\nWhich option would you like (choose by number 1 - 3):");
                Console.Write("1: List All Books\n2: Search Books\n3: Add A Book\n4: Remove Book\n5: Save & Exit\nChoice: ");
                string c = Console.ReadLine();


                //Parse the string to an integer and if successful returns the parsed number to the variable userChoice
                int.TryParse(c, out userChoice);

                switch (userChoice)
                {
                    case 0:
                        
                        //If the TryParse fails above userCoice will equal 0
                        Console.WriteLine("\nPlease enter a valid number!");

                        break;

                    case 1:

                        currentCatalog.ListBooks();

                        break;

                    case 2:

                        Console.Write("\nEnter the title of the book: ");
                        title = Console.ReadLine();

                        currentCatalog.SearchBookList(title);

                        break;

                    case 3:

                        //ADD A BOOK
                        Console.Write("Please enter the title: ");
                        title = Console.ReadLine();

                        Console.Write("Please enter the author: ");
                        author = Console.ReadLine();

                        Console.Write("Please enter the genre: ");
                        genre = Console.ReadLine();

                        Console.Write("Please enter the # of pages: ");
                        int.TryParse(Console.ReadLine(), out pages);

                        Console.Write("Please enter the year published: ");
                        int.TryParse(Console.ReadLine(), out year);

                        //call AddBook from the Card Catalog class and pass a new Book object to store in the list
                        currentCatalog.AddBook(new Book(title, author, genre, pages, year));

                        break;

                    case 4:

                        // CHOICE 3: REMOVE BOOK
                        string inputTitle;
                       
                        // Loop ends when user exits or when book is removed
                        while (true)
                        {

                            Console.Write("Enter the title of the book to remove (enter 'e' for exit): ");
                            inputTitle = Console.ReadLine();
          
                            if (inputTitle.ToLower() == "e" || inputTitle.ToLower() == "exit")
                            {
                                break;
                            }
                            else if(!String.IsNullOrWhiteSpace(inputTitle))
                            {
                                // Check to see if book exists


                                // Call RemoveBook, a mehtod of the CardCatalog class.
                                currentCatalog.RemoveBook(inputTitle);
                                break;
                            }
                        }

                        break;

                    case 5:

                       // SAVE AND EXIT
                       // The Save method is called and then the program is exited.
                       currentCatalog.Save(path + fileName, formatter);
                       return;

                    default:
                        Console.WriteLine("\nPlease enter a number 1 - 5");
                        break;
                }  
            }
        }
    }
}
