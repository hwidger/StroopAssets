using UnityEngine;
using UnityEngine.UI;
public class RandomizeCardColor : MonoBehaviour
{
    private Image image;
    private Text text;

    public Color[] cardColors;
    public string[] cardWords; //Array of colors

    void Start()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<text>(); 
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
