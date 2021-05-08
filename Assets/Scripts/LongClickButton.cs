using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
   // private bool pointerUp;

    public float maxFillTime;
    public float pointerDownTimer;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer == maxFillTime)
            {
                pointerDownTimer -= Time.deltaTime;
            }

            fillImage.fillAmount = pointerDownTimer / maxFillTime;
        }

        if(!pointerDown)
        {
            onLongClick.Invoke();
            Debug.Log("Odpalam funkcje");
        }
        
    }

    //void Update()
    //{
    //    if (pointerDown)
    //    {
    //        pointerDownTimer += Time.deltaTime;
    //        if (pointerDownTimer >= maxFillTime)
    //        {
    //            if (onLongClick != null)
    //                onLongClick.Invoke();

    //            Reset();
    //        }

    //        fillImage.fillAmount = pointerDownTimer / maxFillTime;
    //    }
    //}
}
