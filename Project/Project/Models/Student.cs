namespace Project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Ime { get; set; } = string.Empty;
        public string Prezime { get; set; } = string.Empty;
        public string JMBG { get; set; } = string.Empty;
        public string Indeks { get; set; } = string.Empty;
        public int SmerId { get; set; }
    }
}
