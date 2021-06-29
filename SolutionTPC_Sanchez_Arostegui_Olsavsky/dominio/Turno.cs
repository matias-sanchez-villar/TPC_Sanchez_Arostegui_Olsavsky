﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Turno
    {
        public int ID { get; set; }
        public Medico medico { get; set; }
        public Paciente paciente { get; set; }
        public DateTime FechaHora { get; set; }
        public bool Estado { get; set; }

        public Turno()
        {
            Estado = true;

            medico = new Medico();

            paciente = new Paciente();
        }
    }
}
