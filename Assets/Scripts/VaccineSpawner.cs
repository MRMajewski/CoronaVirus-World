using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineSpawner : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject VaccineList;

    public GameObject Land;

    public float worldRadius = 50f;


    public void SpawnVaccine()
    {
        Vector3 targetPos = Random.onUnitSphere * worldRadius;

        if (CanSpawnVaccine(targetPos))
        {
            Vector3 direction = targetPos - Vector3.zero;

            Quaternion targetRot = Quaternion.LookRotation(direction);

            GameObject newTarget = Instantiate(targetObject, targetPos, targetRot, VaccineList.transform);

            PopUpTween(newTarget);
        }
    }

    public void InitialSpawnVaccine(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnVaccine();
        }
    }


    private void PopUpTween(GameObject target)
    {
        LeanTween.scale(target, Vector3.zero, 0f);
        LeanTween.scale(target, new Vector3(5f, 5f, 5f), 2f);
        LeanTween.rotateAroundLocal(target, Vector3.forward, 270f, 2f);
    }

    private bool CanSpawnVaccine(Vector3 pos)
    {
        if ((Land.GetComponent<MeshCollider>().bounds.Contains(pos)))
            return true;
        else return false;


    }
}
