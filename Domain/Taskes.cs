using System;

namespace Domain
{
    public class Taskes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime SLA { get; set; }
        public string Filename { get; set; }
        public string Status { get; set; }
    
    }
}