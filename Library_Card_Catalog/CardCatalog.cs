﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Library_Card_Catalog
{
    /// <summary>
    ///     CardCatalog Class - stores the information about the file name being used and the current list of books 
    /// </summary>
    class CardCatalog
    {
        private string _fileName;
        private List<Book> books;

        public CardCatalog() { }

        public CardCatalog(string fileName)
        {
            this._fileName = fileName;
            this.books = new List<Book>();
        }

        /// <summary>
        ///     ListBooks is a method in the CardCatalog class.
        /// </summary>
        /// <remarks>
        ///     Reads through the List of Book objects and prints each books information to the console.    
        /// </remarks>
        public void ListBooks()
        {
            foreach (Book b in books)
            {
                //Read trough each book oject in the list and print the appropriate information about the book
                Console.Write("\nTitle: {0}\nAuthor: {1}\nGenre: {2}\n# of Pages: {3}\nYear: {4}", b.Title, b.Author, b.Genre, b.NumPages, b.YearPublished);
                Console.WriteLine();
            }
        }

        /// <summary>
        ///     AddBook is a method in the CardCatalog class.
        /// </summary>
        /// <param name="b"> b is of type Book.</param>
        /// <remarks>
        ///     adds a new instance of type Book to the current CardCatalogs object List called books
        /// </remarks>
        public void AddBook(Book b)
        {
            books.Add(b);
        }

        /// <summary>
        ///     RemoveBook is a method in the CardCatalog class.
        /// </summary>
        /// <param name="book"></param>
        /// <remarks>
        ///     Removes a book in the list by the book title.
        /// </remarks>
        public void RemoveBook(string bookTitle)
        {
            foreach(Book book in books)
            {
                if(book.Title == bookTitle)
                {
                    books.Remove(book);
                    break;
                }
            }
        }

        /// <summary>
        ///     SaveAndExit is a method in the CardCatalog class.
        /// </summary>
        /// <param name="path">Path of the current directory + file name</param>
        /// <param name="formatter"></param>
        /// <remarks>
        ///     Serialiazes the Book List (List<Book>) and writes it to the file given in the path.
        /// </remarks>
        public void SaveAndExit(string path, IFormatter formatter)
        {
            try
            {
                FileStream writeStream = new FileStream(path, FileMode.Open, FileAccess.Write);
                formatter.Serialize(writeStream, this.books);

                // Closes the file stream
                writeStream.Close();
            }
            catch (IOException)
            {
                Console.WriteLine("There was an error saving the file!");
            }
        }

        /// <summary>
        ///     Load is a method of the CardCatalog class.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="formatter"></param>
        /// <remarks>
        ///     If file exists then it loads the file's serialized content into memory.
        ///     If file does not exist then it creates the file.
        /// </remarks>
        public void Load(string path, IFormatter formatter)
        {

            if (File.Exists(path))
            {
                 try
                {
                    FileStream readerFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    this.books = (List<Book>)formatter.Deserialize(readerFileStream);
                    readerFileStream.Close();

                    Console.WriteLine("{0} successfully loaded", this._fileName);

                }
                catch (IOException e)
                {
                    Console.WriteLine("Error loading the file!\nMessage: {0}", e.Message);
                }

            }
            else
            {
                try
                {
                    FileStream s = new FileStream(path, FileMode.CreateNew);
                    s.Close();
                }
                catch (IOException e)
                {
                    Console.WriteLine("Error creating a new empty file.\nMessage: {0}", e.Message);
                }

            }

        }

    }
}
