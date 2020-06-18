namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// This Class is used to create Custom Exception
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Parameterized Constructor Used to Initialize the type of exception
        /// </summary>
        /// <param name="type">It contains the Type of exception</param>
        /// <param name="message">It contains the message</param>
        public CabInvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// It is used when value is null
            /// </summary>
            ValueCanNotBeEmpty,

            /// <summary>
            /// It is used when value is Empty
            /// </summary>
            ValueCanNotBeNull,

            /// <summary>
            /// It is used for any type of Exception
            /// </summary>
            Exception
        }
       
        public ExceptionType type
        /// <summary>
        /// Gets or Sets Reference of the Exception Type
        /// </summary>
        {
            get; set; 
        }
    }
}
