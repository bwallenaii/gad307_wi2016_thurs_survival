using UnityEngine;
using System.Collections;

namespace CompleteProject{
	public class HelephanGun : Weapon {

		public static bool helephantGunInGame = true;

		void Start(){
			inGame = helephantGunInGame;
		}

		override protected void activateWeapon(){
			PlayerWeaponManager.activateHelephantGun(); //static function
		}
	}
}