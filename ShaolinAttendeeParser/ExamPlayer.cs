using CsvHelper.Configuration.Attributes;

namespace ShaolinAttendeeParser
{
    internal class ExamPlayer
    {
        [Name("Short GamerTag")]
        public string Name { get; set; }

        [Index(42)]
        public string Rank { get; set; }

        [Index(43)]
        public string IsFirstTournament { get; set; }

        [Index(44)]
        public string Goals { get; set; }
    }
}
