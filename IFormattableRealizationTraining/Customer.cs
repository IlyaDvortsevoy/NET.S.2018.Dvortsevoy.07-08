using System;
using System.Globalization;

namespace IFormattableRealizationTraining
{
    /// <summary>
    /// Represents model of a customer
    /// </summary>
    public class Customer : IFormattable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IFormattableRealizationTraining.Customer"/> class
        /// with default parametres
        /// </summary>
        /// <exception cref="ArgumentException"> Thrown when name or contactPhone is null or empty </exception>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when revenue is less then zero </exception>
        public Customer()
            : this("Jeffrey Richter", "+1(425) 555 - 0100", 1000000)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IFormattableRealizationTraining.Customer"/> class
        /// with specific parametres
        /// </summary>
        /// <param name="name"> Name of the customer </param>
        /// <param name="contactPhone"> Contact phone of the customer </param>
        /// <param name="revenue"> Revenue of the customer </param>
        /// <exception cref="ArgumentException"> Thrown when name or contactPhone is null or empty </exception>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when revenue is less then zero </exception>
        public Customer(string name, string contactPhone, decimal revenue)
        {
            ValidateArgs(name, contactPhone, revenue);

            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets name of the current customer
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets contact phone of the current customer
        /// </summary>
        public string ContactPhone { get; private set; }

        /// <summary>
        /// Gets revenue of the current customer
        /// </summary>
        public decimal Revenue { get; private set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns string representation of the name, contact phone and revenue
        /// of the current customer
        /// </summary>
        /// <returns> String representation of the customer's info </returns>
        /// <exception cref="FormatException"> Thrown when format specifier is invalid </exception>
        public override string ToString()
        {
            return ToString("NCR", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns string representation of the current customer's info
        /// in a specific format
        /// </summary>
        /// <param name="format"> Format specifier of string representation:
        /// N - show only name
        /// C - show only contact phone
        /// R - show only revenue
        /// NC - show name and contact phone
        /// NR - show name and revenue
        /// CR - show contact phone and revenue
        /// NCR - show name, contact phone and revenue
        /// </param>
        /// <returns> String representation of the customer's info </returns>
        /// <exception cref="FormatException"> Thrown when format specifier is invalid </exception>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns string representation of the current customer's info
        /// in a specific format using specific format provider
        /// </summary>
        /// <param name="format">Format specifier of string representation:
        /// N - show only name
        /// C - show only contact phone
        /// R - show only revenue
        /// NC - show name and contact phone
        /// NR - show name and revenue
        /// CR - show contact phone and revenue
        /// NCR - show name, contact phone and revenue
        /// </param>
        /// <param name="provider"> Specific format provider </param>
        /// <returns> String representation of the customer's info </returns>
        /// <exception cref="FormatException"> Thrown when format specifier is invalid </exception>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "NCR";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                // Show only name
                case "N":
                    return string.Format(provider, "Customer record: {0}", Name);

                // Show only contact phone
                case "C":
                    return string.Format(provider, "Customer record: {0}", ContactPhone);

                // Show only revenue
                case "R":
                    return string.Format(provider, "Customer record: {0}", Revenue);

                // Show name and contact phone
                case "NC":
                    return string.Format(provider, "Customer record: {0}, {1}", Name, ContactPhone);

                // Show name and revenue
                case "NR":
                    return string.Format(provider, "Customer record: {0}, {1}", Name, Revenue);

                // Show contact phone and revenue
                case "CR":
                    return string.Format(provider, "Customer record: {0}, {1}", ContactPhone, Revenue);

                // Show name, contact phone and revenue
                case "NCR":
                    return string.Format(provider, "Customer record: {0}, {1}, {2}", Name, ContactPhone, Revenue);
                default:
                    throw new FormatException("Invalid string format");
            }
        }
        #endregion

        #region Private Helper Methods
        private void ValidateArgs(
            string name, 
            string contactPhone, 
            decimal revenue)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            else if (string.IsNullOrEmpty(contactPhone))
            {
                throw new ArgumentException(nameof(contactPhone));
            }
            else if (revenue < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(revenue));
            }
        }
        #endregion
    }
}