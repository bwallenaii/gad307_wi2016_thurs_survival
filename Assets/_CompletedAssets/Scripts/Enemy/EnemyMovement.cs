using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class EnemyMovement : MonoBehaviour
	{
		Transform player;               // Reference to the player's position.
		PlayerHealth playerHealth;      // Reference to the player's health.
		EnemyHealth enemyHealth;        // Reference to this enemy's health.
		NavMeshAgent nav;               // Reference to the nav mesh agent.

		float hearingDistance = 5f;
		float loudHearingDistance = 15f;
		Vector3 targetLocation;

		void Awake ()
		{
			// Set up the references.
			player = GameObject.FindGameObjectWithTag ("Player").transform;
			playerHealth = player.GetComponent <PlayerHealth> ();
			enemyHealth = GetComponent <EnemyHealth> ();
			nav = GetComponent <NavMeshAgent> ();
			randomLocation();
		}


		void Update ()
		{
			// If the enemy and the player have health left...
			if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
			{
				// ... set the destination of the nav mesh agent to the player.
				//nav.SetDestination (player.position);

				float playerDistance = Vector3.Distance(transform.position, player.position); //get my distance from player

				//check if can hear player
				if((playerDistance < hearingDistance) || (Input.GetButton ("Fire1") && playerDistance < loudHearingDistance)){
					targetLocation = player.position; //CHARGE!!!
				} else if(Vector3.Distance(transform.position, targetLocation) <= 1 ){//check if need new position
					randomLocation();//get a new random location
				}

				nav.SetDestination (targetLocation);
			}
			// Otherwise...
			else
			{
				// ... disable the nav mesh agent.
				nav.enabled = false;
			}
		}

		private void randomLocation(){
			targetLocation = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
		}
	}
}