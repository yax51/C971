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
        public int TermId { get; set; }
        
    }
    

   
}
