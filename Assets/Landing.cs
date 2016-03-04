using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject{
	public class Landing : MonoBehaviour {

		public Button playBtn;
		public Button quitBtn;

		public Toggle spreadToggle;
		public Toggle helephantGunToggle;

		// Use this for initialization
		void Awake () {
			spreadToggle.isOn = SpreadWeapon.spreadInGame;
			helephantGunToggle.isOn = HelephanGun.helephantGunInGame;

			playBtn.GetComponent<Button> ().onClick.AddListener (() => {startGame();});
			quitBtn.GetComponent<Button> ().onClick.AddListener (() => {quitGame();});
		}

		private void startGame(){
			SpreadWeapon.spreadInGame = spreadToggle.isOn;
			HelephanGun.helephantGunInGame = helephantGunToggle.isOn;
			SceneManager.LoadScene (1);
		}

		private void quitGame(){
			Application.Quit ();
		}
	}
}