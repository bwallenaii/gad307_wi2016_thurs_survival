using UnityEngine;
using System.Collections;

namespace CompleteProject{
	public class HelephanGun : Weapon {

		override protected void activateWeapon(){
			PlayerWeaponManager.activateHelephantGun(); //static function
		}
	}
}