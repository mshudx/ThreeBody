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

        public VisualizationViewModel(int minX, int maxX, int minY, int maxY)
        {
            for (int i = 0; i < Constants.NumberOfBodies; i++) PhysicsEngine.Bodies.Add(GenerateRandomBody(minX, maxX, minY, maxY));

            lastTick = DateTime.Now;
            timer.Interval = TimeSpan.FromMilliseconds(Constants.SimulationStepIntervalInMilliseconds);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private Body GenerateRandomBody(int minX, int maxX, int minY, int maxY)
        {
            return new Body()
            {
                Diameter = random.Next(Constants.BodyDiameterInMetersMin, Constants.BodyDiameterInMetersMax),
                Density = Constants.BodyDensityInKilogramsPerSquareMeter,
                Position = new Vector(random.Next(minX, maxX), random.Next(minY, maxY)),
                Velocity = new Vector(random.Next(-1 * Constants.BodyStartingVelocityInMetersPerSecondMax, Constants.BodyStartingVelocityInMetersPerSecondMax), random.Next(-1 * Constants.BodyStartingVelocityInMetersPerSecondMax, Constants.BodyStartingVelocityInMetersPerSecondMax))
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
