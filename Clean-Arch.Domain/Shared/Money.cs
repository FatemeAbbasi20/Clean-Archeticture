using Clean_Arch.Domain.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Domain.Shared
{
    public class Money: BaseValueObject
    
    {
        public int RialValue { get; private set; }
        public Money(int RialValue)
        {
            if (RialValue < 0)
                throw new InvalidDataDomainException();
            this.RialValue = RialValue;
        }
        public static Money FromRial(int RialValue)
        {
            return new Money(RialValue );
        }
        public static Money FromToman(int TomanValue)
        {
            return new Money(TomanValue*10);
        }
        public static Money operator+(Money FirstMoney, Money SecondMoney)
            {
               return new Money( FirstMoney.RialValue+ SecondMoney.RialValue);
            }
        public static Money operator -(Money FirstMoney, Money SecondMoney)
        {
            return new Money(FirstMoney.RialValue - SecondMoney.RialValue);
        }
        //public static bool operator ==(Price FirstMoney, Price SecondMoney)
        //{
        //    return FirstMoney.RialValue == SecondMoney.RialValue;
        //}
        //public static bool operator !=(Price FirstMoney, Price SecondMoney)
        //{
        //    return FirstMoney.RialValue != SecondMoney.RialValue;
        //}
        public override string ToString()
        {
            return RialValue.ToString("#,0");
        }

    }
}
