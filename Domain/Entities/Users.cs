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
    [Table("users")]
    public class Users
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario { get; set; }
        
        public string nombre { get; set; } = string.Empty;
        public string? telefono { get; set; }
        public string? direccion { get; set;}
        [ForeignKey("Municipio")]
        public int idmunicipio { get; set; }    
       
        [ForeignKey("idmunicipio")]
        public Municipio Municipio { get; set; }
        [ForeignKey("Departamento")]
        public int iddepartamento { get; set; }
        [ForeignKey("iddepartamento")]
        public Departamento Departamento { get; set; }
        [ForeignKey("Pais")]
        public int idpais { get; set; }
        [ForeignKey("idpais")]
        public Pais Pais { get; set; }

    }
}
