using FinalOpt.Models.AggregateValues;

namespace FinalOpt.Models
{
    public class DataToRunModel
    {
        public List<TeacherDisciplineSet>? TeacherDisciplineSet { get; set; }
        public List<string>? Rooms { get; set; }
        public List<DedicatedRoomSet>? DedicatedRoomSet { get; set; }
        public string? MorningDiscipline { get; set; }
        public List<RequirementSet>? Requirements {  get; set; }
        public bool RunExample { get; set; }
    }
}
