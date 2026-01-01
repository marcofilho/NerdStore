using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects
{
    public class Validation
    {
        public static void ValidateIfEquals(object firstObject, object secondObject, string message)
        {
            if (firstObject.Equals(secondObject))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfDifferent(object firstObject, object secondObject, string message)
        {
            if (!firstObject.Equals(secondObject))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCaracters(string value, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateCaracters(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length < minimum || length > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateExpression(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfEmpty(string value, string message)
        {
            if (value is null || value.Trim().Length == 0)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfNull(object obj, string message)
        {
            if (obj is null)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThan(decimal amount, decimal minimum, string message)
        {
            if (amount < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThan(double amount, double minimum, string message)
        {
            if (amount < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThan(long amount, long minimum, string message)
        {
            if (amount < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThan(float amount, float minimum, string message)
        {
            if (amount < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThan(int amount, int minimum, string message)
        {
            if (amount < minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfGreaterThan(double amount, double maximum, string message)
        {
            if (amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfGreaterThan(long amount, long maximum, string message)
        {
            if (amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfGreaterThan(float amount, float maximum, string message)
        {
            if (amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfGreaterThan(decimal amount, decimal maximum, string message)
        {
            if (amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfGreaterThan(int amount, int maximum, string message)
        {
            if (amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMininumMaximum(double amount, double minimum, double maximum, string message)
        {
            if (amount < minimum || amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMininumMaximum(float amount, float minimum, float maximum, string message)
        {
            if (amount < minimum || amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMininumMaximum(int amount, int minimum, int maximum, string message)
        {
            if (amount < minimum || amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMininumMaximum(long amount, long minimum, long maximum, string message)
        {
            if (amount < minimum || amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateMininumMaximum(decimal amount, decimal minimum, decimal maximum, string message)
        {
            if (amount < minimum || amount > maximum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanMinimum(long amount, long minimum, string message)
        {
            if (amount <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanMinimum(decimal amount, decimal minimum, string message)
        {
            if (amount <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanMinimum(int amount, int minimum, string message)
        {
            if (amount <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfLessThanMinimum(float amount, float minimum, string message)
        {
            if (amount <= minimum)
            {
                throw new DomainException(message);
            }
        }
        public static void ValidateIfLessThanMinimum(double amount, double minimum, string message)
        {
            if (amount <= minimum)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfFalse(bool expression, string message)
        {

            if (!expression)
            {
                throw new DomainException(message);
            }
        }

        public static void ValidateIfTrue(bool expression, string message)
        {
            if (expression)
            {
                throw new DomainException(message);
            }
        }
    }
}
