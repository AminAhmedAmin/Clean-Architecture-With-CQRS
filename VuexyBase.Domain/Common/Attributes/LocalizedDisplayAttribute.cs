using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Common.Attributes
{
    public class LocalizedDisplayAttribute : Attribute
    {
        public string NameEn { get; }
        public string NameAr { get; }

        public LocalizedDisplayAttribute(string nameAr, string nameEn)
        {
            NameEn = nameEn;
            NameAr = nameAr;
        }
    }
}
