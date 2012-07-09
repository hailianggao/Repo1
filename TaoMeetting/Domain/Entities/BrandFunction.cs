using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
    public class BrandFunction
    {
        public virtual int id { get; set; }
        public virtual int BfId { get; set; }
        //public virtual int FunctionTypeId { get; set; }
        public virtual FunctionType Funcs { get; set; }
    }
}
