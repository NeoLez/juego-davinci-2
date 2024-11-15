using System;
using UnityEngine;

namespace New
{
	public class RegisterPlayerInManager : MonoBehaviour
	{
		
		private void Start() {
			Manager.Instance.player = gameObject;
		}
		
	}
}