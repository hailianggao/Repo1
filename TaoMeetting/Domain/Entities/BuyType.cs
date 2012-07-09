using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
    public class BuyType
    {
        public virtual int id { get; set; }
        [DisplayName("购买类型")]
        public virtual string BuyTypeName { get; set; }
        public virtual bool haschecked { get; set; }
    }
}
