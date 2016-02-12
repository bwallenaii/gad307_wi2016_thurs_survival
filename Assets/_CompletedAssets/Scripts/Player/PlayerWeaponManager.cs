using UnityEngine;
using System.Collections;


namespace CompleteProject{
	public class PlayerWeaponManager : MonoBehaviour {

		private const int NORMAL_DAMAGE = 20;
		private const int SPREAD_DAMAGE = 15;

		public GameObject leftBarrel;
		public GameObject centerBarrel;
		public GameObject rightBarrel;

		private PlayerShooting leftShot;
		private PlayerShooting centerShot;
		private PlayerShooting rightShot;

		private static PlayerWeaponManager player;

		// Use this for initialization
		void Awake () {
			player = this;

			leftShot = leftBarrel.GetComponent<PlayerShooting>();
			centerShot = centerBarrel.GetComponent<PlayerShooting>();
			rightShot = rightBarrel.GetComponent<PlayerShooting>();

			resetWeapon();
		}
		
		// Update is called once per frame
		void Update () {
		
		}

		private void resetWeapon(){

			leftShot.enabled = false;
			rightShot.enabled = false;

			centerShot.damagePerShot = NORMAL_DAMAGE;
		}

		public static void activateSpread(){
			player.enableSpread();
		}

		public void enableSpread(){

			leftShot.enabled = true;
			rightShot.enabled = true;

			leftShot.damagePerShot = SPREAD_DAMAGE;
			rightShot.damagePerShot = SPREAD_DAMAGE;
			centerShot.damagePerShot = SPREAD_DAMAGE;

		}
	}
}