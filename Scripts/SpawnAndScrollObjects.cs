using UnityEngine;

public class SpawnAndScrollObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float scrollSpeed = 5f;
    public float leftBoundaryOffset = -10f;
    public float spawnInterval = 2f;

    private float nextSpawnTime;

    private RectTransform canvasRectTransform;

    void Start()
    {
        canvasRectTransform = GetComponent<RectTransform>(); // Reference to the Canvas's RectTransform
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
        GameObject newObject = Instantiate(objectPrefabs[randomIndex], canvasRectTransform);
        newObject.transform.localPosition = GetRandomSpawnPosition();

        Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * scrollSpeed;
        }
    }

    Vector2 GetRandomSpawnPosition()
    {
        float spawnY = Random.Range(canvasRectTransform.rect.height * 0.25f, canvasRectTransform.rect.height * 0.75f);
        return new Vector2(canvasRectTransform.rect.width + 10f, spawnY);
    }
}
