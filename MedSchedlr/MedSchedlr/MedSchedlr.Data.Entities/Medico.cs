namespace MedSchedlr.Data.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string Especialidade { get; set; }
        public Consultorio Consultorio { get; set; }
        public int CRM { get; set; }        
    }
}
