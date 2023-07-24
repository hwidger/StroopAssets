using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCard : MonoBehaviour
{
    private SwipeEffect _swipeEffect;
    private GameObject _firstCard;

    // Start is called before the first frame update
    void Start()
    {
        _swipeEffect = FindObjectOfType<SwipeEffect>();
        _firstCard = _swipeEffect.gameObject;
        _swipeEffect.cardMoved += CardMovedFront;
        transform.localScale = new Vector3(x: 0.8f, y: 0.8f, z: 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = _firstCard.transform.localPosition.x;
        if (Mathf.Abs (distanceMoved)>0)
        {
            float step = Mathf.SmoothStep (from: 0.8f, to: 1, t:Mathf.Abs(distanceMoved)/(Screen.width/2));
            transform.localScale = new Vector3(x: step, y: step, z: step);
        }
    }

    void CardMovedFront()
    {
        gameObject.AddComponent<SwipeEffect>();
        Destroy(this);
    }
}
