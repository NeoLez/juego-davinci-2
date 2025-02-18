using New;
using UnityEngine;

namespace Stats
{
    public class StatIntPercentageModifier : StatPercentageModifier
    {
        public StatIntPercentageModifier(float percentage, float effectTime) : base(percentage, effectTime)
        {
            
        }
        
        public override float getOffset(float baseValue)
        {
            return Mathf.Floor(baseValue * percentage);
        }
    }
}