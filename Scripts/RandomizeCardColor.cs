using UnityEngine;
using UnityEngine.UI;
public class RandomizeCardColor : MonoBehaviour
{
    private Image image;

    public Color[] cardColors;

    void Start()
    {
        image = GetComponent<Image>();
        RandomizeColor();
    }

    void RandomizeColor()
    {
        if (cardColors.Length > 0)
        {
            // Get a random color from the cardColors array
            Color randomColor = cardColors[Random.Range(0, cardColors.Length)];
            image.color = randomColor;
        }
        else
        {
            Debug.LogError("No card colors defined in the RandomizeCardColor script.");
        }
    }
}
