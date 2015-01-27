using System;
using System.Text;
using System.Collections.Generic;


namespace eValorados_Web.Models {

    public class Movimiento : BaseModel<int> {
        public virtual Almacen Almacen { get; set; }
        public virtual MotivoMovimiento MotivoMovimiento { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        public virtual string OtroMotivoMovimiento { get; set; }
        public virtual int Cantidad { get; set; }
        public virtual DateTime? FechaMovimiento { get; set; }
        public virtual bool IsTerminado { get; set; }
    }
}
