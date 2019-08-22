
using System;

namespace BookToHome.Utils 
{
    public interface IRuleValidation
    {
        void BuildException<T>(T obj);
    }
}