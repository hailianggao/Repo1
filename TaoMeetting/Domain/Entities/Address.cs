using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
 public  class Address
    {
     public virtual string ZipCode { get; set; }
     [DisplayName("名称")]
     public virtual string Name { get; set; }

     public virtual string Province { get; set; }
    }
}
