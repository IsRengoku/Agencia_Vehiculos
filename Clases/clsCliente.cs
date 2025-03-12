using System;
using Agencia_Vehiculos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Web;

namespace Agencia_Vehiculos.Clases
{
    public class clsCliente
    {
        private Agencia_VehiculosEntities1 Agencia = new Agencia_VehiculosEntities1();
        public Cliente persona { get; set; }
        public string Insertar()
        {
            try
            {
                Agencia.Clientes.Add(persona);
                Agencia.SaveChanges();
                return "Se ingresó el cliente " + persona.Nombre + " a la base de datos";
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
                Cliente prod = Consultar(persona.Cedula);
                if (prod == null)
                {
                    return "El cliente no existe";
                }
                Agencia.Clientes.AddOrUpdate(persona);
                Agencia.SaveChanges();
                return "Se actualizó el cliente " + persona.Nombre + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Cliente Consultar(string Cedula)
        {
            Cliente prod = Agencia.Clientes.FirstOrDefault(p => p.Cedula == Cedula);
            return prod;
        }
        public List<Cliente> ConsultarTodos()
        {
            return Agencia.Clientes
                .OrderBy(p => p.Nombre)
                .ToList();
        }
        public string Eliminar()
        {
            try
            {
                Cliente prod = Consultar(persona.Cedula);
                if (prod == null)
                {
                    return "El producto no existe";
                }
                Agencia.Clientes.Remove(prod);
                Agencia.SaveChanges();
                return "Se eliminó el cliente " + prod.Nombre + " correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string EliminarXDocumento(string Documento)
        {
            try
            {
                Cliente cli = Consultar(Documento);
                if (cli == null)
                {
                    return "El documento del cliente no es válido";
                }
                Agencia.Clientes.Remove(cli);
                Agencia.SaveChanges();
                return "Se eliminó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}