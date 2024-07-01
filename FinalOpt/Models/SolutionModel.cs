namespace FinalOpt.Models
{
    public class SolutionModel
    {
        public List<List<Timetable>> timetable { get; set; }

        public List<Class> classes { get; set; }
        public List<DDuration> dduration { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class DDuration
    {
        public int DayDuration { get; set; }
    }

    public class Class
    {
        public string ClassName { get; set; }
    }

    public class Timetable
    {
        public int hour { get; set; }
        public string className { get; set; }
        public string teacher { get; set; }

        public string discipline { get; set; }

        public string room { get; set; }

        public int? id { get; set; }

        public int? repetition { get; set; }
    }
}
