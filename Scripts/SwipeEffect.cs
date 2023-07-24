using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Vector3 _initialPosition;
    private float _distanceMovedHorizontal;
    private float _distanceMovedVertical;
    private bool _swipeLeft = false;
    private bool _swipeRight = false;
    private bool _swipeUp = false;
    private bool _swipeDown = false;


    public event Action cardMoved;

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x+eventData.delta.x,
            transform.localPosition.y+eventData.delta.y);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialPosition = transform.localPosition;
        Debug.Log("Initial touch position: " + _initialPosition);
    }

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
    //    if (_distanceMoved < 0.4 * Screen.width)
    //    {
    //        transform.localPosition = _initialPosition;
    //    }
    //    else
    //    {
    //        if (transform.localPosition.x > _initialPosition.x)
    //        {
    //            _swipeLeft = false;

    //        }
    //        else
    //        {
    //            _swipeLeft = true;
    //        }
    //        StartCoroutine(MovedCard());
    //    }
    //}

    public void OnEndDrag(PointerEventData eventData)
    {
        _distanceMovedHorizontal = Mathf.Abs(transform.localPosition.x - _initialPosition.x);
        _distanceMovedVertical = Mathf.Abs(transform.localPosition.y - _initialPosition.y);

        if(_distanceMovedHorizontal < (0.1 * Screen.width) && _distanceMovedVertical < (0.1 * Screen.width))
        {
            transform.localPosition = _initialPosition;
            Debug.Log("Snapped");
            
            //Debug.Log("Screen Width:" + Screen.width);
            //Debug.Log("Screen Height" + Screen.height);

            //Debug.Log("Distance moved Horizontal" + _distanceMovedHorizontal);
            //Debug.Log("Distance moved Vertical" + _distanceMovedVertical);


        }
        else
        {
            // Card swipe off screen based off of direction && transform.localPosition.y > -0.5 && transform.localPosition.y < 0.5
            if (transform.localPosition.x > _initialPosition.x)
            {
                _swipeRight = true;
                Debug.Log("SwipeRight");
            }
            else if (transform.localPosition.x < _initialPosition.x)
            {
                _swipeLeft = true;
                Debug.Log("SwipeLeft");

            }
            else if (transform.localPosition.y > _initialPosition.y)
            {
                _swipeUp = true;
                Debug.Log("SwipeUp");

            }
            else if (transform.localPosition.y < _initialPosition.y)
            {
                _swipeDown = true;
                Debug.Log("SwipeDown");

            }
            else
            {
                Debug.Log("No Swipe detected");
            }
            cardMoved?.Invoke();
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while (GetComponent<Image>().color != new Color(1, 1, 1, 0))
        {
            time += Time.deltaTime;
            if (_swipeLeft)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x-Screen.width,time),transform.localPosition.y,0);

            }
            else if (_swipeRight)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
                    transform.localPosition.x+Screen.width,time),transform.localPosition.y,0);

            }
            else if (_swipeUp)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 
                    Mathf.SmoothStep(transform.localPosition.y, transform.localPosition.y + Screen.width,time), 0);

            }
            else if (_swipeDown)
            {
                transform.localPosition = new Vector3(transform.localPosition.x,
                    Mathf.SmoothStep(transform.localPosition.y, transform.localPosition.y - Screen.width, time), 0);

            }
            GetComponent<Image>().color = new Color(1,1,1,Mathf.SmoothStep(1,0,4*time));
            yield return null;
        }
        Debug.Log("THIS WORKED");
        Destroy(gameObject);
    }
}
