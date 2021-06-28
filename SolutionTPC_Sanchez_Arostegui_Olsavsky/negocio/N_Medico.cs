﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using dataAccess;

namespace negocio
{
    public class N_Medico
    {
        

        public List<Medico> Listar()
        {
            List<Medico>  Lista = new List<Medico>();
            DataAcces Datos = new DataAcces();

            try
            {
                string Select = " SELECT M.ID, M.Apellido, M.Nombre, M.FechaNacimiento, M.Domicilio, M.Celular, M.Genero, M.Matricula, U.Email, U.Estado, E.Especialidad ";
                string From = " FROM Medicos M ";
                string JoinU = " inner join Usuarios U on M.IDUsuario = U.ID ";
                string JoinE = " inner join Especialidades E on E.ID = M.IDEspecialidad ";
                string Where = " where U.Estado = 1 ";
                string query = Select + From + JoinU + JoinE + Where;

                Datos.setearConsulta(query);
                Datos.ejecutarLectura();

                while(Datos.Lector.Read())
                {
                    Medico medico = new Medico();

                    medico.ID = (int)Datos.Lector["ID"];
                    medico.Apellido = (string)Datos.Lector["Apellido"];
                    medico.Nombre = (string)Datos.Lector["Nombre"];
                    medico.FechaNacimiento = (DateTime)Datos.Lector["FechaNacimiento"];
                    medico.Domicilio = (string)Datos.Lector["Domicilio"];
                    medico.Celular = (string)Datos.Lector["Celular"];
                    medico.Genero = (string)Datos.Lector["Genero"];
                    medico.Matricula = (string)Datos.Lector["Matricula"];
                    medico.Usuario.Email = (string)Datos.Lector["Email"];
                    medico.Especialidad = (string)Datos.Lector["Especialidad"];

                    //medico.Usuario.ID = (int)Datos.Lector["IDUsuario"];
                    //medico.Usuario = new Usuario((int)Datos.Lector["U.ID"], (string)Datos.Lector["Usuario"]);
                    //medico.Usuario.Email = (string)Datos.Lector["Email"];
                    //medico.Usuario.Contrasena = (string)Datos.Lector["Contrasena"];

                    Lista.Add(medico);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        //public void Modificar(Medico medico)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {   /*Arreglar el seteo con los nuevos tipos de datos*/
        //        Datos.setearConsulta("update Medicos set Nombre = @Nombre, Apellido = @Apellido, Domicilio = @Domicilio, EMail = @EMail, Contrasena = @Contrasena, Celular = @Celular, Especialidad = @Especialidad, Matricula = @Matricula where ID = @ID");

        //        //Agregar dentro del formulario correspondiente los datos que vienen del médico especifico
        //        Datos.setearParametro("@ID", medico.ID);
        //        Datos.setearParametro("@Apellido", medico.Apellido);
        //        Datos.setearParametro("@Celular", medico.Celular);
        //        Datos.setearParametro("@Domicilio", medico.Domicilio);
        //        Datos.setearParametro("@Email", medico.Email);
        //        Datos.setearParametro("@Especialidad", medico.Especialidad);
        //        Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
        //        Datos.setearParametro("@Matricula", medico.Matricula);
        //        Datos.setearParametro("@Nombre", medico.Nombre);

        //        Datos.EjecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Datos.cerrarConexion();
        //    }
        //}


        //public void Cargar(Medico medico)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {
        //        Datos.setearConsulta("insert into Medicos (ID, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Celular, Genero, Matricula, Especialidad, Estado) values (@ID, @Nombre, @Apellido, @FechaNacimiento, @Domicilio, @EMail, @Contrasena, @Celular, @Celular, @Genero, @Matricula, @Especialidad, @Estado)");

        //        Datos.setearParametro("@Apellido", medico.Apellido);
        //        Datos.setearParametro("@Celular", medico.Celular);
        //        Datos.setearParametro("@Domicilio", medico.Domicilio);
        //        Datos.setearParametro("@Email", medico.Email);
        //        Datos.setearParametro("@Especialidad", medico.Especialidad);
        //        Datos.setearParametro("@Estado", medico.Estado);
        //        Datos.setearParametro("@FechaNacimiento", medico.FechaNacimiento);
        //        Datos.setearParametro("@Genero", medico.Genero);
        //        Datos.setearParametro("@ID", medico.ID);
        //        Datos.setearParametro("@Matricula", medico.Matricula);
        //        Datos.setearParametro("@Nombre", medico.Nombre);

        //        Datos.EjecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Datos.cerrarConexion();
        //    }
        //}

        //public void Eliminar(int ID)
        //{
        //    Datos = new DataAcces();
        //    try
        //    {
        //        Datos.setearConsulta("update Medicos set Estado = @Estado where ID = @ID");

        //        Datos.setearParametro("@ID", ID);
        //        Datos.setearParametro("@Estado", false);

        //        Datos.EjecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        Datos.cerrarConexion();
        //    }
        //}
    }
}
