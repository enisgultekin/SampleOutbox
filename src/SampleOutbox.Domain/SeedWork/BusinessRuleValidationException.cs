using System;

namespace SampleOutbox.Domain.SeedWork
{
    public class BusinessRuleValidationException : Exception
    {
        public string Details { get;  }

        public override string ToString()
        {
            return string.Empty;
            // return $"";
        }
    }
}