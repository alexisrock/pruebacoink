using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserDeleteRequest : IRequest<BaseResponse>
    {
        public int Id_usuario { get; set; }
    }
}
