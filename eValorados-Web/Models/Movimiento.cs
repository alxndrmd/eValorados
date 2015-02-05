using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace eValorados_Web.Models {

    public class Movimiento : BaseModel<int> {
        public virtual Almacen Almacen { get; set; }
        public virtual MotivoMovimiento MotivoMovimiento { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        [StringLength(200)]
        public virtual string OtroMotivoMovimiento { get; set; }


        [Range(0,999999999)]
        public virtual int Cantidad { get; set; }
        public virtual DateTime? FechaMovimiento { get; set; }
        
        public virtual bool IsTerminado { get; set; }
    }
}
