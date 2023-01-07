using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Kardex
    {

        private string _idKardex;
        private int _Item;
        private string _doc_soporte;
        private string _Det_Operacion;
        private double _cantidad_in;
        private double _precio_In;
        private double _total_In;

        private double _cantidad_Out;
        private double _Precio_out;
        private double _Total_out;

        private double _cantidad_saldo;
        private double _Promedio;
        private double _Total_saldo;

        public double Total_saldo { get => _Total_saldo; set => _Total_saldo = value; }
        public double Promedio { get => _Promedio; set => _Promedio = value; }
        public double Cantidad_saldo { get => _cantidad_saldo; set => _cantidad_saldo = value; }
        public double Total_out { get => _Total_out; set => _Total_out = value; }
        public double Precio_out { get => _Precio_out; set => _Precio_out = value; }
        public double Cantidad_Out { get => _cantidad_Out; set => _cantidad_Out = value; }
        public double Total_In { get => _total_In; set => _total_In = value; }
        public double Precio_In { get => _precio_In; set => _precio_In = value; }
        public double Cantidad_in { get => _cantidad_in; set => _cantidad_in = value; }
        public string Det_Operacion { get => _Det_Operacion; set => _Det_Operacion = value; }
        public string Doc_soporte { get => _doc_soporte; set => _doc_soporte = value; }
        public string IdKardex { get => _idKardex; set => _idKardex = value; }
        public int Item { get => _Item; set => _Item = value; }
    }
}
