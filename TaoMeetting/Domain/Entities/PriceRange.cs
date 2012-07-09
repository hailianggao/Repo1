using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
 public  class PriceRange
    {
     public virtual int id { get; set; }
     public virtual float lowprice { get; set; }
     public virtual float highprice { get; set; }
    }
}
