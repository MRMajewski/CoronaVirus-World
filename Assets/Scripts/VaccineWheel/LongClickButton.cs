using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private bool pointerDown;

    // private bool pointerUp;

        [SerializeField]
    private bool isBarRising = true;

    public bool WasSpinned = false;

    public float maxFillTime;
    public float pointerDownTimer;

    public float percentAmount;

    public float rotateParameter;

    public UnityEvent onLongClick;

    [SerializeField]
    private Image fillImage;


    public GameObject Wheel;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (onLongClick != null)
        {
            onLongClick.Invoke();
            WasSpinned = true;
        }    
        Reset();
    }

    private void Reset()
    {
        pointerDown = false;

        pointerDownTimer = 0;

        UpdateButtonFill();
    }

    void Update()
    {
        if (!WasSpinned)
        {

            if (pointerDown && isBarRising)
            {
                pointerDownTimer += Time.deltaTime;

                if (pointerDownTimer > maxFillTime && isBarRising)
                {
                    isBarRising = false;
                }
            }

            else if (pointerDown && !isBarRising)
            {
                pointerDownTimer -= Time.deltaTime;

                if (pointerDownTimer < 0)
                {
                    isBarRising = true;
                }
            }
            UpdateButtonFill();
        }
    }

    public void UpdateButtonFill()
    {
        percentAmount = pointerDownTimer / maxFillTime;

        fillImage.fillAmount = percentAmount;
    }

}
