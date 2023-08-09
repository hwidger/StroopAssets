using UnityEngine;

public class SpawnAndScrollObjects : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float scrollSpeed = 5f;
    public float leftBoundaryOffset = -10f;
    public float leftBoundary = -10f;
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
        // Will need to revisit these values when game screen is reactive
        float spawnY = ((canvasRectTransform.rect.height / 2) - 350);
        float spawnX = ((canvasRectTransform.rect.width / 2) - 75);
        Debug.Log("spawnY" + spawnY);
        Debug.Log("spawnX" + spawnX);
        return new Vector2(spawnX, spawnY);
    }
}
