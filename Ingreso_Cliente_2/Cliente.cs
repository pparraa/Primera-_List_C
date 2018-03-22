using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingreso_Cliente_2
{
    public class Cliente
    {
        private string rut;
        private string nombre;
        private string apellido;
        private DateTime f_nacimiento;
        private Sexo sexo;
        private EstadoCivil estado_civil;
        

        public Cliente(string rut, string nombre, string apellido, DateTime f_nacimiento, Sexo sexo, EstadoCivil estado_civil)
        {
            this.Rut = rut;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.F_nacimiento = f_nacimiento;
            this.sexo = sexo;
            this.estado_civil = estado_civil;
        }

        public Cliente()
        {
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

        public Sexo Sexo
        {
            get
            {
                return sexo;
            }

            set
            {
                sexo = value;
            }
        }

        public EstadoCivil Estado_civil
        {
            get
            {
                return estado_civil;
            }

            set
            {
                estado_civil = value;
            }
        }

       
        
    }
    public enum Sexo
    {
        hombre = 1, mujer
    }
    public enum EstadoCivil
    {
        soltero = 1, casado, divorciado, viudo
    }


}

