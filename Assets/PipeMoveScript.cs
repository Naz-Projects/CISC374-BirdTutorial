using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -40;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (!logic.IsGameActive()) return; // Don't move pipes if the game isn't active

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}