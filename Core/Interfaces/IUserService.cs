﻿using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public  interface IUserService
    {

        Task<List<UsuarioResponse>> GetAll();
        Task<UsuarioResponse> GetId(int Id);

    }
}
