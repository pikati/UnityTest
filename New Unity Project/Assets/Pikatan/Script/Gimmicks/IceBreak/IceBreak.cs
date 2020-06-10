﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceBreak : MonoBehaviour
{
    Rigidbody[] rb;
    MeshCollider[] mc;
    private bool isColPlayer = false;
    private float countTime = 0;
    private IceBreakMaterialController ictrl;
    private GameStateController ctrl;
    private PoseController poseCtrl;
    private const float TAERU = 3.0f;
    private ParticleSystem particle;
    private bool isChange = false;


    void Start()
    {
        rb = new Rigidbody[transform.childCount - 1];
        rb = gameObject.GetComponentsInChildren<Rigidbody>();
        mc = new MeshCollider[transform.childCount - 1];
        mc = gameObject.GetComponentsInChildren<MeshCollider>();
        ictrl = GetComponent<IceBreakMaterialController>(); 
        ctrl = GameObject.Find("GameStateController").GetComponent<GameStateController>();
        poseCtrl = GameObject.Find("Pose").GetComponent<PoseController>();
        particle = transform.Find("BreakEffect").GetComponent<ParticleSystem>();
        for(int i = 0; i < transform.childCount - 1; i++)
        {
            mc[i].enabled = false;
        }
    }

    private void Update()
    {
        BreakIce();
    }

    private void BreakIce()
    {

        if (!isColPlayer) return;
        if (!ctrl.isProgressed) return;
        if (poseCtrl.isPose) return;

        countTime += Time.deltaTime;
        if(countTime > TAERU)
        {
            for (int i = 0; i < transform.childCount - 1; i++)
            {
                mc[i].enabled = true;
            }
            foreach (Rigidbody r in rb)
            {
                r.isKinematic = false;
                r.transform.SetParent(null);
                Destroy(r.gameObject, 2.0f);
            }
            
            Destroy(gameObject);
        }
        if(!isChange)
        {
            ictrl.ChangeMaterial();
            isChange = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            particle.Play();
            isColPlayer = true;
            Debug.Log("as");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColPlayer = false;
            particle.Stop();
        }
    }
}
