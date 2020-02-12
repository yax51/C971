using SQLite;
using System;
using System.ComponentModel;

namespace C971.Model
{
    public class Courses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CourseName { get; set; }
        public string CourseStatus { get; set; }
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }
        public string InstructName { get; set; }
        public string InstructEmail { get; set; }
        public string InstructPhone { get; set; }
        public string Notes { get; set; }
        public string CObjName { get; set; }
        public DateTime CObjStart { get; set; }
        public DateTime CObjEnd { get; set; }
        public string CPerName { get; set; }
        public DateTime CPerStart { get; set; }
        public DateTime CPerEnd { get; set; }
        
    }
    

   
}
