using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiDinero
{
    [Flags]
    public enum SavingType
    {
        NoneSpecified = 0,
        BuyHouse = 1,
        PayDebt = 2,
        VacationBigPurchase = 4,
        Retirement = 8
    }
}