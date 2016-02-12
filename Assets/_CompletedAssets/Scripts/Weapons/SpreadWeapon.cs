using UnityEngine;
using System.Collections;


namespace CompleteProject{
	public class SpreadWeapon : MonoBehaviour {

		void OnTriggerEnter(Collider col){
			print("touching");

			PlayerWeaponManager pwm = col.gameObject.GetComponent<PlayerWeaponManager>();

			if(pwm != null){
				//PlayerWeaponManager.activateSpread(); //static function
				pwm.enableSpread();
			}
			
		}
	}
}