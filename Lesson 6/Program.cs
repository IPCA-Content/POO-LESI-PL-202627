//-----------------------------------------------------------------
//    <copyright file="Program.cs"    company="IPCA">
//     Copyright IPCA-EST. All rights reserved.
//    </copyright>
//    <date>12-10-2026</date>
//    <time>21:01</time>
//    <author>Ernesto Casanova</author>
//-----------------------------------------------------------------

using Lesson_6.Models;
using Lesson_6.Utils;

namespace Lesson_6
{
    /// <summary>
    /// Demonstrates polymorphism with the abstract <see cref="Notification"/> class.
    /// </summary>
    internal static class Program
    {
        #region Entry point

        /// <summary>
        /// Creates one notification of each type and sends them through the base class.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        private static void Main(string[] args)
        {
            EnvLoader.Load();

            Console.WriteLine("=== Lesson 6: Polymorphism with Abstract Class Notification ===\n");

            string? senderEmail = Environment.GetEnvironmentVariable("GMAIL_SENDER");
            string? appPassword = Environment.GetEnvironmentVariable("GMAIL_APP_PASSWORD");
            string emailRecipient = Environment.GetEnvironmentVariable("EMAIL_RECIPIENT") ?? "student@example.com";
            string pushTopic = Environment.GetEnvironmentVariable("PUSH_TOPIC") ?? "ipca-poo-demo";
            string smsRecipient = Environment.GetEnvironmentVariable("SMS_RECIPIENT") ?? "+351912345678";
            string smsApiKey = Environment.GetEnvironmentVariable("TEXTBELT_API_KEY") ?? "textbelt";
            
            Notification[] notifications =
            [
                new Email("Hello! This is a test email sent from Lesson 6.", emailRecipient, senderEmail, appPassword),
                new Push("Hello from Lesson 6! Push notification arrived.", pushTopic),
                new Sms("Lesson 6 SMS test.", smsRecipient, smsApiKey)
            ];

            foreach (Notification notification in notifications)
            {
                Console.WriteLine($"\nDispatching notification to: {notification.Recipient}");
                notification.Send();
            }

            Console.WriteLine("\nAll notifications executed.");
        }

        #endregion
    }
}
