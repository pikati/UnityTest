﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonContorller : MonoBehaviour
{
    public bool isStart { get; set; } = false;
    private Button[] buttons = new Button[3];
    private Text[] texts = new Text[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            buttons[i] = obj.GetComponent<Button>();
            texts[i] = obj.transform.GetChild(0).gameObject.GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            float speed = 1.0f;
            for(int i = 0; i < 3; i++)
            {
                ColorBlock cb = buttons[i].colors;
                cb.normalColor -= new Color(0, 0, 0, speed * Time.deltaTime);
                buttons[i].colors = cb;
                texts[i].color -= new Color(0, 0, 0, speed * Time.deltaTime);
            }
            if (texts[2].color.a < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ChangeButtonTransition()
    {
        for (int i = 0; i < 3; i++)
        {
            buttons[i].transition = Selectable.Transition.ColorTint;
        }
    }
}