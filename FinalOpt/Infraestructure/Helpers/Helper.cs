using FinalOpt.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Reflection;
using System.Text;

namespace FinalOpt.Infraestructure.Helpers
{
    public static class Helper
    {
        public static string EncodeToBase64(string content)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            return Convert.ToBase64String(bytes);
        }

        public static string FromBase64(string content)
        {
            byte[] data = Convert.FromBase64String(content);
            string decodedContent = Encoding.UTF8.GetString(data);

            return decodedContent;
        }

        public static Dictionary<string, List<string>> FromIbmDat(string str)
        {
            var content = FromBase64(str);
            // Dividir el contenido en pares clave-valor
            var pairs = content.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var dictionary = new Dictionary<string, List<string>>();

            foreach (var pair in pairs)
            {
                var parts = pair.Split(new[] { '=' }, 2); // Dividir en clave y valor por el primer '='
                if (parts.Length < 2) continue;

                var key = parts[0].Trim();
                var value = parts[1].Replace("{", "")
                         .Replace("}", "")
                         .Replace("<", "")
                         .Replace(">", "")
                         .Replace("\"", "")
                         .Trim();

                var valuesList = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(v => v.Trim())
                                      .ToList();

                if (key == "RequirementSet")
                {
                    valuesList = SplitIntoGroupsOfFour(valuesList);
                }

                dictionary.Add(key, valuesList);
            }

            return dictionary;
        }

        private static List<string> SplitIntoGroupsOfFour(List<string> input)
        {
            var result = new List<string>();
            for (int i = 0; i < input.Count; i += 4)
            {
                var group = input.Skip(i).Take(4).Select(x => x.Trim());
                result.Add(string.Join(" ", group));
            }
            return result;
        }

        public static string ObjectToDat(DataToRunModel data)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(FixedFields);

            sb.Append("TeacherDisciplineSet = {");
            foreach (var item in data.TeacherDisciplineSet)
            {
                sb.AppendFormat("<\"{0}\",\"{1}\">,", item.TeacherName, item.Discipline);
            }
            sb.Length--;
            sb.AppendLine("};");

            sb.Append("Room = {");
            foreach (var room in data.Rooms)
            {
                sb.AppendFormat("\"{0}\", ", room);
            }
            sb.Length -= 2;
            sb.AppendLine("};");

            sb.Append("DedicatedRoomSet = {");
            foreach (var item in data.DedicatedRoomSet)
            {
                sb.AppendFormat("<\"{0}\",\"{1}\">,", item.Room, item.Discipline);
            }
            sb.Length--;
            sb.AppendLine("};");

            sb.AppendFormat("MorningDiscipline = {{\"{0}\"}};", data.MorningDiscipline);
            sb.AppendLine();

            sb.Append("RequirementSet = {");
            foreach (var item in data.Requirements)
            {
                sb.AppendFormat("<\"{0}\",\"{1}\",{2},{3}>,", item.Course, item.Discipline, item.DailyHours, item.WeeklyDays);
            }
            sb.Length--;
            sb.AppendLine("};");


            return sb.ToString();
        }

        public static string FixedFields = "BreakDuration = 1;\r\nDayDuration = 8;\r\nNumberOfDaysPerPeriod = 5;\r\nNeedBreak = {};";
    }
}
