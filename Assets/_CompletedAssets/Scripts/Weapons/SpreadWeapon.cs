﻿using UnityEngine;
using System.Collections;


namespace CompleteProject{
	public class SpreadWeapon : Weapon {

		override protected void activateWeapon(){
			PlayerWeaponManager.activateSpread(); //static function
		}
	}
}