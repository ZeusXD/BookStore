using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class StrategyTypeComicQuality : IStrategyTypeBookQuality
    {
        public void DefineBookQuality(BookStore book)
        {
            var quality = book.Quality - ((DateTime.Now - book.EntryDate).Days * 2);
            
            book.Quality = quality;
            if(quality <= 0)
            {
                throw new Exception($"The Comic has a quality of {quality}, its necesary remove from the inventory");
            }
        }
    }
}