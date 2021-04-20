using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    public GameObject targetObject;
    public GameObject world;

    public GameObject Land;

    public float worldRadius = 50f;

    [ContextMenu("SpawnTarget")]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnTarget();
    }

    public void SpawnTarget()
    {
        Vector3 targetPos = Random.onUnitSphere* worldRadius;

      

        if (CanSpawn(targetPos))
        {
            Vector3 direction = targetPos - Vector3.zero;

            Quaternion targetRot = Quaternion.LookRotation(direction);

            GameObject newTarget = Instantiate(targetObject, targetPos, targetRot, world.transform);

            PopUpTween(newTarget);
        }

    }


    private void PopUpTween(GameObject target)
    {
        LeanTween.scale(target, Vector3.zero, 0f);
        LeanTween.scale(target, new Vector3(2f,2f,2f), 2f);
        LeanTween.rotateAroundLocal(target, Vector3.forward, 270f, 2f);
    }


    private bool CanSpawn(Vector3 pos)
    {
        if ((Land.GetComponent<MeshCollider>().bounds.Contains(pos)))
            return true;
        else return false;

        
    }
}
