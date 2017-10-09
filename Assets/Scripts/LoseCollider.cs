using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	public bool godMode;

	void OnTriggerEnter2D (Collider2D trigger)
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		//print ("Trigger");
		if(!godMode)
		{
			if(Ball.ballNumber > 1)
			{	
				Ball.ballNumber--;
				print(Ball.ballNumber);
				Destroy(gameObject);
			}
			else if (Ball.ballNumber == 1)
			{
				//print ("test, ballNumber == 1");
				levelManager.LoadLevel("Lose Screen");
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		print ("Collision");
	}
}
