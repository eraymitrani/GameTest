using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Sprite[] playerSprites;
    public int currentSprite;
    public float pitFall;
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public LevelManager levelManager;
    public float groundCheckRad;
    public LayerMask whatIsGround;
    private bool isGround;
    private GameObject pauseObject;

    void Awake()
    {
        playerSprites = Resources.LoadAll<Sprite>("Sprites");
    }
	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        pauseObject = GameObject.FindGameObjectWithTag("ShowOnPause");
        pauseObject.SetActive(false);
        Time.timeScale = 1;
        currentSprite = 1;
    }
	void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, whatIsGround);
    }
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody2D>().position.y < pitFall)
        {
            if(currentSprite == 1)
            {
                Debug.Log("Game Over");
                Application.Quit();
            }
            levelManager.RespawnPlayer();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<SpriteRenderer>().sprite = playerSprites[--currentSprite];
            jumpHeight -= 5;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseObject.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                pauseObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
