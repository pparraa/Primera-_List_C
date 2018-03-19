using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingreso_Cliente_2
{
    public class Cliente
    {
        private string apellido;
        private DateTime f_nacimiento;
        private Sexo s;
        private EstadoCivil e;
        private string rut;
        private string nombre;

        public Cliente(string rut, string nombre, string apellido, DateTime f_nacimiento, Sexo s, EstadoCivil e)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.F_nacimiento = f_nacimiento;
            this.S = s;
            this.E = e;
        }

        public Cliente()
        {
        }
        public enum Sexo
        {
            hombre = 1, mujer
        }
        public enum EstadoCivil
        {
            soltero = 1, casado, divorciado, viudo
        }


        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public DateTime F_nacimiento
        {
            get
            {
                return f_nacimiento;
            }

            set
            {
                f_nacimiento = value;
            }
        }

        public Sexo S
        {
            get
            {
                return s;
            }

            set
            {
                s = value;
            }
        }

        public EstadoCivil E
        {
            get
            {
                return e;
            }

            set
            {
                e = value;
            }
        }

       
        
    }


}

