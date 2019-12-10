using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

    public MainWindow()
        {
            InitializeComponent();
           
        }

       //Create a list of all objects 
        List<SolarObject> m_allObjects = new List<SolarObject>();

        //Create a dispatcher timer 
        DispatcherTimer timer = new DispatcherTimer();
        int m_timerInterval = 10;

        /// <summary>
        /// Create an action event. When the button is clicked the objects of the solar system start to move on a defined path
        /// </summary>
        /// <param name="sender">a menu item is clicked</param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            double cx = MyCanvas.ActualWidth / 2;
            double cy = MyCanvas.ActualHeight / 2;

            //define the name, color, location, radius and size of the sun object
            SunObject sun = new SunObject("sun", Colors.Orange, MyCanvas, cx, cy, 100, 100);

            //define the name, color, location, radius and size of the Earth object and position from the Sun
            PlanetObject earth = new PlanetObject("earth", Colors.Blue, MyCanvas, 0, 0, 50, 40, 40, sun, 100, 1);

            //define the name, color, location, radius and size of the Moon object and position from the Sun
            PlanetObject moon = new PlanetObject("moon", Colors.White, MyCanvas, 0, 0, 10, 20, 20, earth, 40, 5);

            //define the name, color, location, radius and size of the Mars object and position from the Sun
            PlanetObject mars = new PlanetObject("mars", Colors.Red, MyCanvas, 0, 0, 50, 40, 40, sun, 200, 2);

            //Add the new objects to the allObjects list
            m_allObjects.Add(sun);
            m_allObjects.Add(earth);
            m_allObjects.Add(moon);
            m_allObjects.Add(mars);

            //start the timer what defines the speed of the objects
            timer.Interval = TimeSpan.FromMilliseconds(m_timerInterval);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        /// <summary>
        /// create an action handler for all objects 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach(SolarObject s in m_allObjects)
            {
                s.Update(m_timerInterval);
            }
        }

        /// <summary>
        /// make sure if the menu item is checked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_enable_Checked(object sender, RoutedEventArgs e)
        {
            menuItem.IsChecked = true;
            timer.IsEnabled = true;
        }
        
        /// <summary>
        /// make sure if the menu item is unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Unchecked(object sender, RoutedEventArgs e)
        {
            menuItem.IsChecked = false;
            timer.IsEnabled = false;
        }

       
        
    }
}

