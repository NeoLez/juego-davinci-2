using New;

namespace Stats
{
    public class StatPercentageModifier
    {
        private Timer timer;
        protected float percentage;

        public StatPercentageModifier(float percentage, float effectTime)
        {
            this.percentage = percentage;
            timer = new Timer(Timer.UpdateType.UPDATE);
            timer.Wait(effectTime);
        }

        public virtual float getOffset(float baseValue)
        {
            return baseValue * percentage;
        }
        
        public bool HasExpired()
        {
            return !timer.IsWaiting();
        }
    }
}