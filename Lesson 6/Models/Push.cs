//-----------------------------------------------------------------
//    <copyright file="Push.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Text;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents a push notification delivered through ntfy.sh.
    /// </summary>
    public class Push : Notification
    {
        #region Private Fields

        /// <summary>
        /// The static <see cref="HttpClient"/> instance used for sending HTTP requests to ntfy.sh.
        /// </summary>
        private static readonly HttpClient HttpClient = new();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Push"/> class.
        /// </summary>
        /// <param name="message">The notification content.</param>
        /// <param name="recipient">The ntfy topic name (e.g. ipca-poo-demo).</param>
        /// <exception cref="ArgumentException">The message or topic is invalid.</exception>
        public Push(string message, string recipient)
            : base(message, recipient)
        {
            if (!IsValidTopic(Recipient))
            {
                throw new ArgumentException("Recipient must be a topic with 2 to 64 letters, digits, '-' or '_'.", nameof(recipient));
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks that the topic has 2 to 64 characters: letters, digits, '-' or '_'.
        /// </summary>
        /// <param name="topic">The topic name to validate.</param>
        /// <returns>True if the topic is valid; otherwise false.</returns>
        private static bool IsValidTopic(string topic)
        {
            if (topic.Length < 2 || topic.Length > 64)
            {
                return false;
            }

            foreach (char c in topic)
            {
                if (!char.IsAsciiLetterOrDigit(c) && c != '-' && c != '_')
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Overrides of Notification

        /// <summary>
        /// Sends the push notification to ntfy.sh, or simulates the send if the service is unreachable.
        /// </summary>
        public override void Send()
        {
            try
            {
                string url = $"https://ntfy.sh/{Recipient}";

                using var content = new StringContent(Message, Encoding.UTF8, "text/plain");
                using HttpResponseMessage response = HttpClient.PostAsync(url, content).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"[Push] Notification sent to topic '{Recipient}'. View live: {url}");
                }
                else
                {
                    Console.WriteLine($"[Push] HTTP failure with status {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Push Error] {ex.Message} -> Falling back to console simulation.");
                Console.WriteLine($"[Push (Simulation)] Topic: {Recipient} | Message: {Message}");
            }
        }

        #endregion
    }
}
