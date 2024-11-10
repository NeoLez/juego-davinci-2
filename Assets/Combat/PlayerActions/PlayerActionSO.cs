using UnityEngine;

namespace Combat
{
	[CreateAssetMenu(fileName = "NewSkill", menuName = "Skill")]
	public class PlayerActionSO : ScriptableObject
	{
		public PlayerActions action;
		public Sprite Skill_Sprite;
		public string Skill_Name;
		public string Description;
	}
}