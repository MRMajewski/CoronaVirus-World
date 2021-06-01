using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{

    private Ray ray;
    public Camera camera;

    public Collider selection;
    public CursorMovement cursor;
   // public Transform selection;

    public float rayLenght = 20f;

    [Header("Checks")]
    public bool isVirus = false;
    public bool isVaccine = false;

    public GameManager manager;

    public WheelManager wheelManager;

    // Update is called once per frame
    void Update()
    {
        RaycastCheck();
    }

    public void RaycastCheck()
    {
        ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayLenght, Color.red);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, rayLenght))
        {
           //   selection = hitInfo.transform;
            selection = hitInfo.collider;
            {
                if (selection.tag == "Virus" && manager.vaccinePoints>0)
                {

                    Debug.Log("Trafiony wirus");
                    var virus = selection.GetComponent<Virus>();

                    selection.GetComponent<Collider>().enabled = false;
                    // virus.addPoints();
                    manager.AddPoints(virus.Points);                 
                    manager.UseVaccine(1);
                    virus.DestroyTarget();


                }
                if (selection.tag == "Vaccine")
                {


                    Debug.Log("Trafione vacccine");
                    var vaccine = selection.GetComponent<Vaccine>();

                    selection.GetComponent<Collider>().enabled = false;                  
                    wheelManager.activateWheelPanel();                    
                    vaccine.DestroyVaccine();

                }

                else
                {
                    selection = null;
                    ResetChecks();
                }
            }
        }
    }


    private void ResetChecks()
    {
        isVirus = false;
        isVaccine = false;
    }


}
