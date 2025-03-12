using Agencia_Vehiculos.Clases;
using Agencia_Vehiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agencia_Vehiculos.Controllers
{
    [RoutePrefix("api/Vehiculos")]
    public class VehiculosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXId")]
        public Vehiculo ConsultarXId(int Id)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(Id);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Vehiculo> ConsultarTodos()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXPrecio")]
        public List<Vehiculo> ConsultarXMarca(int Precio)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ConsultarXPrecio(Precio);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.carro = vehiculo;
            return Vehiculo.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.carro = vehiculo;
            return Vehiculo.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            Vehiculo.carro = vehiculo;
            return Vehiculo.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(int Id)
        {
            clsVehiculo Vehiculo = new clsVehiculo();
            return Vehiculo.EliminarXId(Id);
        }
    }
}