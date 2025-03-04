using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public LogicScript logic;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool birdIsAlive = true;

    // Reference to the AudioSource component
    public AudioSource flapSound;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        flapSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Only allow flapping if the game is active and the bird is alive
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && logic.IsGameActive())
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;

            if (flapSound != null && flapSound.clip != null)
            {
                flapSound.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (logic.IsGameActive()) // Only trigger game over if the game is active
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }
}