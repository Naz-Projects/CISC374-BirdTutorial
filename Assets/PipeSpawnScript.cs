using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1;
    public float heightOffset = 8;

    private float timer = 0;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (!logic.IsGameActive()) return; // Don't spawn pipes if the game isn't active

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x + 2, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}