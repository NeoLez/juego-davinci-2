using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [Serializable] public class StatProperty
    {
        [SerializeField] private float baseValue;
        private List<StatFlatModifier> flatModifiers = new();
        private List<StatPercentageModifier> percentageModifiers = new();

        public float value => GetCurrentValue();

        public void SetBaseValue(float value)
        {
            baseValue = value;
        }
        
        private float GetCurrentValue()
        {
            float offset = 0;
            for (int i = flatModifiers.Count-1; i >= 0; i--)
            {
                if (flatModifiers[i].HasExpired())
                {
                    flatModifiers.RemoveAt(i);
                    continue;
                }

                offset += flatModifiers[i].getOffset();
            }
            for (int i = percentageModifiers.Count-1; i >= 0; i--)
            {
                if (percentageModifiers[i].HasExpired())
                {
                    percentageModifiers.RemoveAt(i);
                    continue;
                }

                offset += percentageModifiers[i].getOffset(baseValue);
            }

            return baseValue + offset;
        }
        
        public void AddFlatModifier(StatFlatModifier modifier)
        {
            flatModifiers.Add(modifier);
        }
        
        public void AddPercentageModifier(StatPercentageModifier modifier)
        {
            percentageModifiers.Add(modifier);
        }

        public static implicit operator float(StatProperty v)
        {
            return v.value;
        }
    }
}