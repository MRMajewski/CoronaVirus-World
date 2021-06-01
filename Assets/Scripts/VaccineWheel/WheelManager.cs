using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelManager : MonoBehaviour
{
    public Wheel wheel;
    public Needle needle;

    public GameObject wheelPanel;

    public bool WasSpinned = false;

    public TextMeshProUGUI vaccinePoints;

    public GameManager manager;
    public UIManager uiManager;

    public Rigidbody world;


    private void Start()
    {
        LeanTween.alphaCanvas(wheelPanel.GetComponent<CanvasGroup>(), 0f, 0f);
        wheelPanel.SetActive(false);
    }

    private void Update()
    {
        if(WasSpinned)
        {
            int vaccinePoints = needle.PointsGained;
            manager.AddVaccinePoints(vaccinePoints);
            disactivateWheelPanel();
            WasSpinned = false;
        }
    }

    public void activateWheelPanel()
    {       
        wheelPanel.SetActive(true);
        WasSpinned = false;

        LeanTween.alphaCanvas(wheelPanel.GetComponent<CanvasGroup>(), 1f, .5f);
        wheel.RandomizeWheelRotation();
        world.angularDrag = 10f;
    }

    public void disactivateWheelPanel()
    {
        LeanTween.alphaCanvas(wheelPanel.GetComponent<CanvasGroup>(), 0f, .5f);
        world.angularDrag = .5f;


    }
        
}
