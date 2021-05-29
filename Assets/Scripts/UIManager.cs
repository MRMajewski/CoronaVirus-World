using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI vaccinePointsText;



    public void UpdatePoints(int points)
    {
        pointsText.text = points.ToString();
        LeanTween.scale(pointsText.gameObject, Vector3.one, 1f).setEasePunch();
    }

    public void UpdateVaccinePoints(int vaccinePoints)
    {
        vaccinePointsText.text = vaccinePoints.ToString();
        LeanTween.scale(vaccinePointsText.gameObject, Vector3.one, 1f).setEasePunch();
    }

}
