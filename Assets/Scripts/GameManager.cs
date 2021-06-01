using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    public int vaccinePoints;

    public UIManager uiManager;

    public VirusSpawnTest virusSpawner;
    public VaccineSpawner vaccineSpawner;

    [Header("Starting parameters")]
    public int onStartVirusAmount;
    public int onStartVaccineAmount;

    [Header("SpawningParameters")]
    public bool IsSpawningVirus = true;
    public bool IsSpawningVaccine = true;
    public int VirusRefreshTime;
    public int VaccineRefreshTime;


    // Start is called before the first frame update
    void Start()
    {
        InitGamePoints();
        virusSpawner.InitialSpawnTarget(onStartVirusAmount);
        vaccineSpawner.InitialSpawnVaccine(onStartVaccineAmount);
        StartCoroutine(VirusSpawnCoroutine());
        StartCoroutine(VaccineSpawnCoroutine());
    }

    IEnumerator VirusSpawnCoroutine()
    {
        yield return new WaitForSeconds(4f);

        while (IsSpawningVirus)
        {
            virusSpawner.SpawnTarget();
            Debug.Log("Spawned Virus");
            yield return new WaitForSeconds(VirusRefreshTime);
        }

    }

    IEnumerator VaccineSpawnCoroutine()
    {
        yield return new WaitForSeconds(5f);

        while (IsSpawningVaccine)
        {
            vaccineSpawner.SpawnVaccine();
            Debug.Log("Spawned Vaccine");
            yield return new WaitForSeconds(VaccineRefreshTime);
        }

    }






    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        uiManager.UpdatePoints(points);
    }

    public void AddVaccinePoints(int addedPoints)
    {
        vaccinePoints += addedPoints;
        uiManager.UpdateVaccinePoints(vaccinePoints);
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
