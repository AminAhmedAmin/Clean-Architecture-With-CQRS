using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Enums.Validation
{
    public enum ValidationTypesEnum
    {
        Required,
        MinLength,
        MaxLength,
        ConfirmNewPassowrd,
        Email,
        GreaterThan,
        ExclusiveBetween,
        SaudiPhone,
        IdentityNumber,
        IBAN,
        BankAccountNo
    }
}
