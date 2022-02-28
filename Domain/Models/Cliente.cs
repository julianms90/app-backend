using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string NombreCompleto { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Identificacion { get; set; }
        public int Edad { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Genero { get; set; }
        public bool Estado { get; set; }
        public bool Maneja { get; set; }
        public bool UsaLentes { get; set; }
        public bool Diabetico { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Enfermedad { get; set; }
        public List<DatosAdicionales> DatosAdicionales { get; set; }
    }
}
