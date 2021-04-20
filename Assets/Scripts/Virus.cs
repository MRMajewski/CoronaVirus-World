using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public int Points;

    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void DestroyTarget()
    {
        LeanTween.sequence().append(

        LeanTween.scale(this.gameObject, Vector3.zero, 1f).setEasePunch()).

        append(
            LeanTween.scale(this.gameObject, Vector3.zero, 1f).setEaseOutSine());

        Destroy(this.gameObject, 2f);
    }

    public void addPoints()
    {
        manager.points += Points;
    }

}
