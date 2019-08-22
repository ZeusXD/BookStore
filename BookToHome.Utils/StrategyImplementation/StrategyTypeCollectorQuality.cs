using System;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class StrategyTypeCollectorQuality : IStrategyTypeBookQuality
    {
        public void DefineBookQuality(BookStore book)
        {
            var quality = book.Quality + (DateTime.Now - book.EntryDate).Days;
            
            book.Quality = quality;
        }
    }
}