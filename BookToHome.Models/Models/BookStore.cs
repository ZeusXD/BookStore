using System;

namespace BookToHome.Models
{
    public class BookStore
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public int Quality { get; set; }
        public DateTime EntryDate { get; set; }
        public int MinimunStock { get; set; }
    }
}