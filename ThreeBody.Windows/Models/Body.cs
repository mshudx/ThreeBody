using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ThreeBody.Windows.Models
{
    /// <summary>
    /// Describes a 2-dimensional circular body with mass.
    /// </summary>
    public class Body : INotifyPropertyChanged
    {
        #region Writable Properties
        private double _Diameter;
        /// <summary>
        /// Diameter of the body in meters.
        /// </summary>
        public double Diameter
        {
            get
            {
                return _Diameter;
            }
            set
            {
                if (_Diameter != value)
                {
                    _Diameter = value;
                    OnPropertyChanged();
                    OnPropertyChangedExplicit(nameof(Area));
                    OnPropertyChangedExplicit(nameof(Mass));
                }
            }
        }

        private double _Density;
        /// <summary>
        /// Density of the body in kilograms per square meter.
        /// </summary>
        public double Density
        {
            get
            {
                return _Density;
            }
            set
            {
                if (_Density != value)
                {
                    _Density = value;
                    OnPropertyChanged();
                    OnPropertyChangedExplicit(nameof(Mass));
                }
            }
        }

        /// <summary>
        /// Position of the object in meters.
        /// </summary>
        private Vector _Position;
        public Vector Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (_Position != value)
                {
                    _Position = value;
                    OnPropertyChanged();
                    OnPropertyChangedExplicit(nameof(PositionAsThickness));
                }
            }
        }

        public Thickness PositionAsThickness
        {
            get
            {
                return new Thickness(Position.X, Position.Y, 0, 0);
            }
        }

        /// <summary>
        /// Velocity of the object in meters/second.
        /// </summary>
        private Vector _Velocity;
        public Vector Velocity
        {
            get
            {
                return _Velocity;
            }
            set
            {
                if (_Velocity != value)
                {
                    _Velocity = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Calculated Properties
        /// <summary>
        /// Area of the body in square meters.
        /// </summary>
        public double Area
        {
            get
            {
                return Math.Pow(Diameter / 2, 2) * Math.PI;
            }
        }
        /// <summary>
        /// Mass of the body in kilograms.
        /// </summary>
        public double Mass
        {
            get
            {
                return Area * Density;
            }
        }

        public override string ToString()
        {
            return $"X: {Position.X} Y: {Position.Y} dX: {Velocity.X} dY: {Velocity.Y} Diameter: {Diameter} Mass: {Mass}";
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        private void OnPropertyChangedExplicit(string caller)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion
    }
}
