using System;
using New;

namespace Stats
{
    public class StatFlatModifier
    {
        private Timer timer;
        private float value;

        public StatFlatModifier(float value, float effectTime)
        {
            this.value = value;
            timer = new Timer(Timer.UpdateType.UPDATE);
            timer.Wait(effectTime);
        }
        
        public float getOffset()
        {
            return value;
        }

        public bool HasExpired()
        {
            return !timer.IsWaiting();
        }
    }
}