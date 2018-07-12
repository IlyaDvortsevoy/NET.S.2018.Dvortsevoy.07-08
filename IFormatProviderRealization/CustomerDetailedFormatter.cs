﻿using System;
using IFormattableRealizationTraining;

namespace IFormatProviderRealization
{
    /// <summary>
    /// Converts a value of the Customer class instance to its string representation
    /// </summary>
    public class CustomerDetailedFormatter : IFormatProvider, ICustomFormatter
    {
        #region Public Methods
        /// <summary>
        /// Returns an object that provides formatting services for the specified type
        /// </summary>
        /// <param name="formatType"> An object that specifies the type of format object to return </param>
        /// <returns> An instance of the object specified by formatType, if the IFormatProvider implementation can supply that type of object otherwise, null. </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Converts the value of a specified object to an equivalent string representation using specified format and culture-specific formatting information.
        /// </summary>
        /// <param name="format"> A format string containing formatting specifications </param>
        /// <param name="arg"> An object to format </param>
        /// <param name="formatProvider"> An object that supplies format information about the current instance </param>
        /// <returns> The string representation of the value of arg, formatted as specified by format and formatProvider </returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!formatProvider.Equals(this))
            {
                return null;
            }
           
            if (arg is Customer customer)
            {
                return $"Customer info -- Name: {customer.Name}, " +
                    $"Contact phone: {customer.ContactPhone}, Revenue: {customer.Revenue}.";
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}