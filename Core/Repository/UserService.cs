using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class UserService : IUserService
    {

        private readonly IDataAccess<UserSp> repository;

        private readonly IMapper mapper;

        public UserService(IDataAccess<UserSp> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;

        }



        public async Task<List<UsuarioResponse>> GetAll()
        {

            var listPruebaSeleccion = await repository.GetAll();
            var list = MapperListesponse(listPruebaSeleccion);
            return list;


        }
        private List<UsuarioResponse> MapperListesponse(List<UserSp> listPruebaSeleccion)
        {
            List<UsuarioResponse> listResponse = new List<UsuarioResponse>();

            listPruebaSeleccion.ForEach(c =>
            {
                var Response = mapper.Map<UsuarioResponse>(c);
                listResponse.Add(Response);
            });
            return listResponse;
        }
        public async Task<UsuarioResponse> GetId(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var pruebaSeleccion = await repository.GetById(Id);
                    var response = mapper.Map<UsuarioResponse>(pruebaSeleccion);
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
