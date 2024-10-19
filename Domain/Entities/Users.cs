using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Users")]
    public class Users
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_usuario { get; set; }
        
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Direccion { get; set;}
        [ForeignKey("Municipio")]
        public int IdMunicipio { get; set; }    
       
        [ForeignKey("IdMunicipio")]
        public Municipio Municipio { get; set; }
        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public Departamento Departamento { get; set; }
        [ForeignKey("Pais")]
        public int Idpais { get; set; }
        [ForeignKey("Idpais")]
        public Pais Pais { get; set; }

    }
}
