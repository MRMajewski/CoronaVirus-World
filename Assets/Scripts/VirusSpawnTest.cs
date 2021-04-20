using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawnTest : MonoBehaviour
{

    public GameObject virusObject;

    public GameObject VirusList;


    public bool isPosOk;

    public Vector3 pos;

    public float worldRadius = 50f;
    // Start is called before the first frame update
    void Start()
    {
        InitialSpawnTarget(4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnTarget();

    }

    private void SpawnTarget()
    {
        // Vector3 targetPos = Random.onUnitSphere * worldRadius;

        Vector3 targetPos = setPosition();

            Vector3 direction = targetPos - Vector3.zero;

            Quaternion targetRot = Quaternion.LookRotation(direction);

            GameObject newTarget = Instantiate(virusObject, targetPos, targetRot, VirusList.transform);

            PopUpTween(newTarget);
        
    }

    private void InitialSpawnTarget(int amount)
    {
        for (int i = 0; i < amount + 1; i++)
        {
            Vector3 targetPos = Random.onUnitSphere * worldRadius;

            Vector3 direction = targetPos - Vector3.zero;

            Quaternion targetRot = Quaternion.LookRotation(direction);

            GameObject newTarget = Instantiate(virusObject, targetPos, targetRot, VirusList.transform);

            PopUpTween(newTarget);
        }
    }


    private bool CanSpawn(Vector3 pos)
    {
        if ((this.GetComponent<SphereCollider>().bounds.Contains(pos)))
            return true;
        else return false;
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

