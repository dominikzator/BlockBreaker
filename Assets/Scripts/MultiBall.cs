using UnityEngine;
using System.Collections;

public class MultiBall : MonoBehaviour {
	
	public Rigidbody2D rigidBody;
	public Ball ball;
	
	// Use this for initialization
	void Start () {
		rigidBody = this.GetComponent<Rigidbody2D>();		
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "Paddle")
		{
			ball = GameObject.FindObjectOfType<Ball>();	
			//GameObject firstBall = Instantiate(ball,ball.transform.position, Quaternion.identity) as GameObject;
			//firstBall.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,10f);
//GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;			
			Destroy(gameObject);
		}
		
	}
}
