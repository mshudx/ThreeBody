using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBody.Windows.Models;
using Windows.UI.Xaml;

namespace ThreeBody.Windows.ViewModels
{
    /// <summary>
    /// Sets up and hosts a PhysicsEngine instance.
    /// </summary>
    public class VisualizationViewModel
    {
        public PhysicsEngine PhysicsEngine { get; } = new PhysicsEngine();

        private Random random = new Random();
        private DispatcherTimer timer = new DispatcherTimer();
        private DateTime lastTick;

        public VisualizationViewModel()
        {
            for (int i = 0; i < 3; i++) PhysicsEngine.Bodies.Add(GenerateRandomBody());

            lastTick = DateTime.Now;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private Body GenerateRandomBody()
        {
            return new Body()
            {
                Diameter = random.Next(10, 30),
                Density = 0.3,
                Position = new Vector(random.Next(200, 600), random.Next(200, 600)),
                Velocity = new Vector(random.Next(-50, 50), random.Next(-50, 50))
            };
        }

        private void Timer_Tick(object sender, object e)
        {
            double secondsElapsed = (DateTime.Now - lastTick).TotalSeconds;
            lastTick = DateTime.Now;
            PhysicsEngine.Step(secondsElapsed);
        }
    }
}
