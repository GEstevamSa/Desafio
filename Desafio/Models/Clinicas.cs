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
        public int ClinicaID { get; set; }

        [ForeignKey("medicos")]
        public int IDMedico { get; set; }
        
        public Medico medicos { get; set; }

        public string NomeClinica { get; set; }
    }
}