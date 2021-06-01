using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    public GameObject virusObject;

    public GameObject VirusList;


    public bool isPosOk;

    public Vector3 pos;

    public float worldRadius = 50f;

    [ContextMenu("SpawnVirus")]
    [ContextMenu("InitialSpawnVirus(2)")]


    public void SpawnVirus()
    {

        Vector3 targetPos = setPosition();

            Vector3 direction = targetPos - Vector3.zero;

            Quaternion targetRot = Quaternion.LookRotation(direction);

            GameObject newTarget = Instantiate(virusObject, targetPos, targetRot, VirusList.transform);

            PopUpTween(newTarget);
        
    }

    public void Test()
    {
        SpawnVirus();
    }

    public void InitialSpawnVirus(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnVirus();
        }
    }

    //DZIAŁA  XD
    private Vector3 setPosition()
    {
        SphereCollider[] colliders;
        colliders = VirusList.GetComponentsInChildren<SphereCollider>();

        do
        {
            pos = Random.onUnitSphere * worldRadius;

            foreach (SphereCollider collider in colliders)

            {
                if(collider.bounds.Contains(pos))
                
                    isPosOk = true;
                    else isPosOk = false;               
            }
        }

        while (isPosOk);

        return pos;
    }

    private void PopUpTween(GameObject target)
    {
        LeanTween.scale(target, Vector3.zero, 0f);
        LeanTween.scale(target, new Vector3(2f, 2f, 2f), 2f);
        LeanTween.rotateAroundLocal(target, Vector3.forward, 270f, 2f);
    }
}

