using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (logic.IsGameActive() && collision.gameObject.layer == 3) // Only add score if the game is active
        {
            logic.addScore(1);
        }
    }
}