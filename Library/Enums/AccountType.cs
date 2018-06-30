using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    /// <summary>
    /// 币种类别
    /// </summary>
    public enum AccountType
    {
        奖金积分 = 1,
        电子积分 = 2,
        消费积分 = 3,
        种子积分 = 4,
        报单积分 = 5,
        能量值 = 6,
        购物钱包 = 7,
        交易钱包 = 8,
    };

}

namespace Library
{
    public class AccountTypeHelper
    {
        public static string GetName(int type)
        {
            return Enum.GetName(typeof(AccountType), type);
        }
    }
}


