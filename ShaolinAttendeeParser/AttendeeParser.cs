using CsvHelper;
using System.Globalization;
using System.Management.Automation;

namespace ShaolinAttendeeParser
{
    [Cmdlet(VerbsData.Export, "ShaolinExamPlayers")]
    public class AttendeeParser : PSCmdlet
    {
        private string outputFile;

        [Parameter(Position = 0)]
        public string InputFilepath { get; set; }

        protected override void BeginProcessing()
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var monthYear = DateTime.Now.ToString("MMMM yyyy");

            outputFile = Path.Combine(desktopPath, $"Shaolin Exam - {monthYear}.csv");
        }

        protected override void ProcessRecord()
        {
            using var reader = new StreamReader(InputFilepath);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csvReader.GetRecords<ExamPlayer>();

            using var writer = new StreamWriter(outputFile);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(records);
        }
    }
}
