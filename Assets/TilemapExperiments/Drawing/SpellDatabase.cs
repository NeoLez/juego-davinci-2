using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace TilemapExperiments.Drawing
{
    public static class SpellDatabase
    {
        public static Dictionary<DrawingPattern, SpellSO> patterns;
        static SpellDatabase()
        {
            List<SpellSO> spellsList = Resources.LoadAll<SpellSO>("SpellsSO").ToList();
            patterns = new();
            
            spellsList.ForEach(spell =>
            {
                patterns.Add(new DrawingPattern(spell.drawingPattern), spell);
            });
        }

        
        [CanBeNull] public static SpellSO FindSpellFromPattern(DrawingPattern pattern)
        {
            foreach (var p in patterns)
            {
                if (p.Key.Matches(pattern))
                {
                    return p.Value;
                }
            }
            return null;
        }
    }
}