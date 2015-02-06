using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class TipoValorado : BaseModel<int> {
        public TipoValorado() {
            
			Valorados = new List<Valorado>();
        }


        [StringLength(200)]
        public virtual string Descripcion { get; set; }


        [DisplayName("¿Está activo?")] 
        public virtual bool IsActivo { get; set; }

        public virtual IList<Valorado> Valorados { get; set; }
    }
}
