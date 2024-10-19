using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("municipio")]
    public class Municipio
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
      
        public string? nombre { get; set; }
        [ForeignKey("Departamento")]
        public int iddepartamento { get; set; }
        [ForeignKey("iddepartamento")]
        public Departamento? Departamento { get; set; }

}
}
