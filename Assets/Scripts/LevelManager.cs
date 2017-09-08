using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    private PlayerController player;
    
	// Use this for initialization

	void Start () {
        player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void RespawnPlayer() 
    {

        Debug.Log("Respawn");
        player.transform.position = new Vector3(player.transform.position.x, 10);
    
    }
}
