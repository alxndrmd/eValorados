using System;
using System.Text;
using System.Collections.Generic;


namespace eValorados_Web.Models {

    public class TipoValorado : BaseModel<int> {
        public TipoValorado() {
            
			Valorados = new List<Valorado>();
        }
        public virtual string Descripcion { get; set; }
        public virtual bool IsActivo { get; set; }
        public virtual IList<Valorado> Valorados { get; set; }
    }
}
