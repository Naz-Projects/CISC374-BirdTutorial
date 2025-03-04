using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud; // Assign your cloud prefab here
    public float spawnRate = 2f; // Time between cloud spawns
    public float heightOffset = 3f; // Vertical range for cloud spawns
    public float spawnX = 24f; // X position where clouds spawn
    public float despawnX = -10f; // X position where clouds despawn 

    private float timer = 0;

    void Update()
    {
        // Spawn clouds at interval
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnCloud();
            timer = 0;
        }

        // Dspawn clouds that move off-screen
        DespawnClouds();
    }

    void SpawnCloud()
    {
        // Calculate random Y position within the height offset
        float randomY = Random.Range(transform.position.y - heightOffset, transform.position.y + heightOffset);

        // Spawn the cloud at the fixed X position and random Y position
        Instantiate(cloud, new Vector3(spawnX, randomY, 0), Quaternion.identity);
    }

    void DespawnClouds()
    {
        // find all clouds in the scene
        GameObject[] clouds = GameObject.FindGameObjectsWithTag("Cloud"); 

        // despawn clouds that are off-screen
        foreach (GameObject cloud in clouds)
        {
            if (cloud.transform.position.x < despawnX)
            {
                Destroy(cloud);
            }
        }
    }
}