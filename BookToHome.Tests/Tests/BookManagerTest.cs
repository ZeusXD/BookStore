using System;
using System.Collections.Generic;
using System.Linq;
using BookToHome.Data;
using BookToHome.Interfaces;
using BookToHome.Logic;
using BookToHome.Models;
using BookToHome.Utils;
using Xunit;

namespace BookToHome.Tests
{

    public class BookManagerTest
    {
        private readonly IBookManager bookManager;
        private readonly IBookData bookData;
        private readonly TestMocks testMocks;

        public BookManagerTest()
        {
            bookData = new BookStoreDataMock(new List<BookStore>());
            bookManager = new BookManager(bookData);
            testMocks = new TestMocks();  
        }

        #region Tests for AddBook method 
        
        [Fact]
        public void Return_Unsuccessful_When_Receives_null()
        {
            var result = bookManager.AddBook(null);
            Assert.False(result.Successful);
        }

        [Theory]
        [InlineData(null,false)]
        public void Return_Unsuccessful_When_Receives_Book_Is_Null(Book input, bool expectedValue)
        {
            var newRecord = new BookStore{
                Quantity = 4,
                Book = input,
                Quality = 20,
                EntryDate = DateTime.Now,
                MinimunStock = 1
            };           
            var result = bookManager.AddBook(newRecord);
            Assert.Equal(expectedValue, result.Successful);          
        }

        [Theory]
        [InlineData("",false)]
        [InlineData(null,false)]
        public void Return_Unsuccessful_When_Receives_Title_Is_Empty_Or_Null(string input, bool expectedValue)
        {
            var newRecord = new BookStore{
                Quantity = 4,
                Book = new Book { Title = input, Type = BookType.Book },
                Quality = 20,
                EntryDate = DateTime.Now,
                MinimunStock = 1
            };
            var result = bookManager.AddBook(newRecord);
            Assert.Equal(expectedValue, result.Successful);
        }

        [Theory]
        [InlineData(-4, false)]
        public void Return_Unsuccessful_When_Receives_Quantity_Is_Negative(int input, bool expectedValue)
        {
            var newRecord = new BookStore{
                Quantity = input,
                Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                Quality = 20,
                EntryDate = DateTime.Now,
                MinimunStock = 1
            };
            var result = bookManager.AddBook(newRecord);
            Assert.Equal(expectedValue, result.Successful);

        }


        [Fact]
        public void Return_Successful_When_Add()
        {
            var newRecord = new BookStore{
                Quantity = 5,
                Book = new Book { Title = "El Aleph", Type = BookType.Book  },
                Quality = 20,
                EntryDate = DateTime.Now,
                MinimunStock = 1

            };
            var result = bookManager.AddBook(newRecord);
            Assert.True(result.Successful);
        }
        
        [Fact]
        public void Return_Unsuccessful_When_Book_Quality_0()
        {
            var newRecord = new BookStore{
                Quantity = 5,
                Book = new Book { Title = "1984", Type = BookType.Book  },
                Quality = 5,
                EntryDate = new DateTime(2019, 8, 13),
                MinimunStock = 1

            };
            var result = bookManager.AddBook(newRecord);
            Assert.False(result.Successful);
        }

        [Fact]
        public void Return_Unsuccessful_When_Comic_Quality_0()
        {
            var newRecord = new BookStore{
                Quantity = 5,
                Book = new Book { Title = "Amazing Spiderman #1", Type = BookType.Comic  },
                Quality = 10,
                EntryDate = new DateTime(2019, 8, 13),
                MinimunStock = 1
            };
            var result = bookManager.AddBook(newRecord);
            Assert.False(result.Successful);  
        }

        [Fact]
        public void Return_Successful_When_Collector_Quality_Increment()
        {
            var newRecord = new BookStore{
                Quantity = 5,
                Book = new Book { Title = "The Atlas Rebellion", Type = BookType.CollectorsEdition  },
                Quality = 0,
                EntryDate = new DateTime(2015, 8, 13),
                MinimunStock = 1
            };
            var result = bookManager.AddBook(newRecord);
            Assert.True(result.Content.Quality > 0);
        }

        #endregion

        #region Tests for ListBooks Method
        [Fact]
        public void Return_Unsuccessful_When_Result_Is_List()
        {
            var result = bookManager.ListStoredBooks();
            Assert.Equal(new List<BookStore>(), result.Content);
        }

        #endregion


        #region Test For MinimunStock method

        [Fact]
        public void Return_Successful_When_Get_MinimunStock_List()
        {
            var data = new BookStoreDataMock(testMocks.StoredBooksMinimunStock());
            var manager = new BookManager(data);

            var result = manager.ListMinimunStockBooks();

            var expected = testMocks.AssertStoredBooksMinimunStock().Select(b => b.Book.Title);
            var actual = result.Content.Select(b => b.Book.Title);

            Assert.Equal(expected, actual);

        }

        #endregion
    
    }


}