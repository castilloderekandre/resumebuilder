using ResumeBuilder.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace ResumeBuilder
{
    // Title, start date, end date, has one date, has no date, organization, has organization, address, has address, body
    internal static class Autofill
    {
        static string[] jobTitles = ["Plumber", "Electrician", "Mechanic", "IT", "SWE", "Security", "Salesperson"];
        static string[] projectTitles = ["Tic-Tac-Toe", "Console App", "REST API Implementation", "Ubuntu Server"];
        static string[] certificationTitles = ["CompTIA+", "Networking+", "Security+", "Networking Basics", "CCNA"];
        static string[] organizations = ["Apple", "Google", "Meta", "Spotify", "Chevrolet", "Chrysler", "Dodge"];
        static string[] street_numbers = ["123", "5050", "1234", "1574", "520", "8088", "7134"];
        static string[] street_names = ["Washington", "Martin Luther King Jr.", "Abraham Lincoln", "Wind Whisper", "Savanna Pasture", "Beckendorff"];
        static string[] street_type = ["Avenue", "Boulevard", "Lane", "Street", "Drive"];
        static string[] bodies = [
            "Did cleaning duties.",
            "Did opening duties:\n - Set up chairs\n - Assisted team lead",
            "Did closing duties:\n - Restocked\n - Sweeped\n - Cleaned"
        ];

        public static Entry GenerateEntry()
        {
            Random random = new();

            string[] titles;

            double result = random.NextDouble();

            if (result < 0.3)
                titles = jobTitles;
            else if (result > 0.3 && result <= 0.6)
                titles = projectTitles;
            else
                titles = certificationTitles;

            DateTime? startDate = null;
            DateTime? endDate = null;
            bool hasNoDate = random.NextDouble() < 0.5;
            bool hasOneDate = random.NextDouble() < 0.5 && !hasNoDate;

            if (!hasNoDate)
            {
                startDate = new DateTime(2000, 1, 1);

                if (!hasOneDate)
                    endDate = new DateTime(2010, 2, 3);
            }

            bool hasOrganization = random.NextDouble() < 0.5;
            bool hasAddress = random.NextDouble() < 0.5;

            return new Entry(
                PickOne(titles),
                startDate,
                endDate,
                hasOneDate,
                hasNoDate,
                PickOne(organizations, hasOrganization),
                hasOrganization,
                GenerateStreet(),
                hasAddress,
                PickOne(bodies)
                );
        }

        static string GenerateStreet()
        {
            return PickOne(street_numbers) + " " + PickOne(street_names) + " " + PickOne(street_type);
        }

        static string? PickOne(string[] collection, bool valueCheck = true)
        {
            if (!valueCheck)
                return null;

            Random random = new();
            return collection[random.Next(collection.Length)];
        }
    }
}
