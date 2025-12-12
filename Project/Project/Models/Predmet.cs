namespace Project.Models
{
    public class Predmet
    {
        public int PredmetId { get; set; }
        public string Naziv {  get; set; } = string.Empty;
        public int SmerId { get; set; }
        public Smer Smer { get; set; } = new Smer();
        public List<StudentiPredmeti> StudentiPredmeti { get; set; } = new List<StudentiPredmeti>();
        public List<ProfesoriPredmeti> ProfesoriPredmeti { get; set; }=new List<ProfesoriPredmeti>();
        
    }
}
