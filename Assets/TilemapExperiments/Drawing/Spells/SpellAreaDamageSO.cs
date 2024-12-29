using Unity.VisualScripting;
using UnityEngine;

namespace TilemapExperiments.Drawing.Spells
{
    [CreateAssetMenu(menuName = "Spells/SpellAreaDamageSO")]
    public class SpellAreaDamageSO : SpellSO
    {
        [Header("AreaDamage Fields")]
        public float radius;
        public float damage;
        
        public override void Cast()
        {
            Debug.Log("a");
        }
    }
}