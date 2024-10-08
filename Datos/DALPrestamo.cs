﻿using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace DAL
{
    public class DALPrestamo
    {
        public Respuesta RegistrarPrestamo(EntidadPréstamo prestamo)
        {
            //Conexion de la BD
            SqlConnection SqlCon = new SqlConnection();
   
            try
            {
                //Se establece la conexion a la BD
                SqlCon = ConexionBaseDatos.GetInstancia().CrearConexion();

                //Se indica el SP a usar y el tipo de comando
                SqlCommand comando = new SqlCommand("usp_registrar_préstamo", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                //Paramentros
                //metodo get
                comando.Parameters.Add("@id_técnico", SqlDbType.Int).Value = prestamo.IdTécnico;
                comando.Parameters.Add("@id_prestatario", SqlDbType.Int).Value = prestamo.IdPrestatario;
                comando.Parameters.Add("@fecha_creación", SqlDbType.DateTime).Value = prestamo.FechaCreación;
                comando.Parameters.Add("@fecha_devolución", SqlDbType.DateTime).Value = prestamo.FechaDevolución;

                //Se abre la conexion con la BD
                SqlCon.Open();

                //Si la ejecucion del comando es 1 indica que se guardo el dato, sino no
                return comando.ExecuteNonQuery() == 1 ? new Respuesta(0, "Operación exitosa.") : new Respuesta(1, "Error al almacenar los datos.");


            }
            catch (Exception ex)
            {
                // Establece el código de error dentro del mensaje como ex.HResult y ex.Message como el mensaje de error.
                return new Respuesta(ex.HResult, ex.Message);
            }
            finally
            {
                //Cierra la conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            


        }


        public Respuesta ListarPrestamo(string cTexto)
        {

            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {

                //Se establece la conexion a la BD
                SqlCon = ConexionBaseDatos.GetInstancia().CrearConexion();

                //Se indica el SP a usar y el tipo de comando
                SqlCommand comando = new SqlCommand("usp_listar_préstamo", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                //Paramentros
                comando.Parameters.Add("@criterio_busqueda", SqlDbType.NVarChar).Value = cTexto;

                //Se abre la conexion con la BD
                SqlCon.Open();

                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);

                return new Respuesta(0, Tabla);


            }
            catch (Exception ex)
            {
                // Establece el código de error dentro del mensaje como ex.HResult y ex.Message como el mensaje de error.
                return new Respuesta(ex.HResult, ex.Message);
            }
            finally
            {
                //Cierra la conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public Respuesta ListarPrestamoEspecifico(int Id)
        {

            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();

            try
            {

                //Se establece la conexion a la BD
                SqlCon = ConexionBaseDatos.GetInstancia().CrearConexion();

                //Se indica el SP a usar y el tipo de comando
                SqlCommand comando = new SqlCommand("usp_listar_préstamo_especifico", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                //Paramentros

                comando.Parameters.Add("@id", SqlDbType.Int).Value = Id;

                //Se abre la conexion con la BD
                SqlCon.Open();

                Resultado = comando.ExecuteReader();
                Tabla.Load(Resultado);

                return new Respuesta(0, Tabla);


            }
            catch (Exception ex)
            {
                // Establece el código de error dentro del mensaje como ex.HResult y ex.Message como el mensaje de error.
                return new Respuesta(ex.HResult, ex.Message);
            }
            finally
            {
                //Cierra la conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }


        public Respuesta EliminarPréstamo(int IdPréstamo)
        {

            //Conexion de la BD
            SqlConnection SqlCon = new SqlConnection();

            try
            {

                //Se establece la conexion a la BD
                SqlCon = ConexionBaseDatos.GetInstancia().CrearConexion();

                //Se indica el SP a usar y el tipo de comando
                SqlCommand comando = new SqlCommand("usp_eliminar_préstamo", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                //Paramentros
                comando.Parameters.Add("@id", SqlDbType.Int).Value = IdPréstamo;

                //Se abre la conexion con la BD
                SqlCon.Open();

                return comando.ExecuteNonQuery() == 1 ? new Respuesta(0, "Operación exitosa.") : new Respuesta(1, "Error al almacenar los datos.");

            }
            catch (Exception ex)
            {
                // Establece el código de error dentro del mensaje como ex.HResult y ex.Message como el mensaje de error.
                return new Respuesta(ex.HResult, ex.Message);
            }
            finally
            {
                //Cierra la conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            
        }
        public Respuesta ActualizarPrestamo(EntidadPréstamo préstamo)
        {

            //Conexion de la BD
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                //Se establece la conexion a la BD
                SqlCon = ConexionBaseDatos.GetInstancia().CrearConexion();

                //Se indica el SP a usar y el tipo de comando
                SqlCommand comando = new SqlCommand("usp_actualizar_préstamo", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                //Paramentros
                //metodo get
                comando.Parameters.Add("@id_préstamo", SqlDbType.Int).Value = préstamo.IdPréstamo;
                comando.Parameters.Add("@id_técnico", SqlDbType.Int).Value = préstamo.IdTécnico;
                comando.Parameters.Add("@id_prestatario", SqlDbType.Int).Value = préstamo.IdPrestatario;
                comando.Parameters.Add("@id_estado_préstamo", SqlDbType.Int).Value = préstamo.IdEstadoCreación;
                comando.Parameters.Add("@fecha_devolución", SqlDbType.NVarChar).Value = préstamo.FechaDevolución;

                //Se abre la conexion con la BD
                SqlCon.Open();

                //Si la ejecucion del comando es 1 indica que se guardo el dato, sino no
                return comando.ExecuteNonQuery() == 1 ? new Respuesta(0, "Operación exitosa.") : new Respuesta(1, "Error al almacenar los datos.");


            }
            catch (Exception ex)
            {
                // Establece el código de error dentro del mensaje como ex.HResult y ex.Message como el mensaje de error.
                return new Respuesta(ex.HResult, ex.Message);
            }
            finally
            {
                //Cierra la conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            


        }
    }
}
