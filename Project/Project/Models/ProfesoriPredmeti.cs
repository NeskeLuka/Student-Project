namespace Project.Models
{
    public class ProfesoriPredmeti
    {
        public int ProfesorPredmetId {  get; set; }
        public int PredmetId { get; set; }  
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }=new Profesor();
        public Predmet Predmet { get; set; }= new Predmet();
    }
}
