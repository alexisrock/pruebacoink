using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserSp
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public int idmunicipio { get; set; }
        public int idpais { get; set; }
        public int iddepartamento { get; set; }

        

    }
}
