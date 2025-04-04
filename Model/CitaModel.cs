﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Model
{
    public class Cita
    {
        public int Id { get; set; }
        public string Especialidad { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = "Disponible";

        [ForeignKey("Medico")]
        public int IdMedico { get; set; }

        public Medico Medico { get; set; }


    }
}
