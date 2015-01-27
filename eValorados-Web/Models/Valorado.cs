using System;
using System.Text;
using System.Collections.Generic;


namespace eValorados_Web.Models {

    public class Valorado : BaseModel<int> {
        public Valorado() {
			Almacenes = new List<Almacen>();
        }
        public virtual TipoValorado TipoValorado { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string IdentificadorAdicional { get; set; }
        public virtual bool IsActivo { get; set; }
        public virtual IList<Almacen> Almacenes { get; set; }
    }
}
