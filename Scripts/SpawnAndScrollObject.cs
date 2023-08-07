using UnityEngine;

public class SpawnAndScrollObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Assign your prefabs in the Inspector
    public float scrollSpeed = 5f; // Adjust the speed as needed
    public float leftBoundary = -10f; // Set the left boundary where objects will be destroyed
    public float spawnInterval = 2f; // Time interval between object spawns

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject newObject = Instantiate(objectPrefabs[randomIndex], transform);
        newObject.transform.position = GetRandomSpawnPosition();

        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * scrollSpeed;
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float spawnY = Random.Range(Screen.height * 0.25f, Screen.height * 0.75f);
        Vector3 screenPosition = new Vector3(Screen.width + 10f, spawnY, 10f);
        return Camera.main.ScreenToWorldPoint(screenPosition);
    }
}
