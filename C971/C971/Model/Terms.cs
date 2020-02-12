using SQLite;
using System;




namespace C971.Model
{
    public class Terms
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TermName { get; set; } 
        public string TermStatus { get; set; } 
        public DateTime TProjStart { get; set; }
        public DateTime TProjEnd { get; set; } 
        public DateTime TActStart { get; set; } 
        public DateTime TActEnd { get; set; } 
        
       


    }

    





}
