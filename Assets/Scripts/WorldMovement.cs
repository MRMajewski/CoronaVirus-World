using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed;


    [Header("Mobile Parameters")]

    public Vector2 pressPosition;
    public Vector2 realesePosition;

    public bool detectSwipeOnlyAfterRelease = false;
    // Start is called before the first frame update

    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
      //  UpdateSwipePC();


          UpdateMovement();
     //   UpdateMovementMobile();
    }

    //private void UpdateMovementMobile()
    //{
    //    foreach (Touch touch in Input.touches)
    //    {
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            fingerUp = touch.position;
    //            fingerDown = touch.position;
    //        }

    //        //Detects Swipe while finger is still moving
    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            if (!detectSwipeOnlyAfterRelease)
    //            {
    //                fingerDown = touch.position;
    //                checkSwipe();
    //            }
    //        }

    //        //Detects swipe after finger is released
    //        if (touch.phase == TouchPhase.Ended)
    //        {
    //            fingerDown = touch.position;
    //            checkSwipe();
    //        }
    //    }
    //}

    //private void checkSwipe()
    //{
    //    Vector3 swipeDirection = fingerDown - fingerUp;

    //    rigidbody.AddTorque(swipeDirection * speed);
    //}


    private void UpdateSwipePC()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pressPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            if(Input.GetMouseButtonUp(0))
            {
                realesePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                direction = realesePosition - pressPosition;

                rigidbody.AddTorque(direction * speed);

                pressPosition = Vector3.zero;
                realesePosition = Vector3.zero;
            }

        }

    }


    private void UpdateMovement()
    {
        var direction = Vector3.zero; // zmienna z kierunkiem

        if (Input.GetKey(KeyCode.UpArrow))
            direction += Vector3.left;

        if (Input.GetKey(KeyCode.DownArrow))
            direction += Vector3.right;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction += Vector3.down;

        if (Input.GetKey(KeyCode.RightArrow))
            direction += Vector3.up;

        rigidbody.AddTorque(direction * speed);
    }

}
