using LibraryManagement.Data;
using LibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        // Constructor to inject the DbContext
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        // Method to get all books
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        // Method to get a book by ID
        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        // Method to add a new book
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        // Method to update an existing book
        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }

        // Method to delete a book by ID
        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        // Method to save changes to the database
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}