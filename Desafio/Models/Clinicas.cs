using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Desafio.Models
{
    public class Clinicas
    {
        [Key]
        [Required]
        public int ClinicaID { get; set; }

        [ForeignKey("medicos")]
        [Required]
        public int IDMedico { get; set; }
        
        public Medico medicos { get; set; }

        public string NomeClinica { get; set; }
        public int Estrelas { get; set; }
        public string NomeSecretaria { get; set; }
        public string Endereco { get; set; }
    }
}