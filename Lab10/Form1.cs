using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        private readonly TechnicianDB _technicianDb = new TechnicianDB();
        private readonly IncidentDB _incidentDb = new IncidentDB();

        public Form1()
        {
            InitializeComponent();
            Text = "Incidents by Technician";
            lstIncidents.Font = new Font("Consolas", 10F);
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayClosedIncidents();
        }

        private void DisplayClosedIncidents()
        {
            var technicians = _technicianDb.GetTechnicians();
            var incidents = _incidentDb.GetIncidents();

            var closedIncidentsQuery =
                from inc in incidents
                join tech in technicians on inc.TechID equals tech.TechID
                where inc.DateClosed != null
                orderby tech.Name, inc.DateOpened
                select new
                {
                    TechnicianName = tech.Name,
                    Product = inc.ProductCode,
                    DateOpened = inc.DateOpened.ToShortDateString(),
                    DateClosed = inc.DateClosed.Value.ToShortDateString(),
                    Title = inc.Title
                };

            var rows = closedIncidentsQuery.ToList();

            lstIncidents.Items.Clear();

            string header =
                "Technician".PadRight(18) +
                "Product".PadRight(11) +
                "Date Opened".PadRight(14) +
                "Date Closed".PadRight(14) +
                "Title";
            lstIncidents.Items.Add(header);

            string previousTech = null;

            foreach (var row in rows)
            {
                string techColumn = row.TechnicianName != previousTech
                    ? row.TechnicianName
                    : string.Empty;

                previousTech = row.TechnicianName;

                string line =
                    techColumn.PadRight(18) +
                    row.Product.PadRight(11) +
                    row.DateOpened.PadRight(14) +
                    row.DateClosed.PadRight(14) +
                    row.Title;

                lstIncidents.Items.Add(line);
            }
        }
    }
}