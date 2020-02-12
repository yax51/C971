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
        public DateTime ObjAssessStart { get; set; }
        public DateTime ObjAssessEnd { get; set; }
        public DateTime PerAssessStart { get; set; }
        public DateTime PerAssessEnd { get; set; }

    }
}
