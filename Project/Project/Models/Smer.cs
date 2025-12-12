namespace Project.Models
{
    public class Smer
    {
        public int SmerId { get; set; }
        public string SmerName { get; set; }= string.Empty;
        public List<Student> Studenti { get; set; }= new List<Student>();
        public List<Predmet> Predmeti { get; set; }= new List<Predmet>();
    }
}
