//-----------------------------------------------------------------
//    <copyright file="Notification.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_6.Constants;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents an abstract base class for different types of notifications,
    /// such as email, SMS, and push notifications.
    /// </summary>
    public abstract class Notification
    {
        #region Private Fields
        /// <summary>
        /// The recipient of the notification.
        /// </summary>
        private string _recipient = string.Empty;
        
        /// <summary>
        /// The message content of the notification.
        /// </summary>
        private string _message = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the message content of the notification.
        /// </summary>
        /// <exception cref="ArgumentException">The message is blank or has an invalid length.</exception>
        public string Message
        {
            get => _message;
            private set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);

                if (value.Length < Limits.MinLength || value.Length > Limits.MaxLength)
                {
                    throw new ArgumentException(
                        $"Message must be between {Limits.MinLength} and {Limits.MaxLength} characters.",
                        nameof(value));
                }

                _message = value;
            }
        }

        /// <summary>
        /// Gets the recipient of the notification.
        /// </summary>
        /// <exception cref="ArgumentException">The recipient is blank.</exception>
        public string Recipient
        {
            get => _recipient;
            private set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(value);
                _recipient = value.Trim();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class with the specified message and recipient.
        /// </summary>
        /// <param name="message">The message content of the notification.</param>
        /// <param name="recipient">The recipient of the notification.</param>
        /// <exception cref="ArgumentException">The message or recipient is invalid.</exception>
        protected Notification(string message, string recipient)
        {
            Message = message;
            Recipient = recipient;
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Sends the notification to the recipient.
        /// This method must be implemented by derived classes.
        /// </summary>
        public abstract void Send();

        #endregion
    }
}
