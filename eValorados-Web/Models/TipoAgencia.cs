using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace eValorados_Web.Models {

    public class TipoAgencia : BaseModel<int> {
        public TipoAgencia() {
			Agencias = new List<Agencia>();
        }

        [StringLength(60)]
        [DisplayName("Descripcion")]
        public virtual string Descripcion { get; set; }


        [DisplayName("Central")]
        public virtual bool IsCentral { get; set; }

        [Range(0,9)]
        [DisplayName("¿Está activo?")] 
        public virtual bool IsActivo { get; set; }
        public virtual IList<Agencia> Agencias { get; set; }
    }
}
