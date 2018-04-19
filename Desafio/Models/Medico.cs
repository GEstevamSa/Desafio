using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio.Models
{
    public class Medico
    {
        [Key]
        public int MedicoID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public bool Ativo { get; set; }

        public ICollection<Clinicas> clinica { get; set; }
    }
}