using System;
using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

[CreateAssetMenu()]
public class CharacterDataSO : ScriptableObject
{
	[SerializeField]
	public Stats BaseStats;
    [SerializeField]
    public string Name;
    [SerializeField]
	public List<PlayerActions> Habilidades;
	[SerializeField]
	public Sprite Sprite;
}