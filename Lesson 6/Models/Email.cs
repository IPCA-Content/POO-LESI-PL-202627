//-----------------------------------------------------------------
//    <copyright file="Email.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Net;
using System.Net.Mail;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents an email notification sent through Gmail SMTP.
    /// </summary>
    public class Email : Notification
    {
        #region Private Fields

        /// <summary>
        /// The optional Gmail sender address for sending the email.
        /// </summary>
        private readonly string? _senderEmail;
        
        /// <summary>
        /// The optional Gmail App Password for authenticating the sender.
        /// </summary>
        private readonly string? _appPassword;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="message">The message content of the email.</param>
        /// <param name="recipient">The recipient email address.</param>
        /// <param name="senderEmail">Optional Gmail sender address.</param>
        /// <param name="appPassword">Optional Gmail App Password.</param>
        /// <exception cref="ArgumentException">The message or recipient is invalid.</exception>
        public Email(string message, string recipient, string? senderEmail = null, string? appPassword = null)
            : base(message, recipient)
        {
            if (!IsValidEmail(Recipient))
            {
                throw new ArgumentException("Recipient must be a valid email address (e.g. name@ipca.pt).", nameof(recipient));
            }

            _senderEmail = senderEmail;
            _appPassword = appPassword;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks that the email has one '@', a local part, and a domain containing a dot.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the address has a valid basic format; otherwise false.</returns>
        private static bool IsValidEmail(string email)
        {
            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            string domain = parts[1];
            return parts[0].Length > 0
                   && domain.Contains('.')
                   && !domain.StartsWith('.')
                   && !domain.EndsWith('.');
        }

        #endregion

        #region Overrides of Notification

        /// <summary>
        /// Sends the email through Gmail SMTP when credentials exist; otherwise simulates the send.
        /// </summary>
        public override void Send()
        {
            if (string.IsNullOrWhiteSpace(_senderEmail) || string.IsNullOrWhiteSpace(_appPassword))
            {
                Console.WriteLine($"[Email (Simulation)] Sent to {Recipient}: {Message}");
                return;
            }

            try
            {
                using var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_senderEmail.Trim(), _appPassword.Replace(" ", ""))
                };

                using var mail = new MailMessage(_senderEmail.Trim(), Recipient, "Lesson 6 - Notification Demo", Message);

                client.Send(mail);
                Console.WriteLine($"[Email] Successfully delivered via Gmail to {Recipient}");
            }
            catch (Exception ex)
            {
                string details = ex.InnerException != null ? $"{ex.Message} -> {ex.InnerException.Message}" : ex.Message;
                Console.WriteLine($"[Email Error] {details}");
            }
        }

        #endregion
    }
}
