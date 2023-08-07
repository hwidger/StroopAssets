using UnityEngine;

public class ScrollingImage : MonoBehaviour
{
    public float scrollSpeed = 5f; // Adjust the speed as needed
    public float leftBoundary = -10f; // Set the left boundary where the image will be destroyed

    void Start()
    {
        // Set the initial position of the image in the upper half of the screen
        Vector3 initialPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 10f, Screen.height * 0.75f, 10f));
        transform.position = initialPosition;
    }

    void Update()
    {
        // Move the image to the left based on the scroll speed and time
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Check if the image has crossed the left boundary
        if (transform.position.x <= leftBoundary)
        {
            // Destroy the image when it crosses the left boundary
            Destroy(gameObject);
        }
    }
}
