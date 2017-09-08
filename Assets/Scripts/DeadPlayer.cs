using UnityEngine;
using System.Collections;

public class DeadPlayer : MonoBehaviour {

    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody2D>().position.y < -1)
        {
            levelManager.RespawnPlayer();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            levelManager.RespawnPlayer();
        }
    }
}
