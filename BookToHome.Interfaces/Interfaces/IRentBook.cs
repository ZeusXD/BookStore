using BookToHome.Models;

namespace BookToHome.Interfaces
{
    public interface IBookRental
    {
        Result<string> RentBook(RentBook rent);

        Result<string> ReturnBook(RentBook rent);
    }
}