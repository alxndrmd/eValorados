using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class TipoAgencia : BaseModel<int> {
        public TipoAgencia() {
			Agencias = new List<Agencia>();
        }

        [DisplayName("Descripcion")]
        public virtual string Descripcion { get; set; }
        [DisplayName("Central")]
        public virtual bool IsCentral { get; set; }
        [DisplayName("¿Está activo?")] 
        public virtual bool IsActivo { get; set; }
        public virtual IList<Agencia> Agencias { get; set; }
    }
}
