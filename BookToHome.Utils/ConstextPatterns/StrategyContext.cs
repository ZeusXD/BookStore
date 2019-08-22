using System.Collections.Generic;
using BookToHome.Models;

namespace BookToHome.Utils
{
    public class StrategyContext
    {
        private IDictionary<string, List<IRuleValidation>> definitionType;
        private IDictionary<BookType, IStrategyTypeBookQuality> qualityType;
        public StrategyContext()
        {
            definitionType = new Dictionary<string, List<IRuleValidation>>
            {
                {"BookToHome.Models.BookStore", new StrategyDefBookStore().DefinitionType()},
                {"BookToHome.Models.RentBook", new StrategyDefRentBook().DefinitionType()}   
            };

            qualityType = new Dictionary<BookType, IStrategyTypeBookQuality>
            {
                { BookType.Book, new StrategyTypeBookQuality() },
                { BookType.Comic, new StrategyTypeComicQuality() },
                { BookType.CollectorsEdition, new StrategyTypeCollectorQuality() }
            };


        }

        public List<IRuleValidation> StrategyDef(string className)
        {
            return definitionType[className];                  
        }

        public void StrategyTypeQuality(BookStore book)
        {
            qualityType[book.Book.Type].DefineBookQuality(book);
        }

    }
}