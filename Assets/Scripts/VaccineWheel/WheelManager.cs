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

    public WorldMovement world;
    public float playerSpeed;


    private void Start()
    {
        wheelPanel.SetActive(false);
    }

    private void Update()
    {
        if(WasSpinned)
        {
            int vaccinePoints = needle.PointsGained;
            Debug.Log(vaccinePoints + "Tyle jest w managerze Wheel");
            manager.AddVaccinePoints(vaccinePoints);
            disactivateWheelPanel();
            WasSpinned = false;
        }
    }


    [ContextMenu("activate Wheel Panel")]
    public void activateWheelPanel()
    {       
        wheelPanel.SetActive(true);
        WasSpinned = false;
        LeanTween.alphaCanvas(wheelPanel.GetComponent<CanvasGroup>(), 0f, 0f);
        LeanTween.alphaCanvas(wheelPanel.GetComponent<CanvasGroup>(), 1f, 1f);
        wheel.RandomizeWheelRotation();
        playerSpeed = world.speed;
        world.speed = 0;
    }

    public void UpdateVaccinePoints(int vaccineAmount)
    {
        manager.vaccinePoints += vaccineAmount;
    }

    public void disactivateWheelPanel()
    {
      //  LeanTween.scale(wheelPanel, Vector3.zero, 1f).setEaseInElastic();
        wheelPanel.SetActive(false);
               playerSpeed = world.speed;

    }
        
}
