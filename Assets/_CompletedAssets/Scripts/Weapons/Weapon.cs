using UnityEngine;
using System.Collections;

namespace CompleteProject{
	public class Weapon : MonoBehaviour {

		protected bool inGame = true;

		// Update is called once per frame
		void Update () {
			gameObject.GetComponent<MeshRenderer>().enabled = PlayerWeaponManager.canGetWeapon && inGame;
			gameObject.GetComponent<Collider>().enabled = PlayerWeaponManager.canGetWeapon && inGame;
		}

		void OnTriggerEnter(Collider col){

			PlayerWeaponManager pwm = col.gameObject.GetComponent<PlayerWeaponManager>();

			if(pwm != null){
				activateWeapon();
			}

		}

		virtual protected void activateWeapon(){
			//polymorphic
		}
	}
}
