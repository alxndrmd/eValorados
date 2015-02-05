using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace eValorados_Web.Models {

    public class TipoValorado : BaseModel<int> {
        public TipoValorado() {
            
			Valorados = new List<Valorado>();
        }


        [StringLength(200)]
        public virtual string Descripcion { get; set; }


        [Range(0,9)]
        public virtual bool IsActivo { get; set; }

        public virtual IList<Valorado> Valorados { get; set; }
    }
}
