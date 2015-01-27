using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class Almacen : BaseModel<int> {
        public Almacen() {
			Movimiento = new List<Movimiento>();
        }
        [DisplayName("Agencia")]
        public virtual Agencia Agencia { get; set; }
        [DisplayName("Valorado")]
        public virtual Valorado Valorado { get; set; }
        [DisplayName("Cantidad Mínima")]
        public virtual int? CantidadMinima { get; set; }
        [DisplayName("Cantidad Máxima")]
        public virtual int? CantidadMaxima { get; set; }
        [DisplayName("Inventario Virtual")]
        public virtual int? InventarioVirtual { get; set; }
        [DisplayName("Inventario Real")]
        public virtual int? InventarioReal { get; set; }
        [DisplayName("¿Está activo?")]
        public virtual bool IsActivo { get; set; }
        public virtual IList<Movimiento> Movimiento { get; set; }
    }
}
