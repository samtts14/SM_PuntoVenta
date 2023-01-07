using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj_Capa_Entidad
{
    public class EN_Proveedor
    {
        /*@idproveedor char (6),
          @nombre varchar(50),
          @direccion varchar(150),
          @telefono char (15),
          @rubro varchar(50),
          @ruc char (20),
          @correo varchar(150),
          @contacto varchar(50),
          @fotologo varchar(180)*/

        private string _idproveedor;
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private string _rubro;
        private string _ruc;
        private string _correo;
        private string _contacto;
        private string _fotologo;

        public string Fotologo { get => _fotologo; set => _fotologo = value; }
        public string Contacto { get => _contacto; set => _contacto = value; }
        public string Correo { get => _correo; set => _correo = value; }
        public string Ruc { get => _ruc; set => _ruc = value; }
        public string Rubro { get => _rubro; set => _rubro = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Idproveedor { get => _idproveedor; set => _idproveedor = value; }
    }
}
