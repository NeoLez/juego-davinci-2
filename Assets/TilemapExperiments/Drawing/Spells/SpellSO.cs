using System.Collections.Generic;
using UnityEngine;

public abstract class SpellSO : ScriptableObject
{
    [Header("Spell Fields")]
    public string spellName;
    public Sprite icon;
    public List<OrderAgnosticByteTuple> drawingPattern;
    public abstract void Cast();
}