using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Municipio")]
    public class Municipio
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string? Nombre { get; set; }
        [ForeignKey("Departamento")]
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public Departamento? Departamento { get; set; }

}
}
