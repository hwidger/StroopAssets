using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTextController : MonoBehaviour
{
    public Text textPrefab;
    public string[] colors = { "red", "blue", "green", "yellow" };

    void Start()
    {
        foreach (Transform card in transform)
        {
            Text newColorText = Instantiate(textPrefab, card);
            newColorText.text = colors[Random.Range(0, colors.Length)];
        }
    }
}
