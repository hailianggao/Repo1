using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
    public class BrandInfo
    {
        public virtual int id{get;set;}
        [DisplayName("品牌")]
        public virtual string BrandName { get; set; }
        [DisplayName("图片")]
        public virtual string BrandPic { get; set; }
        [DisplayName("地址")]
        public virtual Address Address { get; set; }
       
        [DisplayName("电话")]
        public virtual string Phone { get; set; }
        [DisplayName("官方地址")]
        public virtual string Url { get; set; }
        [DisplayName("基本功能")]
        public virtual float BaseFunScore { get; set; }
        [DisplayName("特殊功能")]
        public virtual float SpecialFunScore { get; set; }
        [DisplayName("权重")]
        public virtual float Weight { get; set; }
        public virtual string Products { get; set; }
        public virtual string Buytypes { get; set; }
        public virtual string BFunctions { get; set; }
        public virtual string SFunctions { get; set; }
        public virtual IList<BrandFunction> BrandFunctions { get; set; }
        public virtual IList<BrandProduct> BrandProducts { get; set; }
        public virtual IList<BrandBuy> BrandBuys { get; set; }
    }
}
