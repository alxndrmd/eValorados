using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;



namespace eValorados_Web.Models {

    public class Almacen : BaseModel<int> {
        public Almacen() {
			Movimientos = new List<Movimiento>();
        }
        [DisplayName("Agencia")]
        public virtual Agencia Agencia { get; set; }
        [DisplayName("Valorado")]
        public virtual Valorado Valorado { get; set; }
        
        [Range(0, 999999999)]
        [DisplayName("Cantidad Mínima")]
        public virtual int? CantidadMinima { get; set; }

        [Range(0, 999999999)]
        [DisplayName("Cantidad Máxima")]
        public virtual int? CantidadMaxima { get; set; }

        [Range(0, 999999999)]
        [DisplayName("Inventario Virtual")]
        public virtual int? InventarioVirtual { get; set; }

        [Range(0, 999999999)]
        [DisplayName("Inventario Real")]
        public virtual int? InventarioReal { get; set; }

        [DisplayName("¿Está activo?")]
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimientos { get; set; }
    }
}
