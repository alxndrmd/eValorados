using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace eValorados_Web.Models
{
    public class BaseModel<TIdentifier>
        where TIdentifier : new()
    {
        [DisplayName("Código")]
        public virtual TIdentifier Id { get; set; }
    }
}