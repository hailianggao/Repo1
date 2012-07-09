using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
   public class BrandProduct
    {
       public virtual int id { get; set; }
       public virtual int BpId { get; set; }
       //public virtual int ProductTypeId { get; set; }
       public virtual ProductType ProductT { get; set; }
    }
}
