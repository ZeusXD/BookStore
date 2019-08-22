using System.Collections.Generic;

namespace BookToHome.Utils
{
    public class StrategyDefBookStore : IStrategyDefinition
    {
        public List<IRuleValidation> DefinitionType()
        {
            var rulesValidation = new List<IRuleValidation>();
            rulesValidation.Add(new RuleValidationBookStoreNull());
            rulesValidation.Add(new RuleValidationBookQuantity());
            rulesValidation.Add(new RuleValidationBookTitle());
            rulesValidation.Add(new RuleValidationBookQuality());
            return rulesValidation;          
        }
    }
}