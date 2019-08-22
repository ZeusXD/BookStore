using System.Collections.Generic;

namespace BookToHome.Utils
{
    public class RuleContext
    {
  
        public void RuleValidation<T>(T obj)
        {
            var className = typeof(T).FullName;
            
            var rulesValidation = new StrategyContext().StrategyDef(className);

            foreach (var rule in rulesValidation)
            {
                rule.BuildException(obj);
            }

        }

    }
}