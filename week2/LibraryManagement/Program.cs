using LibraryManagement.Data;
using LibraryManagement.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LibraryManagement
{

    // User Stories:
    // 1. As a user, I want to add new books to the library, so that I can manage my collection.
    // 2. As a user, I want to view all books in the library, so that I can see my collection.
    // 3. As a user, I want to edit book details, so that I can update information if needed.
    // 4. As a user, I want to delete books from the library, so that I can remove books I no longer have.

    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddScoped<IBookRepository, BookRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var bookRepository = serviceProvider.GetService<IBookRepository>();

            if (bookRepository != null)
            {
                Menu(bookRepository);
            }
            else
            {
                Console.WriteLine("Failed to initialize BookRepository.");
            }
        }

        static void Menu(IBookRepository bookRepository)
        {
            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook(bookRepository);
                        break;
                    case "2":
                        ViewAllBooks(bookRepository);
                        break;
                    case "3":
                        EditBook(bookRepository);
                        break;
                    case "4":
                        DeleteBook(bookRepository);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void AddBook(IBookRepository bookRepository)
        {
            var book = new Models.Book();
            Console.Write("Enter book title: ");
            book.Title = Console.ReadLine();
            Console.Write("Enter book author: ");
            book.Author = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter book year: ");
                if (int.TryParse(Console.ReadLine(), out int year))
                {
                    book.Year = year;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid year, please try again.");
                }
            }

            bookRepository.AddBook(book);
            bookRepository.Save();
            Console.WriteLine("Book added successfully.");
        }

        static void ViewAllBooks(IBookRepository bookRepository)
        {
            var books = bookRepository.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Year: {book.Year}");
            }
        }

        static void EditBook(IBookRepository bookRepository)
        {
            Console.Write("Enter book ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = bookRepository.GetBookById(id);
                if (book != null)
                {
                    Console.Write("Enter new book title (leave blank to keep current): ");
                    var title = Console.ReadLine();
                    if (!string.IsNullOrEmpty(title))
                    {
                        book.Title = title;
                    }

                    Console.Write("Enter new book author (leave blank to keep current): ");
                    var author = Console.ReadLine();
                    if (!string.IsNullOrEmpty(author))
                    {
                        book.Author = author;
                    }

                    while (true)
                    {
                        Console.Write("Enter new book year (leave blank to keep current): ");
                        var yearInput = Console.ReadLine();
                        if (string.IsNullOrEmpty(yearInput))
                        {
                            break;
                        }
                        else if (int.TryParse(yearInput, out int year))
                        {
                            book.Year = year;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid year, please try again.");
                        }
                    }

                    bookRepository.UpdateBook(book);
                    bookRepository.Save();
                    Console.WriteLine("Book updated successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID, please try again.");
            }
        }

        static void DeleteBook(IBookRepository bookRepository)
        {
            Console.Write("Enter book ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var book = bookRepository.GetBookById(id);
                if (book != null)
                {
                    bookRepository.DeleteBook(id);
                    bookRepository.Save();
                    Console.WriteLine("Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID, please try again.");
            }
        }
    }
}
