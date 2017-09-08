using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    private PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.currentSprite < 3)
        {
            player.GetComponent<SpriteRenderer>().sprite = player.playerSprites[++player.currentSprite];
            player.jumpHeight += 5;
        }
        Destroy(this.gameObject);
    }
}
