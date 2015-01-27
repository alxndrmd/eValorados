using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class MotivoMovimiento : BaseModel<int> {
        public MotivoMovimiento() {
			Movimientos = new List<Movimiento>();
        }

        [DisplayName("Descripcion")]
        public virtual string Descripcion { get; set; }

        [DisplayName(" Es Activo ")]
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimientos { get; set; }
    }
}
