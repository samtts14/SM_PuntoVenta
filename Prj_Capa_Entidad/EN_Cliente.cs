using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cliente
    {
        private string _idcliente;
        private string _razonsocial;
        private string _cedula;
        private string _direccion;
        private string _telefono;
        private string _email;
        private int _Ididis;
        private DateTime _fechaaniver;
        private string _contacto;
        private double _LimiteCredito;

        public double LimiteCredito { get => _LimiteCredito; set => _LimiteCredito = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public DateTime Fechaaniver { get => _fechaaniver; set => _fechaaniver = value; }
        public int Ididis { get => _Ididis; set => _Ididis = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Razonsocial { get => _razonsocial; set => _razonsocial = value; }
        public string Idcliente { get => _idcliente; set => _idcliente = value; }
    }
}
