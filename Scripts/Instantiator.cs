using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject cardPrefab;
    public Color[] cardColors; //Define the card colors in the Unity editor

    void InstantiateCard()
    {
        GameObject newCard = Instantiate(cardPrefab, transform, false);
        newCard.transform.SetAsFirstSibling();
    
        // Access the RandomizeCardColor script on the newCard and set its cardColors property
        RandomizeCardColor randomizeCardColor = newCard.GetComponent<RandomizeCardColor>();
        if (randomizeCardColor != null)
        {
            randomizeCardColor.cardColors = cardColors;
        }
        else
        {
            Debug.LogError("RandomizeCardColor script not found on the cardPrefab or newCard.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < 2)
        {
            InstantiateCard();
        }
    }
}
