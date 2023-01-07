using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_IngresoCompra
    {
        
        private string _idcompra;
        private string _Nro_Fac_Fisico;
        private string _idproveedor;
        private Double _subtotal;
        private DateTime _fechaIngreso;
        private double _Totalcompra;
        private int _idusu;
        private string _modali_Pago;
        private int _TiempoEspera;
        private DateTime _FechaVence;
        private string _EstadoIngreso;
        private bool _RecibiConforme;
        private string _Datos_Adicional;
        private string _TipoDoc_Compra;

        public string TipoDoc_Compra { get => _TipoDoc_Compra; set => _TipoDoc_Compra = value; }
        public string Datos_Adicional { get => _Datos_Adicional; set => _Datos_Adicional = value; }
        public bool RecibiConforme { get => _RecibiConforme; set => _RecibiConforme = value; }
        public string EstadoIngreso { get => _EstadoIngreso; set => _EstadoIngreso = value; }
        public DateTime FechaVence { get => _FechaVence; set => _FechaVence = value; }
        public int TiempoEspera { get => _TiempoEspera; set => _TiempoEspera = value; }
        public string Modali_Pago { get => _modali_Pago; set => _modali_Pago = value; }
        public int Idusu { get => _idusu; set => _idusu = value; }
        public double Totalcompra { get => _Totalcompra; set => _Totalcompra = value; }
        public DateTime FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public double Subtotal { get => _subtotal; set => _subtotal = value; }
        public string Idproveedor { get => _idproveedor; set => _idproveedor = value; }
        public string Nro_Fac_Fisico { get => _Nro_Fac_Fisico; set => _Nro_Fac_Fisico = value; }
        public string Idcompra { get => _idcompra; set => _idcompra = value; }
    }
}
