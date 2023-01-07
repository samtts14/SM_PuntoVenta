using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Det_Pedido
    {
        private string _idPed;
        private string _IdProd;
        private double _precio;
        private double _cantidad;
        private double _Importe;
        private string _tipoProd;
        private string _Und;
        private double _Utilidad_Unit;
        private double _totalUtilidad;

        public double TotalUtilidad { get => _totalUtilidad; set => _totalUtilidad = value; }
        public double Utilidad_Unit { get => _Utilidad_Unit; set => _Utilidad_Unit = value; }
        public string Und { get => _Und; set => _Und = value; }
        public string TipoProd { get => _tipoProd; set => _tipoProd = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public double Cantidad { get => _cantidad; set => _cantidad = value; }
        public double Precio { get => _precio; set => _precio = value; }
        public string IdProd { get => _IdProd; set => _IdProd = value; }
        public string IdPed { get => _idPed; set => _idPed = value; }
    }
}
