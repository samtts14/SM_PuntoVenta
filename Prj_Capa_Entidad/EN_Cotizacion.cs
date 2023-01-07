using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Cotizacion
    {
        private string _idCotiza;
        private string _IdPedido;
        private DateTime _FechaCoti;
        private int _Vigencia;
        private double _TotalCoti;
        private string _condiciones;
        private double _igv;
        private string _precioCon_igv;
        private string _estadoCoti;

        public string EstadoCoti { get => _estadoCoti; set => _estadoCoti = value; }
        public string PrecioCon_igv { get => _precioCon_igv; set => _precioCon_igv = value; }
        public double Igv { get => _igv; set => _igv = value; }
        public string Condiciones { get => _condiciones; set => _condiciones = value; }
        public double TotalCoti { get => _TotalCoti; set => _TotalCoti = value; }
        public int Vigencia { get => _Vigencia; set => _Vigencia = value; }
        public DateTime FechaCoti { get => _FechaCoti; set => _FechaCoti = value; }
        public string IdPedido { get => _IdPedido; set => _IdPedido = value; }
        public string IdCotiza { get => _idCotiza; set => _idCotiza = value; }
    }
}
