using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CompleteProject
{
	public class Decoy : MonoBehaviour {

		private static List<Decoy> decoys = new List<Decoy>();
		const float DECOY_TIME = 5f;
		private float liveTime = 0;

		// Use this for initialization
		void Start () {
			decoys.Add(this);
		}
		
		// Update is called once per frame
		void Update () {
		
			liveTime += Time.deltaTime;

			if(liveTime >= DECOY_TIME){
				decoys.Remove(this);
				Destroy(gameObject);
			}

		}

		public static Vector3 closestDecoy(Vector3 pos){

			Vector3 closeDecoy = new Vector3(0, 900, 0);
			float closestDistance = 900;

			foreach(Decoy decoy in decoys){
				float curDist = Vector3.Distance(decoy.transform.position, pos);
				if(curDist < closestDistance){
					closestDistance = curDist;
					closeDecoy = decoy.transform.position;
				}
			}

			return closeDecoy;
		}

		public static void clearDecoys(){
			decoys.Clear();
		}
	}
}