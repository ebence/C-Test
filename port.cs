using System;
using System.Collections.Generic;
using System.Text;

namespace TestToBeDeleted100804
{
    class port:System.IO.Ports.SerialPort
    {
        port() { }
    }
    class myTrial:System.IO.Ports.SerialPort
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }

    class DerivedTrial : myTrial
    {
        private int myInt;

        public int DerivedInt
        {
            get { return myInt; }
            set { myInt = value; }
        }

    }
    class x
    {
        public void s()
        {
            myTrial trial = new myTrial();
            trial.MyProperty = 1;
            
            DerivedTrial derived = new DerivedTrial();
            derived.MyProperty = 1;

        }
    }
}
