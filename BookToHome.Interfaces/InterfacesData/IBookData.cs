using System.Collections.Generic;
using BookToHome.Models;

namespace BookToHome.Interfaces
{
    public interface IBookData
    {
        List<BookStore> GetStoredBooks();
        void AddBook(BookStore book);
    }
}