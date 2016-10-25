using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBody.Windows.Models
{
    /// <summary>
    /// Implements a simple physics engine supporting Newton's laws of motion and Newton's law of universal gravitation 
    /// (so there are collisions and gravity).
    /// TODO collision
    /// </summary>
    public class PhysicsEngine
    {
        public ObservableCollection<Body> Bodies { get; } = new ObservableCollection<Body>();

        /// <summary>
        /// Steps the simulation forward with the given time amount.
        /// </summary>
        /// <remarks>
        /// The effects of gravity are calculated only once per step, so two half-second steps yield a different result than a single one-second step.
        /// </remarks>
        /// <param name="secondsElapsed"></param>
        public void Step(double secondsElapsed)
        {
            // Compute effect of gravity on velocity.
            foreach (var body1 in Bodies)
            {
                foreach (var body2 in Bodies)
                {
                    if (!object.ReferenceEquals(body1, body2))
                    {
                        CalculateGravityEffects(body1, body2, secondsElapsed);
                    }
                }
            }

            // Compute effect of velocity on position.
            foreach (var body in Bodies)
            {
                body.Position += body.Velocity * secondsElapsed;
            }
        }

        /// <summary>
        /// Calculates the effects of gravity on Body 1 in relation to Body 2 by changing Body 1's velocity appropriately.
        /// </summary>
        /// <remarks>
        /// The calculation is one-way, Body 2 will not be affected. To calculate the effect on Body 2, call the method with the arguments reversed.
        /// </remarks>
        private void CalculateGravityEffects(Body body1, Body body2, double secondsElapsed)
        {
            // Newton's Law of Universal Gravitation
            // Calculate direction of the force
            // "Every point mass attracts every single other point mass by a force pointing along the line intersecting both points."
            var direction = GetDirectionUnitVector(body1, body2);

            // Calculate magnitude of the force
            // "The force is proportional to the product of the two masses and inversely proportional to the square of the distance between them."
            var magnitude =
                (body1.Mass * body2.Mass) /
                (Math.Pow(GetDistance(body1, body2), 2));

            // Calculate force
            var force = direction * magnitude * secondsElapsed;

            // Newton's Second Law
            // F=m*a => a=F/m
            // Calculate acceleration and change velocity by the result
            body1.Velocity += force / body1.Mass;
        }

        /// <summary>
        /// Gets a unit vector (vector with length of 1) pointing from Body 1 towards Body 2.
        /// </summary>
        private Vector GetDirectionUnitVector(Body body1, Body body2)
        {
            var directionVector = body2.Position - body1.Position;
            return directionVector / directionVector.Length;
        }

        /// <summary>
        /// Calculates the distance in meters between the two bodies using the Pythagorean Theorem.
        /// </summary>
        private double GetDistance(Body body1, Body body2)
        {
            return Math.Sqrt(
                Math.Pow(body1.Position.X - body2.Position.X, 2) +
                Math.Pow(body2.Position.Y - body2.Position.Y, 2));
        }
    }
}
