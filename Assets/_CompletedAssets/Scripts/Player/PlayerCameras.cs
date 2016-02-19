using UnityEngine;
using System.Collections;

namespace CompleteProject {
	public class PlayerCameras : MonoBehaviour {

		public const string CEILING_CAMERA = "ceilingCamera";
		public const string HEAD_CAMERA = "headCamera";

		const int CEILING_CAMERA_NUMBER = 0;
		const int HEAD_CAMERA_NUMBER = 1;

		public Camera ceilingCam;
		public Camera headCam;

		private static int cameraNum = CEILING_CAMERA_NUMBER;

		// Use this for initialization
		void Start () {
			ceilingCam.enabled = true;
			headCam.enabled = false;
		}
		
		// Update is called once per frame
		void Update () {
			if(Input.GetButtonDown("Fire3")){
				if(cameraNum == CEILING_CAMERA_NUMBER){ //turn on the head cam
					cameraNum = HEAD_CAMERA_NUMBER;
					ceilingCam.enabled = false;
					headCam.enabled = true;
				} else if(cameraNum == HEAD_CAMERA_NUMBER){ //turn on the ceiling cam
					cameraNum = CEILING_CAMERA_NUMBER;
					ceilingCam.enabled = true;
					headCam.enabled = false;
				}
			}
		}

		public static string cameraName{

			get{
				switch(cameraNum){
				case CEILING_CAMERA_NUMBER:
					return CEILING_CAMERA;
					break;
				case HEAD_CAMERA_NUMBER:
					return HEAD_CAMERA;
					break;

				default:
					return CEILING_CAMERA;
				}
			}

		}
	}
}