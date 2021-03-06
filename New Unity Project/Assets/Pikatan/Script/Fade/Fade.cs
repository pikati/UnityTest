﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private float fadeTime;
    private static string nextSceneName = null;

    private static float fTime;

    private static Canvas canvas;
    private static Image image;

    private static bool isFadeIn;
    private static bool isFadeOut;

    private static float alpha;
    private static float speed = 1.0f;
    public static bool isFading { get; private set; } = false;

    public delegate void EndFade();
    public static event EndFade OnEndFade;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        image = transform.Find("FadeImage").GetComponent<Image>();
        isFadeIn = false;
        isFadeOut = false;
        alpha = 0.0f;
        fTime = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn) UpdateFadeIn();
        else if (isFadeOut) UpdateFadeOut();
        isFading = isFadeIn || isFadeOut;
    }

    private static void UpdateFadeIn()
    {
        alpha += Time.deltaTime / fTime * speed;
        if(nextSceneName != null && alpha >= 1.0f)
        {
            SceneManager.LoadScene(nextSceneName);
        }
        if(alpha >= 1.2f)
        {
            isFadeIn = false;
            canvas.enabled = false;
            OnEndFade?.Invoke();//nullチェックして実行
            FadeOut();
        }

        image.color = new Color(0.0f, 0.0f, 0.0f, alpha);
    }

    private static void UpdateFadeOut()
    {
        alpha -= Time.deltaTime / fTime * speed;

        if (alpha <= 0.0f)
        {
            isFadeOut = false;
            alpha = 0.0f;
        }

        image.color = new Color(0.0f, 0.0f, 0.0f, alpha);
    }

    public static void FadeIn()
    {
        image.color = Color.clear;
        isFadeIn = true;
        alpha = 0.0f;
        speed = 1.0f;
    }

    public static void FadeIn(string sceneName)
    {
        image.color = Color.clear;
        isFadeIn = true;
        alpha = 0.0f;
        nextSceneName = sceneName;
        speed = 1.0f;
    }

    public static void FadeIn(float spd)
    {
        image.color = Color.clear;
        isFadeIn = true;
        alpha = 0.0f;
        nextSceneName = null;
        speed = spd;
    }

    public static void FadeIn(string sceneName, float spd)
    {
        image.color = Color.clear;
        isFadeIn = true;
        alpha = 0.0f;
        nextSceneName = sceneName;
        speed = spd;
    }

    public static void FadeOut()
    {
        image.color = Color.black;
        canvas.enabled = true;
        isFadeOut = true;
        alpha = 1.0f;
    }

    public static void SetFade()
    {
        image.color = Color.black;
        canvas.enabled = true;
        alpha = 1.0f;
    }
}
