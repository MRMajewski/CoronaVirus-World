using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    public int vaccinePoints;

    public UIManager uiManager;


    // Start is called before the first frame update
    void Start()
    {
        InitGamePoints();
    }
    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        uiManager.UpdatePoints(points);
    }

    public void UseVaccine(int vaccineAmount)
    {
        vaccinePoints -= vaccineAmount;
        uiManager.UpdateVaccinePoints(vaccinePoints);
    }

    public void InitGamePoints()
    {
        points = 0;
        vaccinePoints = 5;
        uiManager.UpdatePoints(points);
        uiManager.UpdateVaccinePoints(vaccinePoints);

    }

    
}
