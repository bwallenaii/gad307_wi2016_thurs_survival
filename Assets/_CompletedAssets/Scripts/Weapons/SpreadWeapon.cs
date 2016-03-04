using UnityEngine;
using System.Collections;


namespace CompleteProject{
	public class SpreadWeapon : Weapon {

		public static bool spreadInGame = true;

		void Start(){
			inGame = spreadInGame;
		}

		override protected void activateWeapon(){
			PlayerWeaponManager.activateSpread(); //static function
		}
	}
}