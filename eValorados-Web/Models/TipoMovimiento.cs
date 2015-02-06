using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class TipoMovimiento : BaseModel<int> {
        public TipoMovimiento() {
			Movimientos = new List<Movimiento>();
        }
        [StringLength(60)]
        public virtual string Descripcion { get; set; }
        [StringLength(10)]
        public virtual string Accion { get; set; }


        [DisplayName("¿Está activo?")] 
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimientos { get; set; }
    }
}
