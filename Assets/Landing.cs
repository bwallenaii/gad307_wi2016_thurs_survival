using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace CompleteProject{
	public class Landing : MonoBehaviour {

		public Button playBtn;
		public Button quitBtn;

		// Use this for initialization
		void Awake () {

			playBtn.GetComponent<Button> ().onClick.AddListener (() => {startGame();});
			quitBtn.GetComponent<Button> ().onClick.AddListener (() => {quitGame();});
		}

		private void startGame(){
			SceneManager.LoadScene (1);
		}

		private void quitGame(){
			Application.Quit ();
		}
	}
}