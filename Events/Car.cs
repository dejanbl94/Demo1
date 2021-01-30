using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Car
    {
        public event Action OnChange;

        private double speed;
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                if (speed >= 60)
                {
                    /*if (OnChange != null)
                    {
                        OnChange();
                    }*/
                    // Above check simplified.
                    OnChange?.Invoke();
                }
            }
        
        }
    }
}
