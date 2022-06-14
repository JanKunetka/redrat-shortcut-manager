using System;
using System.Collections.Generic;

namespace RedRats.Safety
{
    /// <summary>
    /// Contains various method for checking correctness of given parameters. If a method fails to pass, it throws an exception.
    /// </summary>
    public static class SafetyNet
    {
        public static event Action<string> OnFireErrorMessage;

        #region Object Checks

        /// <summary>
        /// Checks if a given object is not null.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        /// <exception cref="SafetyNetException"></exception>
        public static void EnsureIsNotNull(object obj, string variableName)
        {
            if (obj == null)
            {
                string message = $"'{variableName}' cannot be null.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        #endregion

        #region Int Checks

        /// <summary>
        /// Checks if an number is not equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="allowedValue">The value it cannot equal to.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsEqual(int number, int allowedValue, string variableName)
        {
            if (number != allowedValue)
            {
                string message = $"Number called '{variableName}' must only equal to {allowedValue}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }
        
        /// <summary>
        /// Checks if an number is not equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="disallowedValue">The value it cannot equal to.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsNotEqual(int number, int disallowedValue, string variableName)
        {
            if (number == disallowedValue)
            {
                string message = $"Number called '{variableName}' must not equal to {disallowedValue}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is bigger than a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minSize">Minimum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsBiggerThan(int number, int minSize, string variableName)
        {
            if (number <= minSize)
            {
                string message = $"Number called '{variableName}' must be above {minSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is bigger than or equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minSize">Minimum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsBiggerOrEqualTo(int number, int minSize, string variableName)
        {
            if (number < minSize)
            {
                string message = $"Number called '{variableName}' must be above or equal to {minSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is smaller than a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maxSize">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsSmallerThan(int number, int maxSize, string variableName)
        {
            if (number >= maxSize)
            {
                string message = $"Number called '{variableName}' must be below {maxSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is smaller than or equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maxSize">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsSmallerOrEqualTo(int number, int maxSize, string variableName)
        {
            if (number > maxSize)
            {
                string message = $"Number called '{variableName}' must be below or equal to {maxSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is within a given range (both inclusive).
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="lowBounds">Minimum value allowed.</param>
        /// <param name="highBounds">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureIntIsInRange(int number, int lowBounds, int highBounds, string variableName)
        {
            if (number < lowBounds && number > highBounds)
            {
                string message = $"Number called '{variableName}' must be in range of {lowBounds} - {highBounds}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        #endregion

        #region Float Checks

        /// <summary>
        /// Checks if a number is not equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="allowedValue">The value it cannot equal to.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsEqual(float number, float allowedValue, string variableName)
        {
            if (Math.Abs(number - allowedValue) > 0.01f)
            {
                string message = $"Number called '{variableName}' must only equal to {allowedValue}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }
        
        /// <summary>
        /// Checks if a number is not equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="disallowedValue">The value it cannot equal to.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsNotEqual(float number, float disallowedValue, string variableName)
        {
            if (Math.Abs(number - disallowedValue) < 0.01f)
            {
                string message = $"Number called '{variableName}' must not equal to {disallowedValue}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is bigger than a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minSize">Minimum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsBiggerThan(float number, float minSize, string variableName)
        {
            if (number <= minSize)
            {
                string message = $"Number called '{variableName}' must be above {minSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is bigger than or equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="minSize">Minimum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsBiggerOrEqualTo(float number, float minSize, string variableName)
        {
            if (number < minSize)
            {
                string message = $"Number called '{variableName}' must be above or equal to {minSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is smaller than a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maxSize">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsSmallerThan(float number, float maxSize, string variableName)
        {
            if (number >= maxSize)
            {
                string message = $"Number called '{variableName}' must be below {maxSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is smaller than or equal to a specific value.
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="maxSize">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsSmallerOrEqualTo(float number, float maxSize, string variableName)
        {
            if (number > maxSize)
            {
                string message = $"Number called '{variableName}' must be below or equal to {maxSize}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is within a given range (both inclusive).
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="lowBounds">Minimum value allowed.</param>
        /// <param name="highBounds">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureValueIsInRange(float number, float lowBounds, float highBounds, string variableName)
        {
            if (number < lowBounds && number > highBounds)
            {
                string message = $"Number called '{variableName}' must be in range of {lowBounds} - {highBounds}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if an number is within a given range (both inclusive).
        /// </summary>
        /// <param name="number">The number to check.</param>
        /// <param name="lowBounds">Minimum value allowed.</param>
        /// <param name="highBounds">Maximum value allowed.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        public static void EnsureFloatIsInRange(float number, float lowBounds, float highBounds, string variableName)
        {
            if (number < lowBounds && number > highBounds)
            {
                string message = $"Number called '{variableName}' must be in range of {lowBounds} - {highBounds}. ({number})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }
        #endregion
        
        #region String Checks
        /// <summary>
        /// Checks if a given string is not null or empty.
        /// </summary>
        /// <param name="stringObject">The string to check.</param>
        /// <param name="variableName">Name of the variable.</param>
        public static void EnsureStringNotNullOrEmpty(string stringObject, string variableName)
        {
            if (string.IsNullOrEmpty(stringObject))
            {
                string message = $"The string '{variableName}' cannot be null nor empty.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }
        
        /// <summary>
        /// Makes sure that a string is longer than minLimit.
        /// </summary>
        /// <param name="stringObject">The string to check.</param>
        /// <param name="minLimit">Minimum characters allowed for the string.</param>
        /// <param name="variableName">Description of wronged variable.</param>
        /// <exception cref="SafetyNetException"></exception>
        public static void EnsureStringMinLimit(string stringObject, int minLimit, string variableName)
        {
            if (stringObject.Length < minLimit)
            {
                string message = $"The string '{variableName}' with value '{stringObject}' cannot have less than or equal to {minLimit} characters! ({stringObject.Length})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Makes sure that a string is shorter than maxLimit.
        /// </summary>
        /// <param name="stringObject">The string to check.</param>
        /// <param name="maxLimit">Maximum characters allowed for the string.</param>
        /// <param name="variableName">Description of wronged variable.</param>
        /// <exception cref="SafetyNetException"></exception>
        public static void EnsureStringMaxLimit(string stringObject, int maxLimit, string variableName)
        {
            if (stringObject.Length > maxLimit)
            {
                string message = $"The string '{variableName}' with value '{stringObject}' cannot have more than or equal to {maxLimit} characters! ({stringObject.Length})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetException(message);
            }
        }

        /// <summary>
        /// Checks if a string's amount of characters is within a given range.
        /// </summary>
        /// <param name="stringObject">The string to check.</param>
        /// <param name="minLimit">Range minimum.</param>
        /// <param name="maxLimit">Range maximum.</param>
        /// <param name="variableName">Name of the wronged variable.</param>
        /// <exception cref="SafetyNetException"></exception>
        public static void EnsureStringInRange(string stringObject, int minLimit, int maxLimit, string variableName)
        {
            EnsureStringMinLimit(stringObject, minLimit, variableName);
            EnsureStringMaxLimit(stringObject, maxLimit, variableName);
        }
        #endregion

        #region List Checks

        /// <summary>
        /// Checks if a given list is not empty.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotEmpty<T>(IList<T> list, string variableName)
        {
            if (list.Count <= 0)
            {
                string message = $"The list '{variableName}' cannot be empty.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list is not null.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotNullOrEmpty<T>(IList<T> list, string variableName)
        {
            if (list == null || list.Count <= 0)
            {
                string message = $"The list '{variableName}' cannot be empty or null.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list has a size lower than a specific size.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="maxAllowedSize">Max allowed size for the list.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotLongerThan<T>(IList<T> list, int maxAllowedSize, string variableName)
        {
            if (list.Count > maxAllowedSize)
            {
                string message = $"The list '{variableName}' cannot have more than {maxAllowedSize} elements. ({list.Count})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list has a size lower or equal to a specific size.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="maxAllowedSize">Max allowed size for the list.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotLongerOrEqualThan<T>(IList<T> list, int maxAllowedSize, string variableName)
        {
            if (list.Count >= maxAllowedSize)
            {
                string message = $"The list '{variableName}' cannot have more or equal to {maxAllowedSize} elements. ({list.Count})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list has a size bigger than a specific value.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="minAllowedSize">Min allowed size for the list.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotShorterThan<T>(IList<T> list, int minAllowedSize, string variableName)
        {
            if (list.Count < minAllowedSize)
            {
                string message = $"The list '{variableName}' cannot have less than {minAllowedSize} elements. ({list.Count})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list has a size bigger or equal to a specific value.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="minAllowedSize">Min allowed size for the list.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsNotShorterOrEqualThan<T>(IList<T> list, int minAllowedSize, string variableName)
        {
            if (list.Count <= minAllowedSize)
            {
                string message = $"The list '{variableName}' cannot have less or equal to {minAllowedSize} elements. ({list.Count})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Checks if a given list has a specific size.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <param name="size">The allowed size for the list.</param>
        /// <param name="variableName">The name of the list</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListIsLongExactly<T>(IList<T> list, int size, string variableName)
        {
            if (list.Count == size)
            {
                string message = $"The list '{variableName}' must have exactly {size} elements. ({list.Count})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        /// <summary>
        /// Ensures a list does not contain a specific object.
        /// </summary>
        /// <typeparam name="T">Any object type.</typeparam>
        /// <param name="list">The list to check.</param>
        /// <param name="value">The object we check the duplicity for.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListNotContains<T>(IList<T> list, T value, string variableName)
        {
            if (list.Contains(value))
            {
                string message = $"The list '{variableName}' already contains '{value}'.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }
        
        /// <summary>
        /// Ensures that list contains a specific object.
        /// </summary>
        /// <typeparam name="T">Any object type.</typeparam>
        /// <param name="list">The list to check.</param>
        /// <param name="value">The object we check the duplicity for.</param>
        /// <param name="variableName">Name of the checked variable.</param>
        /// <exception cref="SafetyNetCollectionException"></exception>
        public static void EnsureListContains<T>(IList<T> list, T value, string variableName) where T : class
        {
            if (!list.Contains(value))
            {
                string message = $"The list '{variableName}' does not contain '{value}'.";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }

        public static void EnsureIndexWithingCollectionRange<T>(int index, ICollection<T> collection, string collectionName)
        {
            if (index < 0 || index > collection.Count - 1)
            {
                string message = $"The index doesn't fit on the '{collectionName}' collection. Length is {collection.Count}. ({index})";
                OnFireErrorMessage?.Invoke(message);
                throw new SafetyNetCollectionException(message);
            }
        }
        #endregion

        /// <summary>
        /// Throw a custom error message, without raising an exception.
        /// </summary>
        /// <param name="message">The message to throw.</param>
        public static void ThrowMessage(string message) => OnFireErrorMessage?.Invoke($"Safety Net - {message}");

    }
}