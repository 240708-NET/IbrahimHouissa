using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        // Method to get all books
        IEnumerable<Book> GetAllBooks();

        // Method to get a book by ID
        Book GetBookById(int id);

        // Method to add a new book
        void AddBook(Book book);

        // Method to update an existing book
        void UpdateBook(Book book);

        // Method to delete a book by ID
        void DeleteBook(int id);

        // Method to save changes to the database
        void Save();
    }
}