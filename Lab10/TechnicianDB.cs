using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;

namespace Lab10
{
    public class TechnicianDB
    {
        public string Dir { get; set; } = string.Empty;
        public string Path { get; set; } = "Technicians.txt";

        public List<Technician> GetTechnicians()
        {
            var technicians = new List<Technician>();

            string baseDir = string.IsNullOrWhiteSpace(Dir)
                ? AppDomain.CurrentDomain.BaseDirectory
                : Dir;

            string filePath = System.IO.Path.Combine(baseDir, Path);

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Trim().Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 && int.TryParse(parts[0], out int techId))
                    
                {
                    technicians.Add(new Technician
                    {
                        TechID = techId,
                        Name = parts[1].Trim()
                    });
                }
            }

            return technicians;
        }
    }
}