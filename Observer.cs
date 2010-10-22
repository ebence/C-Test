using System;
using System.Collections.Generic;
using System.Text;

namespace TestToBeDeleted100804
{
    public interface ISubject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObservers();
    }
    public interface IObserver
    {
        void update(float temp, float humidity, float pressure);
    }
    public interface IDisplayElement
    {
        void display();
    }
    public class WeatherData : ISubject
    {
        private List<object> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<object>();
        }
        #region ISubject Members

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void notifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                IObserver observer = (IObserver)observers[i];
                observer.update(temperature, humidity, pressure);
            }
        }

        #endregion

        public void measurementsChanged()
        {
            notifyObservers();
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }

        #region IDisplayElement Members

        public void display()
        {
            System.Windows.Forms.MessageBox.Show("Current conditions: " + temperature.ToString() + " °C and " + humidity.ToString() + "% humidity");
        }

        #endregion

        #region IObserver Members

        public void update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            display();
        }

        #endregion
    }
    public class HeatIndexDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private float pressure;
        private ISubject weatherData;

        public HeatIndexDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
        }
        #region IObserver Members

        public void update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        #endregion

        #region IDisplayElement Members

        public void display()
        {
            float my = pressure * temperature * humidity;
            System.Windows.Forms.MessageBox.Show(my.ToString());
        }

        #endregion
    }

}
