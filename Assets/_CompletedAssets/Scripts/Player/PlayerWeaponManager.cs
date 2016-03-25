using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace CompleteProject{
	public class PlayerWeaponManager : MonoBehaviour {

		private const float WEAPON_TIME = 20;//in seconds
		private const int NORMAL_DAMAGE = 20;
		private const float NORMAL_ROF = 0.15f;
		private const int SPREAD_DAMAGE = 15;
		private const int HELEPHANT_GUN_DAMAGE = 450;
		private const float HELEPHANT_GUN_ROF = 0.5f;

		public static int numDecoys = 0;
		public GameObject leftBarrel;
		public GameObject centerBarrel;
		public GameObject rightBarrel;
		public GameObject decoy;
		public Text numDecoyOutput;


		private PlayerShooting leftShot;
		private PlayerShooting centerShot;
		private PlayerShooting rightShot;

		private static PlayerWeaponManager player;
		private static float weaponTime = 0;

		// Use this for initialization
		void Awake () {
			Decoy.clearDecoys();
			player = this;

			leftShot = leftBarrel.GetComponent<PlayerShooting>();
			centerShot = centerBarrel.GetComponent<PlayerShooting>();
			rightShot = rightBarrel.GetComponent<PlayerShooting>();
			weaponTime = 0;
			resetWeapon();
		}
		
		// Update is called once per frame
		void Update () {
			numDecoyOutput.text = numDecoys.ToString();
			if(!canGetWeapon){
				weaponTime -= Time.deltaTime;
			} else{
				resetWeapon();
			}

			if(Input.GetButtonDown("Fire2") && numDecoys > 0){
				numDecoys--;
				Instantiate(decoy, 
					new Vector3(transform.position.x, 1, transform.position.z), 
					transform.rotation);
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

			leftShot.DisableEffects ();
			rightShot.DisableEffects ();
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