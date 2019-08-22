using System.Collections.Generic;

namespace BookToHome.Utils
{
    public interface IStrategyDefinition
    {
        List<IRuleValidation> DefinitionType();
    }
}