using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direction);

    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private bool IsMobile;

    public float Direction => _swipeDelta.x;

    private void Start()
    {
        IsMobile = Application.isMobilePlatform;
    }

    private void Update()
    {

        if (!IsMobile)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _tapPosition = Input.mousePosition;
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                _swipeDelta.x = Input.mousePosition.x - _tapPosition.x;
            }
            else
            {
                _swipeDelta = Vector2.zero;
            }

            _tapPosition = Input.mousePosition;
        }
        else
        {

            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                 _tapPosition = Input.GetTouch(0).position;
            }
            else if (TouchPhase.Moved > 0)
            {
                _swipeDelta.x = Input.GetTouch(0).position.x - _tapPosition.x;
            }

            _tapPosition = Input.GetTouch(0).position;
        }
    }
}
