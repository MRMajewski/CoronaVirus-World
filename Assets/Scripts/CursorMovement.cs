using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    public float rotatingSpeed;
    private Quaternion toRotation;


    // Update is called once per frame
    void Update()
    {
        CursorRotating();
    }


    public void CursorRotating()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            toRotation = Quaternion.Euler(-90, -90, 90);
        //    transform.rotation = Quaternion.RotateTowards
        //   (transform.rotation, toRotation, Time.deltaTime * rotatingSpeed);
        }
            toRotation = Quaternion.Euler(-90, -90, 90);            
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            toRotation = Quaternion.Euler(90, -90, 90);
         //   transform.rotation = Quaternion.RotateTowards
        //     (transform.rotation, toRotation, Time.deltaTime * rotatingSpeed);
        }
         

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            toRotation = Quaternion.Euler(0, -90, 90);
      //      transform.rotation = Quaternion.RotateTowards
       //      (transform.rotation, toRotation, Time.deltaTime * rotatingSpeed);
        }
         

        if (Input.GetKey(KeyCode.RightArrow))
        {
            toRotation = Quaternion.Euler(-180, -90, 90);
      //      transform.rotation = Quaternion.RotateTowards
       //      (transform.rotation, toRotation, Time.deltaTime * rotatingSpeed);
        }

         
          transform.rotation = Quaternion.RotateTowards
           (transform.rotation, toRotation, Time.deltaTime * rotatingSpeed);

    }


}
