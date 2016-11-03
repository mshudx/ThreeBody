using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBody.Windows.Models
{
    public static class Constants
    {
        public const int NumberOfBodies = 3; // TODO: this number of bodies will be simulated but exactly 3 will be visualized!
        public const int SimulationStepIntervalInMilliseconds = 10;

        public const int BodyDiameterInMetersMin = 5;
        public const int BodyDiameterInMetersMax = 50;
        public const double BodyDensityInKilogramsPerSquareMeter = 3;

        /// <summary>
        /// Starting velocities will be between -1*this and this.
        /// </summary>
        public const int BodyStartingVelocityInMetersPerSecondMax = 20;

        public const double WorldGenerationMargin = 0.15;
    }
}
