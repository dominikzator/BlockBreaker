using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public Paddle paddle;
	public static bool hasStarted = false;
	public static int ballNumber = 0;
	
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		Ball.ballNumber++;
		//print(Ball.ballNumber);
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
		//audio.Play();
		
		//print(paddleToBallVector.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted)
		{
			//Lock the ball relative to the padde.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse press to launch.
			if(Input.GetMouseButtonDown(0))
			{
				//print ("Mouse Clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,10f);
			}
		}
		
		if((gameObject.transform.position.x< 0 || gameObject.transform.position.x > 16)
		||(gameObject.transform.position.y > 12 || gameObject.transform.position.y < - 0.5))
		{
			//Ball.ballNumber--;
			Destroy(gameObject);
		} 
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		//Vector2 tweak = new Vector2(Random.Range (0f,0.7f), Random.Range(0f,0.7f));
		//print (tweak);
		if(hasStarted)
		{
			GetComponent<AudioSource>().Play();
			//rigidbody2D.velocity += tweak;
			//rigidbody2D.velocity.Scale *=1.1;
			GetComponent<Rigidbody2D>().velocity *= 1.001f;
			print ( GetComponent<Rigidbody2D>().velocity);
			//print(rigidbody2D.velocity);
		}

		if (collision.gameObject.name == "Top Wall") {
			Rigidbody2D rig = this.GetComponent<Rigidbody2D> ();
			int randomInt = Random.Range (0, 2);
			Debug.Log (randomInt);
			if (randomInt == 0) {
				rig.AddForce (new Vector2 (-50f, 0f));
			} 
			else if (randomInt == 1) {
				rig.AddForce (new Vector2 (50f, 0f));
			}
		}
		
	}
	
	void Multiple()
	{
	
	}
	
	void OnDestroy() {
		Ball.ballNumber--;
	}
}
