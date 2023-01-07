using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Producto
    {
        private string _idprod;
        private string _idproveedor;
        private string _descripcionGeneral;
        private double _frank;
        private double _PreCompra_Sol;
        private double _PreCompra_Dlr;
        private double _stock;
        private int _idcat;
        private int _idmark;
        private string _foto;
        private double _PreVenta_Mnr;
        private double _PreVenta_Myr;
        private double _PreVenta_Dolr;
        private string _UndMedida;
        private double _PesoUnit;
        private double _UtilidadUnity;
        private string _TipoProducto;
        private double _valorGeneral;

        public double ValorGeneral { get => _valorGeneral; set => _valorGeneral = value; }
        public string TipoProducto { get => _TipoProducto; set => _TipoProducto = value; }
        public double UtilidadUnity { get => _UtilidadUnity; set => _UtilidadUnity = value; }
        public double PesoUnit { get => _PesoUnit; set => _PesoUnit = value; }
        public string UndMedida { get => _UndMedida; set => _UndMedida = value; }
        public double PreVenta_Dolr { get => _PreVenta_Dolr; set => _PreVenta_Dolr = value; }
        public double PreVenta_Myr { get => _PreVenta_Myr; set => _PreVenta_Myr = value; }
        public double PreVenta_Mnr { get => _PreVenta_Mnr; set => _PreVenta_Mnr = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public int Idmark { get => _idmark; set => _idmark = value; }
        public int Idcat { get => _idcat; set => _idcat = value; }
        public double Stock { get => _stock; set => _stock = value; }
        public double PreCompra_Dlr { get => _PreCompra_Dlr; set => _PreCompra_Dlr = value; }
        public double PreCompra_Sol { get => _PreCompra_Sol; set => _PreCompra_Sol = value; }
        public double Frank { get => _frank; set => _frank = value; }
        public string DescripcionGeneral { get => _descripcionGeneral; set => _descripcionGeneral = value; }
        public string Idproveedor { get => _idproveedor; set => _idproveedor = value; }
        public string Idprod { get => _idprod; set => _idprod = value; }
    }
}
