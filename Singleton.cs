using System;
using System.Collections.Generic;
using System.Text;

namespace TestToBeDeleted100804
{
    class Singleton
    {
        private static Singleton instance;
        private string myString;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance==null)
            {
                instance = new Singleton();
            }
            return instance;
        }

        public string Mama()
        {
            myString += "a";
            return myString;
        }
    }
}
