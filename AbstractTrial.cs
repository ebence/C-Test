using System;
using System.Collections.Generic;
using System.Text;

namespace TestToBeDeleted100804
{
    abstract class AbstractTrial
    {
        public string GetNumber()
        {
            return GetNewI();
        }
        public abstract string GetNewI();
    }

    class DerivedClass1 : AbstractTrial
    {
        public override string GetNewI()
        {
            return "1";
        }
    }
    class DerivedClass2 : AbstractTrial
    {
        public override string GetNewI()
        {
            return "2";
        }
    }
}
