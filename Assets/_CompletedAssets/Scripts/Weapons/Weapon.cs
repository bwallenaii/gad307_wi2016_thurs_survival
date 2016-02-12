using UnityEngine;
using System.Collections;

namespace CompleteProject{
	public class Weapon : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			gameObject.GetComponent<MeshRenderer>().enabled = PlayerWeaponManager.canGetWeapon;
			gameObject.GetComponent<CapsuleCollider>().enabled = PlayerWeaponManager.canGetWeapon;
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
