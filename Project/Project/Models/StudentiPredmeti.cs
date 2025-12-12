namespace Project.Models
{
    public class StudentiPredmeti
    {
        public int StudentPredmetId { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public Student Student { get; set; }=new Student();
        public Predmet Predmet { get; set; } = new Predmet();
    }
}
