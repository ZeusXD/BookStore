using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class StrategyTypeBookQuality : IStrategyTypeBookQuality
    {
        public void DefineBookQuality(BookStore book)
        {
            var quality = book.Quality - (DateTime.Now - book.EntryDate).Days;
            
            book.Quality = quality;
            if(quality <= 0)
            {
                throw new Exception($"The Book has a quality of {quality}, its necesary remove from the inventory");
            }
        }
    }
}