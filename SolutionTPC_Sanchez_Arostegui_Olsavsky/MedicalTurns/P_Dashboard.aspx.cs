﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.Data.SqlClient;

namespace MedicalTurns
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public List<Medico> listaMedicos;
        public List<Paciente> listaPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ///Listamos a medico
                N_Medico medicoNegocio = new N_Medico();
                listaMedicos = medicoNegocio.Listar();

                Session.Add("Medicos", listaMedicos);


                ///Listamos Paciente
                N_Paciente paciente = new N_Paciente();
                listaPaciente = paciente.Listar();

                Session.Add("Paciente", listaPaciente);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //Response.Redirect("Dashboard.aspx");
            }
        }

    }
}