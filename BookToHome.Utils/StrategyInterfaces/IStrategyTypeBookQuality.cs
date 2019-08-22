using BookToHome.Models;

namespace BookToHome.Utils
{
    public interface IStrategyTypeBookQuality
    {
        void DefineBookQuality(BookStore book);
    }
}