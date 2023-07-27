// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class SwipeBehavior : MonoBehaviour
// {

//     private Vector3 startPos;
//     private bool isDraffing = false;
//     private float swipeThreshold = 100f;

//     public float flyOffSpeed = 1000f;
//     public RectTransform cardRectTransform;


//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             startPos = Input.mousePosition;
//             isDraffing = true;
//         }
//         else if (Input.GetMouseButtonUp(0))
//         {
//             float swipeDistance = (Input.mousePosition - startPos).magnitude;

//             if (isDragging && swipeDistance > swipeDistanceThreshold)
//             {
//                 Vector3 direction = (Input.mousePosition - startPos).normalized;
//                 SwipeCard(direction);
//             }

//             isDragging = false;
//         }
//     }

//     void SwipeCard(Vector3 swipeDirection)
//     {
//         if (swipeDirection.x > 0)
//         {
//             Debug.Log("Swiped right!");
//             FlyOff(Vector2.right);
//         }
//         else if (swipeDirection.x < 0)
//         {
//             Debug.Log("Swiped left!");
//             FlyOff(Vector2.left);
//         }
//         else if (swipeDirection.y > 0)
//         {
//             Debug.Log("Swiped up!");
//             FlyOff(Vector2.up);
//         }
//         else if (swipeDirection.y < 0)
//         {
//             Debug.Log("Swiped down");
//             FlyOff(Vector2.down);
//         }
//     }

//     void FlyOff(Vector2 direction)
//     {

//     }
// }
