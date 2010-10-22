using System;
using System.Collections.Generic;
using System.Text;

namespace TestToBeDeleted100804
{
    public class Duck
    {
        protected IFlyBehavior flyBehavior;
        public Duck()
        { }

        public void performFly()
        {
            flyBehavior.fly();
        }
        public void setFlyBehavior(IFlyBehavior fb)
        {
            flyBehavior = fb;
        }
    }
    public interface IFlyBehavior
    {
         void fly();
    }
    public class FlyWithWings:IFlyBehavior
    {
         public void fly()
        {
            System.Windows.Forms.MessageBox.Show("I am flying");
        }
    }
    public class FlyNoWay : IFlyBehavior
    {
         public void fly()
        {
            System.Windows.Forms.MessageBox.Show("I can't fly");
        }
    }
    public class MallardDuck : Duck
    {
        public MallardDuck()
        {
            flyBehavior = new FlyNoWay();
        }
    }
    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyWithWings();
        }
    }
    public class FlyRocketPowered : IFlyBehavior
    {
        public void fly()
        {
            System.Windows.Forms.MessageBox.Show("I'm flying with a rocket");
        }
    }
}
