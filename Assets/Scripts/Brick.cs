using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public GameObject smoke;
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int bricksRemaining = 0;
  
    private int timesHit;                       //how many times was this brick hit
    private LevelManager levelmanager;
    private bool isBreakable;
    

    // Use this for initialization
    void Start () {
        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");

       

        if (isBreakable)
        {
            bricksRemaining++;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(isBreakable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            bricksRemaining--;
            levelmanager.BrickDestroyed();
           
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            
            ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    //TODO this is temporary
    void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite is missing!");
        }
    }

}
