namespace backend.Model
{
    public class LoginRequest
    {
        public string Documento { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
    }
}
