﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace MedicalTurns
{
    public partial class A_CargarEspecialidad : System.Web.UI.Page
    {
        public List<Especialidad> lista;

        protected void Page_Load(object sender, EventArgs e)
        {

            N_Especialidad Negocio = new N_Especialidad();
            lista = Negocio.listar();

            Session.Add("Especialidad", lista);

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid) return;

            else
            {
                N_Especialidad Negocio = new N_Especialidad();
                Especialidad especialidad = new Especialidad();

                especialidad.Nombre = Especialidad.Text;

                Negocio.Cargar(especialidad);
                Response.Redirect("A_CargarEspecialidad.aspx");
            }
        }
    }
}