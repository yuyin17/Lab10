using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab10
{
    public class IncidentDB
    {
        public string Dir { get; set; } = string.Empty;
        public string Path { get; set; } = "Incidents.txt";

        public List<Incident> GetIncidents()
        {
            var incidents = new List<Incident>();

            string baseDir = string.IsNullOrWhiteSpace(Dir)
                ? AppDomain.CurrentDomain.BaseDirectory
                : Dir;

            string filePath = System.IO.Path.Combine(baseDir, Path);

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] fields = line.Split('|');
                if (fields.Length < 8)
                    continue;

                int incidentId = int.Parse(fields[0].Trim());
                int customerId = int.Parse(fields[1].Trim());
                string productCode = fields[2].Trim();

                string techText = fields[3].Trim();
                int? techId = string.IsNullOrEmpty(techText) ? (int?)null : int.Parse(techText);

                DateTime dateOpened = DateTime.Parse(fields[4].Trim(), CultureInfo.InvariantCulture);

                string closedText = fields[5].Trim();
                DateTime? dateClosed = string.IsNullOrEmpty(closedText)
                    ? (DateTime?)null
                    : DateTime.Parse(closedText, CultureInfo.InvariantCulture);

                string title = fields[6].Trim();
                string description = fields[7].Trim();

                incidents.Add(new Incident
                {
                    IncidentID = incidentId,
                    CustomerID = customerId,
                    ProductCode = productCode,
                    TechID = techId,
                    DateOpened = dateOpened,
                    DateClosed = dateClosed,
                    Title = title,
                    Description = description
                });
            }

            return incidents;
        }
    }
}