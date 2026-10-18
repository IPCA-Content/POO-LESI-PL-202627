//-----------------------------------------------------------------
//    <copyright file="Sms.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>22:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using System.Text.Json;

namespace Lesson_6.Models
{
    /// <summary>
    /// Represents an SMS notification sent through the Textbelt service.
    /// </summary>
    public class Sms : Notification
    {
        #region Private Fields

        /// <summary>
        /// The static <see cref="HttpClient"/> instance used for sending HTTP requests to Textbelt.
        /// </summary>
        private static readonly HttpClient HttpClient = new();
        
        /// <summary>
        /// The API key for the Textbelt service. The default value is "textbelt" for free testing.
        /// </summary>
        private readonly string _apiKey;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Sms"/> class.
        /// </summary>
        /// <param name="message">The message content of the SMS.</param>
        /// <param name="recipient">The phone number with country code (e.g. +351912345678).</param>
        /// <param name="apiKey">Textbelt API key ('textbelt' is the free test key).</param>
        /// <exception cref="ArgumentException">The message or phone number is invalid.</exception>
        public Sms(string message, string recipient, string apiKey = "textbelt")
            : base(message, recipient)
        {
            if (!IsValidPhoneNumber(Recipient))
            {
                throw new ArgumentException("Recipient must start with '+' followed by 8 to 15 digits (e.g. +351912345678).", nameof(recipient));
            }

            _apiKey = apiKey;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks that the phone number is '+' followed by 8 to 15 digits.
        /// </summary>
        /// <param name="phone">The phone number to validate.</param>
        /// <returns>True if the number has a valid international format; otherwise false.</returns>
        private static bool IsValidPhoneNumber(string phone)
        {
            if (!phone.StartsWith('+') || phone.Length < 9 || phone.Length > 16)
            {
                return false;
            }

            for (int i = 1; i < phone.Length; i++)
            {
                if (!char.IsAsciiDigit(phone[i]))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Overrides of Notification

        /// <summary>
        /// Sends the SMS through Textbelt, or simulates the send if the service is unreachable.
        /// </summary>
        public override void Send()
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "phone", Recipient },
                    { "message", Message },
                    { "key", _apiKey }
                };

                using var content = new FormUrlEncodedContent(parameters);
                using HttpResponseMessage response = HttpClient.PostAsync("https://textbelt.com/text", content).GetAwaiter().GetResult();

                string responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                using var doc = JsonDocument.Parse(responseBody);
                bool success = doc.RootElement.TryGetProperty("success", out var successProp) && successProp.GetBoolean();

                if (success)
                {
                    Console.WriteLine($"[SMS] Successfully delivered to {Recipient} via Textbelt!");
                }
                else
                {
                    string errorReason = doc.RootElement.TryGetProperty("error", out var errorProp)
                        ? errorProp.GetString() ?? "Unknown error"
                        : responseBody;
                    Console.WriteLine($"[SMS Result] Could not send to {Recipient}: {errorReason}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SMS Error] {ex.Message} -> Falling back to console simulation.");
                Console.WriteLine($"[SMS (Simulation)] To: {Recipient} | Message: {Message}");
            }
        }

        #endregion
    }
}
