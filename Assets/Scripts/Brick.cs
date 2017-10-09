using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
		
	private int timesHit;
	private LevelManager levelmanager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable  = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable)
		{
			breakableCount++;
			//print (breakableCount);
		}
		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		AudioSource.PlayClipAtPoint(crack,transform.position,0.15f);
		if(isBreakable)
		{
			HandleHits();
		}
	}
	
	void HandleHits()
	{
		timesHit++;
		//SimulateWin();
		int maxHits = hitSprites.Length + 1;
		if(timesHit>=maxHits)
		{
			breakableCount--;
			//print (breakableCount);
			levelmanager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
			
		}
		else
		{
			LoadSprites();
		}
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;	
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Brick Sprite is missing");
		}
		
	}
	
	//TODO Remove this method once we can actually win!
	void SimulateWin()
	{
		levelmanager.LoadNextLevel();
	}
	
}
