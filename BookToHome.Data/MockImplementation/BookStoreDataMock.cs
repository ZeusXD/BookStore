
using System.Collections.Generic;
using BookToHome.Interfaces;
using BookToHome.Models;

namespace BookToHome.Data
{
    public class BookStoreDataMock : IBookData
    {

        private List<BookStore> booksStored;
        public BookStoreDataMock(List<BookStore> booksStored)
        {
            this.booksStored = booksStored;
        }

        public void AddBook(BookStore book)
        {
            booksStored.Add(book);
        }

        public List<BookStore> GetStoredBooks()
        {
            return booksStored;
        }
    }
}