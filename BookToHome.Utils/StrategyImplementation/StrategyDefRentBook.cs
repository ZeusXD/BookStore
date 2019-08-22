using System.Collections.Generic;

namespace BookToHome.Utils
{
    public class StrategyDefRentBook : IStrategyDefinition
    {
        public List<IRuleValidation> DefinitionType()
        {
            var rulesValidation = new List<IRuleValidation>();
            rulesValidation.Add(new RuleValidationRentEmpty());
            return rulesValidation;
        }
    }
}