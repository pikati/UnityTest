﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceBreak : MonoBehaviour
{
    [SerializeField]
    private int loadCapacity;
    Rigidbody[] rb;
    private bool isColPlayer = false;
    [SerializeField]
    private float taeru = 0;
    private float countTime = 0;
    private int penNum = 0;
    void Start()
    {
        rb = new Rigidbody[transform.childCount];
        rb = gameObject.GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        BreakIce();
    }

    private void BreakIce()
    {
        if (!isColPlayer) return;
        float dTime = Time.deltaTime;
        countTime += dTime + penNum * 0.1f * dTime;
        if(countTime > taeru)
        {
            foreach (Rigidbody r in rb)
            {
                r.isKinematic = false;
                r.transform.SetParent(null);
                Destroy(r.gameObject, 2.0f);
            }
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            penNum = collision.gameObject.GetComponent<PlayerManager>().penguinNum;
            //if (penNum > loadCapacity)
            //{
            //    isColPlayer = true;
            //}
            isColPlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColPlayer = false;
            countTime = 0;
        }
    }
}
