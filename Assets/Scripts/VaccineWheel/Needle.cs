using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public GameObject Wheel;

    public string prizeType;

    public int PointsGained;

    public WheelManager wheelManager;


    private void Update()
    {
        Wheel.GetComponent<Wheel>().currentRotation = Wheel.transform.rotation;

        if (Wheel.GetComponent<Wheel>().isSpinning && Wheel.GetComponent<Wheel>().storedRotation == Wheel.GetComponent<Wheel>().currentRotation)
        {
            Wheel.GetComponent<Wheel>().isSpinning = false;
            Wheel.GetComponent<Wheel>().storedRotation = Wheel.transform.rotation;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
     if(Wheel.GetComponent<Wheel>().isSpinning)

        {
            Debug.Log("Powinno zadziałać o tu");
            Debug.Log(collision.gameObject.tag);
            prizeType = collision.gameObject.tag;

            Wheel.GetComponent<Wheel>().isSpinning = false;

            SetAmountOfPoints();
            wheelManager.WasSpinned =true;

        }
    }

    public int GetAmountOfPoints()
    {
        switch(prizeType)
        {

            case "BigPrize":
                PointsGained = 3;
                break;

            case "MedPrize":
                PointsGained = 2;
                break;

            case "SmallPrize":
                PointsGained =1;
                break;

            default:
                break;         
        }
        return PointsGained;
    }


    public void SetAmountOfPoints()
    {
        int pointsGained = 0;
        switch (prizeType)
        {

            case "BigPrize":
                pointsGained = 3;
                break;

            case "MedPrize":
                pointsGained = 2;
                break;

            case "SmallPrize":
                pointsGained = 1;
                break;

            default:
                break;
        }
        PointsGained=pointsGained;
    }




}
