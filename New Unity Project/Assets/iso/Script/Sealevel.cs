﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sealevel : MonoBehaviour
{
    private static float waterline;          //水面の高さコントローラー
    public GameObject panel;                 //水のテクスチャ 
    private static float playerline;         //playerの高さ
    private float watermin;                  //水面の下限   
    private float waterrateMAX;              //水面の下限とplayerの高さからの距離
    private float waterrateNOW;              //水面の現在の高さとplayerの高さからの距離
    private static float WaterHight;         //水のWidth,Hight
    private static float posy;               //水のposY

    private WaterHeightController whc;
    private PlayerManager pm;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        whc = GameObject.Find("WaterHeightController").GetComponent<WaterHeightController>();
        //水面の下限を取得
        watermin = whc.GetMinHeight();

        //playerの高さを取得
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        rectTransform = panel.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

        playerline = pm.position.y;
       

        //水面の下限とplayerの高さの距離を取得
        waterrateMAX = playerline - watermin;

        if (waterrateMAX <= 0)
        {
            waterrateMAX = 1;
        }

        //水面の高さを取得
        waterline = whc.waterHeight;

        //水面の高さとplayerの高さの距離を取得
        waterrateNOW = playerline - waterline;

        //水の縦のサイズを計算　　　　-12      -270    1    0/  -3    
        WaterHight = 90.0f * (1.0f-waterrateNOW / waterrateMAX);

        //サイズが100以上にならないように設定
        if (WaterHight > 100.0f)
        {
            WaterHight = 100.0f;
        }
        
        //水の座標Yを計算
        posy = 136 - (100.0f - WaterHight) / 2;



        //水の座標・サイズを設定
        rectTransform.sizeDelta = new Vector2(100.0f, WaterHight);
        rectTransform.anchoredPosition  = new Vector2(362.0f, posy);
        
    }
}
