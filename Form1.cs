using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestToBeDeleted100804
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Singleton myObj = Singleton.GetInstance();

            MessageBox.Show(myObj.Mama());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duck mallard = new MallardDuck();
            mallard.performFly();

            Duck model = new ModelDuck();
            model.performFly();
            model.setFlyBehavior(new FlyRocketPowered());
            model.performFly();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            HeatIndexDisplay myDisplay = new HeatIndexDisplay(weatherData);
            weatherData.setMeasurements(80, 65, 30.4f);
            weatherData.setMeasurements(82, 70, 29.2f);
            weatherData.setMeasurements(78, 90, 29.2f);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyReader myR = new MyReader(new ReadGerman());
            myR.Read();
            myR.SetReader(new ReadHungarian());
            myR.Read();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbstractTrial myTrial = new DerivedClass1();
            System.Windows.Forms.MessageBox.Show(myTrial.GetNewI());
            myTrial = new DerivedClass2();
            System.Windows.Forms.MessageBox.Show(myTrial.GetNewI());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            port myport = new port();
            
            
        }
    }
 
    public interface IReadable
    {
        void Read();
    }

    public class ReadHungarian:IReadable
    {
        public 
            void Read()
        {
            System.Windows.Forms.MessageBox.Show("Hungarian");
        }
    }
    public class ReadGerman : IReadable
    {
        public void Read()
        {
            System.Windows.Forms.MessageBox.Show("German");
        }
    }

    public class MyReader
    {
        private IReadable myIReadable;

        public MyReader(IReadable r)
        {
            myIReadable = r;
        }

        public void SetReader(IReadable ReadR)
        {
            myIReadable = ReadR;
        }
        public void Read()
        {
            myIReadable.Read();
        }
           
    }
}