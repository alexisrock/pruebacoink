using Core.Interfaces;
using Moq;
using Domain.DTO;
using ApiOLSoftwareRest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using MediatR;
using AutoMapper;
using Core.Repository;
using DataAccess.Interfaces;
using Domain.Entities;



namespace Tests.Presentacion
{
    public class UsuarioControllerTest
    {

        private readonly Mock<ISender> _pruebaSeleccionServiceMock;

        private readonly Mock<IUserService> _userService;
        private readonly UsuarioController _controller;

        private readonly Mock<IDataAccess<Users>> _repositoryMock;
        private readonly Mock<IDataAccess<Pais>> _repositoryPaisMock;
        private readonly Mock<IDataAccess<Departamento>> _repositoryDepartamentoMock;
        private readonly Mock<IDataAccess<Municipio>> _repositoryMunicipioMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Service _service;

        public UsuarioControllerTest()
        {
            _pruebaSeleccionServiceMock = new Mock<ISender>();
            _userService = new Mock<IUserService>();
            _controller = new UsuarioController(_pruebaSeleccionServiceMock.Object, _userService.Object);


            _repositoryMock = new Mock<IDataAccess<Users>>();
            _repositoryPaisMock = new Mock<IDataAccess<Pais>>();
            _repositoryDepartamentoMock = new Mock<IDataAccess<Departamento>>();
            _repositoryMunicipioMock = new Mock<IDataAccess<Municipio>>();
            _mapperMock = new Mock<IMapper>();
            _service = new Service(
           _repositoryMock.Object,
           _mapperMock.Object,
           _repositoryPaisMock.Object,
           _repositoryDepartamentoMock.Object,
           _repositoryMunicipioMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllUsers()
        {
            var list = new List<UsuarioResponse>() {new UsuarioResponse {   Nombre = "andres", Direccion = "calelle 45 no 54", Telefono = "3112002020" , IdMunicipio= 1 },
                new UsuarioResponse {   Nombre = "martha", Direccion = "calelle 45 no 54", Telefono = "6017682475" , IdMunicipio= 1 } };



            _userService.Setup(x => x.GetAll()).ReturnsAsync(list);
            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);           
            Assert.Equal(200, okResult.StatusCode);
            

        }


        [Fact]
        public async Task GetAll_ReturnsProblem_WhenServiceThrowsException()
        {

            _userService.Setup(x => x.GetAll()).ThrowsAsync(new System.Exception());
         

            var result = await _controller.GetAll();

           
            Assert.IsType<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            Assert.Equal(500, objectResult.StatusCode);
        }


        [Fact]
        public async Task GetId_ReturnsOk_WhenServiceReturnsProduct()
        {
            
            var productoMock = new UsuarioResponse { Nombre = "andres", Direccion = "calelle 45 no 54", Telefono = "3112002020", IdMunicipio = 1 };


            _userService.Setup(x => x.GetId(1)).ReturnsAsync(productoMock);

           
            var result = await _controller.GetId(1);

            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(productoMock, okResult.Value);
        }

        [Fact]
        public async Task GetId_ReturnsBadRequest_WhenServiceReturnsNull()
        {

            _userService.Setup(service => service.GetId( 1)).ReturnsAsync((UsuarioResponse)null);

           
            var result = await _controller.GetId(1);

           
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public async Task GetId_ReturnsProblem_WhenServiceThrowsException()
        {

            _userService.Setup(service => service.GetId(1)).ThrowsAsync(new System.Exception());

        
            var result = await _controller.GetId(1);

         
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
        }

      

        [Fact]
        public async Task HandleUsuarioRequest_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var request = new UsuarioRequest { IdMunicipio = 1, IdDepartamento = 1, IdPais = 1 };
            var user = new Users();
            var response = new BaseResponse();

            _mapperMock.Setup(m => m.Map<Users>(It.IsAny<UsuarioRequest>())).Returns(user);
            _repositoryMunicipioMock.Setup(r => r.GetByIdOthers(It.IsAny<int>())).ReturnsAsync(new Municipio());
            _repositoryDepartamentoMock.Setup(r => r.GetByIdOthers(It.IsAny<int>())).ReturnsAsync(new Departamento());
            _repositoryPaisMock.Setup(r => r.GetByIdOthers(It.IsAny<int>())).ReturnsAsync(new Pais());
            _repositoryMock.Setup(r => r.Insert(It.IsAny<Users>())).Returns(Task.CompletedTask);

            // Act
            var result = await _service.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Usuario creado con éxito", result.Mensaje);
        }


    }





}

