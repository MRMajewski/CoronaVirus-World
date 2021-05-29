using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public LongClickButton butonScript;

    public Quaternion storedRotation;
    public Quaternion currentRotation;

    public bool isSpinning = false;

    // Start is called before the first frame update
    void Start()
    {
      //  RandomizeWheelRotation();


    }

    public void RandomizeWheelRotation()
    {
        this.gameObject.transform.Rotate(0, 0, Random.Range(0, 360f));
    }

    void Update()
    {
      //  if (transform.hasChanged)
      //  {
         //   print("The transform has changed!");
      //      transform.hasChanged = false;
      //;  }
    }

    //public void SpinWheel(float percentAmount, float rotateParameter)
    //{
    //    LeanTween.rotateAroundLocal(this.gameObject, Vector3.forward, percentAmount * rotateParameter, 8f * percentAmount).setEaseOutExpo();
       
    //}

    public void SpinWheel()
    {
        storedRotation = transform.rotation;
        LeanTween.rotateAroundLocal(this.gameObject, Vector3.forward, butonScript.percentAmount * butonScript.rotateParameter, 8f * butonScript.percentAmount).setEaseOutExpo();
        isSpinning = true;


      //  this.transform.Rotate(Vector3.forward, butonScript.percentAmount * butonScript.rotateParameter);

    }

    IEnumerator SpinWheelCoroutine()
    {
        storedRotation = transform.rotation;
        LeanTween.rotateAroundLocal(this.gameObject, Vector3.forward, butonScript.percentAmount * butonScript.rotateParameter, 8f * butonScript.percentAmount).setEaseOutExpo();
        butonScript.gameObject.SetActive(false);
        yield return new WaitForSeconds(8f * butonScript.percentAmount);
        butonScript.gameObject.SetActive(true);
        butonScript.WasSpinned = false;
        Debug.Log("Korutyna koniec");
        isSpinning = true;
    }

    public void SpinWheelCor()
    {
        StartCoroutine(SpinWheelCoroutine());
    }



}
