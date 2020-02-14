using SQLite;
using System;

namespace C971.Model
{
    public class Assessments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ObjAssessName { get; set; }
        public string PerAssessName { get; set; }
        public string AssessType { get; set; }
        public string AssessCourse { get; set; }
        public DateTime CObjStart { get; set; }
        public DateTime CObjEnd { get; set; }
        public DateTime CPerStart { get; set; }
        public DateTime CPerEnd { get; set; }
    }
}
