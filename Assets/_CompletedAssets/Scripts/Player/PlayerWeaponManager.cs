using UnityEngine;
using System.Collections;


namespace CompleteProject{
	public class PlayerWeaponManager : MonoBehaviour {

		private const float WEAPON_TIME = 20;//in seconds
		private const int NORMAL_DAMAGE = 20;
		private const float NORMAL_ROF = 0.15f;
		private const int SPREAD_DAMAGE = 15;
		private const int HELEPHANT_GUN_DAMAGE = 450;
		private const float HELEPHANT_GUN_ROF = 0.5f;

		public GameObject leftBarrel;
		public GameObject centerBarrel;
		public GameObject rightBarrel;

		private PlayerShooting leftShot;
		private PlayerShooting centerShot;
		private PlayerShooting rightShot;

		private static PlayerWeaponManager player;
		private static float weaponTime = 0;

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
			if(!canGetWeapon){
				weaponTime -= Time.deltaTime;
			} else{
				resetWeapon();
			}
		}

		private void gotWeapon(){
			weaponTime = WEAPON_TIME;
		}

		private void resetWeapon(){
			leftShot.enabled = false;
			rightShot.enabled = false;

			centerShot.damagePerShot = NORMAL_DAMAGE;
			centerShot.timeBetweenBullets = NORMAL_ROF;
		}

		public static void activateSpread(){
			player.enableSpread();
		}

		public void enableSpread(){
			gotWeapon();
			leftShot.enabled = true;
			rightShot.enabled = true;

			leftShot.damagePerShot = SPREAD_DAMAGE;
			rightShot.damagePerShot = SPREAD_DAMAGE;
			centerShot.damagePerShot = SPREAD_DAMAGE;

		}

		public static void activateHelephantGun(){
			player.enableHelephantGun();
		}

		public void enableHelephantGun(){
			gotWeapon();
			centerShot.damagePerShot = HELEPHANT_GUN_DAMAGE;
			centerShot.timeBetweenBullets = HELEPHANT_GUN_ROF;
		}

		public static bool canGetWeapon{
			get{
				return weaponTime <= 0;
			}
		}
	}
}