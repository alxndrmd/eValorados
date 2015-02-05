using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace eValorados_Web.Models {

    public class MotivoMovimiento : BaseModel<int> {
        public MotivoMovimiento() {
			Movimientos = new List<Movimiento>();
        }
        [StringLength(200)]
        [DisplayName("Descripcion")]
        public virtual string Descripcion { get; set; }

        [Range(0, 9)]
        [DisplayName(" Es Activo ")]
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimientos { get; set; }
    }
}
