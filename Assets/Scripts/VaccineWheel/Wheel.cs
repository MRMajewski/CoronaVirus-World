using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public LongClickButton butonScript;

    public Quaternion storedRotation;
    public Quaternion currentRotation;

    public bool isSpinning = false;

    public void RandomizeWheelRotation()
    {
        this.gameObject.transform.Rotate(0, 0, Random.Range(0, 360f));
    }

    public void SpinWheel()
    {
        storedRotation = transform.rotation;
        LeanTween.rotateAroundLocal(this.gameObject, Vector3.forward, butonScript.percentAmount * butonScript.rotateParameter, 8f * butonScript.percentAmount).setEaseOutExpo();
        isSpinning = true;
    }

    IEnumerator SpinWheelCoroutine()
    {
        storedRotation = transform.rotation;
        LeanTween.rotateAroundLocal(this.gameObject, Vector3.forward, butonScript.percentAmount * butonScript.rotateParameter, 8f * butonScript.percentAmount).setEaseOutExpo();
        butonScript.gameObject.SetActive(false);
        yield return new WaitForSeconds(8f * butonScript.percentAmount);
        butonScript.gameObject.SetActive(true);
        butonScript.WasSpinned = false;
        isSpinning = true;
    }

    public void SpinWheelCor()
    {
        StartCoroutine(SpinWheelCoroutine());
    }



}
