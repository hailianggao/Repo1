using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaoMeetting.Domain
{
    public class FunctionType
    {
        public virtual int id { get; set; }
        [DisplayName("功能名称")]
        public virtual string FunName { get; set; }
        [DisplayName("功能类别")]
        public virtual bool hascheck{get;set;}
        public virtual int FunType { get; set; }
        public virtual string FunTypeName { get; set; }
    }
}
