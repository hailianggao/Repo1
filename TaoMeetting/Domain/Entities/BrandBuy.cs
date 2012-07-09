using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
    public class BrandBuy
    {
        public virtual int id { get; set; }
        public virtual int BbId { get; set; }
        [DisplayName("价格")]
        public virtual float Price { get; set; }
        //public virtual int BuyTypeId { get; set; }
        public virtual BuyType ButT{get;set;}
       

    }
}
