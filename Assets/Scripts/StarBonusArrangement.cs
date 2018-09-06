﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBonusArrangement : MonoBehaviour {

    public int spawnWeight = 0;
    private float spawnPercentage = 0.0f;
    private float chanceMin = 0.0f;
    private float chanceMax = 0.0f;
    private int numChildren = 0;

    void Start()
    {
        numChildren = transform.childCount;
    }

    public float SpawnPercentage
    {
        get { return spawnPercentage; }
        set { spawnPercentage = value; }
    }

    public float ChanceMin
    {
        get { return chanceMin; }
        set { chanceMin = value; }
    }

    public float ChanceMax
    {
        get { return chanceMax; }
        set { chanceMax = value; }
    }

    public int NumChildren
    {
        get { return numChildren; }
        set
        {
            numChildren = value;
            if (numChildren == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
