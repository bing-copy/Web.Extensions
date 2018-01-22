using System;

namespace Cosmos.AspNetCore.Extensions.Internal
{
    public static class CheckHelper
    {
        public static string SetterCheckingWhetherArgumentNullOrNot(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value;
        }

        public static string SetterCheckingWhetherArgumentOutOfRangeOrNot(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return value;
        }
    }
}
