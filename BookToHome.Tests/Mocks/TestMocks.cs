using System;
using System.Collections.Generic;
using BookToHome.Models;

namespace BookToHome.Tests
{
    public class TestMocks
    {
        public List<BookStore> StoredBooks()
        {
            return new List<BookStore>
            {
                new BookStore 
                {
                    Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                    Quantity = 5,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 2
                }
            };
        }
        public List<BookStore> StoredBooks1()
        {
            return new List<BookStore>
            {
                new BookStore 
                {
                    Book = new Book { Title = "Rayuela", Type = BookType.Book  },
                    Quantity = 4,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 4
                },
                new BookStore 
                {
                    Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                    Quantity = 5,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 2
                }
            };
        }
        public List<BookStore> StoredBooks2()
        {
            return new List<BookStore>
            {
                new BookStore 
                {
                    Book = new Book { Title = "Rayuela", Type = BookType.Book  },
                    Quantity = 3,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 4
                },
                new BookStore 
                {
                    Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                    Quantity = 5,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 2
                }
            };
        }
        public RentBook RentReturnBook()
        {
            return new RentBook
            {
                BookStore = new BookStore{ Book = new Book{ Title = "Rayuela" }, Quantity = 1 },
                Customer = new Customer{ Name = "Bruce Wayne" }
            };
        }

        public List<BookStore> StoredBooksMinimunStock()
        {
            return new List<BookStore>
            {
                new BookStore 
                {
                    Book = new Book { Title = "Rayuela", Type = BookType.Book  },
                    Quantity = 2,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 4
                },
                new BookStore 
                {
                    Book = new Book { Title = "El Tunel", Type = BookType.Book  },
                    Quantity = 0,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 3
                },
                new BookStore 
                {
                    Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                    Quantity = 10,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 2
                }
            };
        }

        public IList<BookStore> AssertStoredBooksMinimunStock()
        {
            return new List<BookStore>
            {
                new BookStore 
                {
                    Book = new Book { Title = "Rayuela", Type = BookType.Book  },
                    Quantity = 2,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 4
                },
                new BookStore 
                {
                    Book = new Book { Title = "El Tunel", Type = BookType.Book  },
                    Quantity = 0,
                    Quality = 20,
                    EntryDate = DateTime.Now,
                    MinimunStock = 3
                }
            };
        }

    }

}