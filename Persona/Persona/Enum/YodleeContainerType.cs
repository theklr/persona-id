using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiDinero
{
    public enum YodleeContainerType
    {
        NotSpecified = 0,
        BANK = 1,
        CREDIT_CARD = 2,
        INVESTMENT = 3,
        INSURANCE = 4,
        LOAN = 5,
        REWARD_PROGRAM = 6,
        MORTGAGE = 7,
        ALL = BANK | CREDIT_CARD | INVESTMENT | INSURANCE | LOAN | REWARD_PROGRAM | MORTGAGE
    }
}