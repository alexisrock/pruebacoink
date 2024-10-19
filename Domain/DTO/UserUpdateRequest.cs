using Domain.Common;
using MediatR;


namespace Domain.DTO
{
    public class UserUpdateRequest : IRequest<BaseResponse>
    {
        public int Id_usuario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public int IdDepartamento { get; set; }
        public int Idpais { get; set; }
        public int IdMunicipio { get; set; }
    }
}
