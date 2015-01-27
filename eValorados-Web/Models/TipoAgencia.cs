using System;
using System.Text;
using System.Collections.Generic;


namespace eValorados_Web.Models {

    public class TipoAgencia : BaseModel<int> {
        public TipoAgencia() {
			Agencias = new List<Agencia>();
        }
        public virtual string Descripcion { get; set; }
        public virtual bool IsCentral { get; set; }
        public virtual bool IsActivo { get; set; }
        public virtual IList<Agencia> Agencias { get; set; }
    }
}
