using System;
using UnityEngine;

namespace New
{
	public class RegisterPlayerInManager : MonoBehaviour
	{
		
		private void Update() {
			Manager.Instance.player = gameObject;
		}
		
	}
}