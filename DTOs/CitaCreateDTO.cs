namespace backend.DTOs
{
    public class CitaCreateDTO
    {
        public string Especialidad { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = "Disponible";
        public int IdMedico { get; set; }
    }
}
