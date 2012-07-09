using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
   
   public class ProductType
    {
       public virtual int id { get; set; }
       [DisplayName("产品类别")]
       public virtual string TypeName { get; set; }
       [DisplayName("图片")]
       public virtual string TypePic { get; set; }
       public virtual bool haschecked { get; set; }
    }
}
