using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace eValorados_Web.Models {
    
    public class Agencia : BaseModel<int> {
        public Agencia() {
			Almacenes = new List<Almacen>();
        }
        [DisplayName("Tipo de agencia")]
        public virtual TipoAgencia TipoAgencia { get; set; }
        [DisplayName("Descripción")]
        [StringLength(60)]
        public virtual string Descripcion { get; set; }
        [StringLength(200)]
        [DisplayName("Dirección")]
        public virtual string Direccion { get; set; }

        [Range(0, 9)]
        [DisplayName("¿Está activo?")]
        public virtual bool IsActivo { get; set; }
        public virtual IList<Almacen> Almacenes { get; set; }
    }
}
