﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWater : MonoBehaviour
{
    private Transform player;
    private Transform sea;
    private GameObject inWater;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sea = GameObject.Find("WaterLarge").transform;
        inWater = transform.Find("InWaterEffect").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y + 4.1f < sea.position.y) inWater.SetActive(true);
        else inWater.SetActive(false);
    }
}