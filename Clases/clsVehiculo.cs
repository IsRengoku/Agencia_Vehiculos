using Agencia_Vehiculos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Agencia_Vehiculos.Clases
{
    public class clsVehiculo
    {
        private Agencia_VehiculosEntities1 Agencia = new Agencia_VehiculosEntities1();
        public Vehiculo carro { get; set; }
        public string Insertar()
        {
            try
            {
                Agencia.Vehiculos.Add(carro);
                Agencia.SaveChanges();
                return "Se ingresó el vehiculo " + carro.Id_vehiculo + " a la base de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                Vehiculo prod = Consultar(carro.Id_vehiculo);
                if (prod == null)
                {
                    return "El vehiculo no existe";
                }
                Agencia.Vehiculos.AddOrUpdate(carro);
                Agencia.SaveChanges();
                return "Se actualizó el vehiculo " + carro.Id_vehiculo + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Vehiculo Consultar(int Id)
        {
            Vehiculo prod = Agencia.Vehiculos.FirstOrDefault(p => p.Id_vehiculo == Id);
            return prod;
        }
        public List<Vehiculo> ConsultarTodos()
        {
            return Agencia.Vehiculos
                .OrderBy(p => p.Marca)
                .ToList();
        }
        public List<Vehiculo> ConsultarXPrecio(int precio)
        {
            return Agencia.Vehiculos
                .Where(p => p.Precio_vehiculo == precio)
                .OrderBy(p => p.Marca)
                .ToList();
        }
        public string Eliminar()
        {
            try
            {
                Vehiculo prod = Consultar(carro.Id_vehiculo);
                if (prod == null)
                {
                    return "El vehiculo no existe";
                }
                Agencia.Vehiculos.Remove(prod);
                Agencia.SaveChanges();
                return "Se eliminó el vehiculo " + prod.Id_vehiculo + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EliminarXId(int Id)
        {
            try
            {
                Vehiculo car = Consultar(Id);
                if (car == null)
                {
                    return "El id del vehiculo no es válido";
                }
                Agencia.Vehiculos.Remove(car);
                Agencia.SaveChanges();
                return "Se eliminó el vehiculo correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}