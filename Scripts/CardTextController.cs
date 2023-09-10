using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTextController : MonoBehaviour
{
    public Text textPrefab;
    public Color[] colors; // Use Color type instead of string for colors

    void Start()
    {
        foreach (Transform card in transform)
        {
            Text newColorText = Instantiate(textPrefab, card);
            
            // Randomly set color
            newColorText.color = colors[Random.Range(0, colors.Length)];
            
            // Randomly set word
            string[] words = { "blue", "red", "green", "yellow" };
            newColorText.text = words[Random.Range(0, words.Length)];
        }
    }
}
