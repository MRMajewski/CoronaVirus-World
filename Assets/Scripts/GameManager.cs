﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int points;

    public int vaccinePoints;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetPoints()
    {
        points = 0;
    }

    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
    }
}