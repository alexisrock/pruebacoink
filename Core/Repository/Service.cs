using AutoMapper;
using DataAccess.Interfaces;
using Domain.Common;
using Domain.DTO;
using Domain.Entities;
using MediatR;

namespace Core.Repository
{
    public class Service : IRequestHandler<UsuarioRequest, BaseResponse>
        , IRequestHandler<UserUpdateRequest, BaseResponse>
        , IRequestHandler<UserDeleteRequest, BaseResponse>
    {

        private readonly IDataAccess<Users> repository;
        private readonly IDataAccess<Pais> repositoryPais;        
        private readonly IDataAccess<Departamento> repositoryDepartamento;
        private readonly IDataAccess<Municipio> repositoryMunicipio;





        private readonly IMapper mapper;

        public Service(IDataAccess<Users> repository, IMapper mapper, IDataAccess<Pais> repositoryPais, IDataAccess<Departamento> repositoryDepartamento, IDataAccess<Municipio> repositoryMunicipio)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repositoryPais = repositoryPais;
            this.repositoryDepartamento = repositoryDepartamento;
            this.repositoryMunicipio = repositoryMunicipio;
        }

        public async Task<BaseResponse> Handle(UsuarioRequest request, CancellationToken cancellationToken)
        {

            var outPut = new BaseResponse();

            try
            {
                if (request is null )
                {
                    outPut.Mensaje = "Error en el request";
                    return outPut;
                }

                var resMuni = await ValideMunicipio(request.IdMunicipio);
                var resDepa = await ValideDepartamento(request.IdDepartamento);
                var resPa = await ValidePais(request.IdPais);              


                if (resMuni && resDepa && resPa)
                {
                    var user = mapper.Map<Users>(request);
                    await repository.Insert(user);
                    outPut.Mensaje = "Usuario creado con éxito";
                    return outPut;
                }

                outPut.Mensaje = "Existen parametros no validos";
                return outPut;
            }
            catch (Exception ex)
            {

                outPut.Mensaje = ex.Message;
            }

            return outPut;
        }
        
        public async Task<BaseResponse> Handle(UserUpdateRequest request, CancellationToken cancellationToken)
        {
            var outPut = new BaseResponse();
            try
            {
                if (request is not null)
                {

                    var user = await repository.GetByIdOthers(request.Id_usuario);
                    user.telefono = request.Telefono;
                    user.nombre = request.Nombre;
                    user.idmunicipio = request.IdMunicipio;
                    user.iddepartamento = request.IdDepartamento;
                    user.idpais = request.Idpais;


                    user.direccion = request.Direccion;
                    await repository.Update(user);
                    outPut.Mensaje = "Usuario actualizada con éxito";
                    return outPut;
                }
                outPut.Mensaje = "Error en el request";

            }
            catch (Exception ex)
            {

                outPut.Mensaje = ex.Message;
            }

            return outPut;
        }

        public async Task<BaseResponse> Handle(UserDeleteRequest request, CancellationToken cancellationToken)
        {

            var outPut = new BaseResponse();

            if (request.Id_usuario > 0)
            {

                var user = await repository.GetByIdOthers(request.Id_usuario);
                await repository.Delete(user);
                outPut.Mensaje = "Usuario eliminado con éxito";
            }
            else
            {
                outPut.Mensaje = "Error en el request";
            }

            return outPut;
        }


        private async Task<bool> ValideMunicipio(int id)
        {
            return await this.repositoryMunicipio.GetByIdOthers(id) is not null;
        }

        private async Task<bool> ValideDepartamento(int id)
        {
            return await this.repositoryDepartamento.GetByIdOthers(id) is not null;
        }

        private async Task<bool> ValidePais(int id)
        {
            return await this.repositoryPais.GetByIdOthers(id) is not null;
        }




    }
}
