using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int points;

    public int vaccinePoints;

    public UIManager uiManager;

    public VirusSpawner virusSpawner;

    public VaccineSpawner vaccineSpawner;

    [Header("Starting parameters")]
    public int onStartVirusAmount;
    public int onStartVaccineAmount;

    [Header("SpawningParameters")]
    public bool IsSpawningVirus = true;
    public bool IsSpawningVaccine = true;
    public int VirusRefreshTime;
    public int VaccineRefreshTime;

    public float VaccineProductionParameter;
    public float VirusSpreadingTimeParameter;


    // Start is called before the first frame update
    void Start()
    {
        InitGamePoints();
        virusSpawner.InitialSpawnVirus(onStartVirusAmount);
        vaccineSpawner.InitialSpawnVaccine(onStartVaccineAmount);
        StartCoroutine(VirusSpawnCoroutine());
        StartCoroutine(VaccineSpawnCoroutine());
    }

    IEnumerator VirusSpawnCoroutine()
    {
        yield return new WaitForSeconds(4f);

        while (IsSpawningVirus)
        {
            virusSpawner.SpawnVirus();
            VirusSpreadingTimeParameter = virusSpawner.VirusList.GetComponentsInChildren<Transform>().Length*0.1f;
            if (VirusSpreadingTimeParameter >= VirusRefreshTime)
                VirusSpreadingTimeParameter = 3;
            yield return new WaitForSeconds(VirusRefreshTime - VirusSpreadingTimeParameter);
        }

    }

    IEnumerator VaccineSpawnCoroutine()
    {
        yield return new WaitForSeconds(6f);

        while (IsSpawningVaccine)
        {
            vaccineSpawner.SpawnVaccine();
            VaccineProductionParameter = vaccineSpawner.VaccineList.GetComponentsInChildren<Transform>().Length * 0.25f;
            if (VaccineProductionParameter >= VaccineRefreshTime)
                VaccineProductionParameter = 4;
            yield return new WaitForSeconds(VaccineRefreshTime-VaccineProductionParameter);
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


    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
