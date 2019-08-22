using System;
using Xunit;
using BookToHome.Interfaces;
using BookToHome.Logic;
using BookToHome.Models;
using System.Collections.Generic;
using BookToHome.Data;


namespace BookToHome.Tests
{
    public class BookRentalTest
    {

        private TestMocks bookRentalMock;
        private RentBook rentBookMock;
        public BookRentalTest()
        {
            bookRentalMock = new TestMocks();         
        }

        #region Test for RentBook and ReturnBook methods

        [Fact]
        public void Return_Unsuccessful_When_Receives_Empty()
        {
            var bookDal = new BookStoreDataMock(bookRentalMock.StoredBooks1());
            var result = new BookRental(bookDal).RentBook(new RentBook());
            Assert.False(result.Successful);
        }

        [Fact]
        public void Return_Unsuccessful_When_Book_Is_Not_Stored()
        {
            rentBookMock = bookRentalMock.RentReturnBook();
            var bookDal = new BookStoreDataMock(bookRentalMock.StoredBooks());
            var result = new BookRental(bookDal).RentBook(rentBookMock);
            
            Assert.False(result.Successful);
        }

        [Fact]
        public void Return_Successful_Rent()
        {
            rentBookMock = bookRentalMock.RentReturnBook();
            var bookDal = new BookStoreDataMock(bookRentalMock.StoredBooks1());
            var result = new BookRental(bookDal).RentBook(rentBookMock);

            Assert.True(result.Successful);
        }

        [Fact]
        public void Return_Successful_Return()
        {
            rentBookMock = bookRentalMock.RentReturnBook();
            var bookDal = new BookStoreDataMock(bookRentalMock.StoredBooks2());
            var result = new BookRental(bookDal).ReturnBook(rentBookMock);
            Assert.True(result.Successful);
        }


        #endregion


    }
}