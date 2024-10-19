using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Departamento")]
    public  class Departamento
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
        public string? Nombre { get; set; }
        [ForeignKey("Pais")]
        public int Idpais { get; set; }
        [ForeignKey("Idpais")]
        public Pais? Pais { get; set; }


    }
}
