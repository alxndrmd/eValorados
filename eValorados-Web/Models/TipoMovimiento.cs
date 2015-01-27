using System;
using System.Text;
using System.Collections.Generic;


namespace eValorados_Web.Models {

    public class TipoMovimiento : BaseModel<int> {
        public TipoMovimiento() {
			Movimientos = new List<Movimiento>();
        }
        public virtual string Descripcion { get; set; }
        public virtual string Accion { get; set; }
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimientos { get; set; }
    }
}
