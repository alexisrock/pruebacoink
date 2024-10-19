using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("departamento")]
    public  class Departamento
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }      
        public string? nombre { get; set; }
        [ForeignKey("Pais")]
        public int idpais { get; set; }
        [ForeignKey("idpais")]
        public Pais? Pais { get; set; }


    }
}
