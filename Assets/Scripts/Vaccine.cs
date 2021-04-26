using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{

    public GameManager manager;

    public int vaccinePoints;


    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void addVaccinePoints()
    {
        manager.vaccinePoints += vaccinePoints;
    }

    public void decreaseVaccinePoints()
    {
        manager.vaccinePoints -= vaccinePoints;
    }


    public void DestroyVaccine()
    {

     LeanTween.scale(this.gameObject, Vector3.zero, 1.5f).setEaseOutSine();

        Destroy(this.gameObject, 1.5f);
    }

}
