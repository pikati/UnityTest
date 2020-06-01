﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    private TitleCinemachineManager cinemachineManager;
    private TitleTextController title;
    private TitleButtonContorller buttons;
    private TitlePlayableDirectorManager pdm;
    private TitleSceneManager tsm;

    private void Start()
    {
        cinemachineManager = GameObject.Find("CineamchineManager").GetComponent<TitleCinemachineManager>();
        title = GameObject.Find("Title").GetComponent<TitleTextController>();
        buttons = GameObject.Find("Buttons").GetComponent<TitleButtonContorller>();
        pdm = GameObject.Find("PlayableDirectorManager").GetComponent<TitlePlayableDirectorManager>();
        tsm = GameObject.Find("TitleSceneManager").GetComponent<TitleSceneManager>();
    }
    public void StartGame()
    {
        cinemachineManager.StartPrologueEvent();
        title.isStart = true;
        buttons.ChangeButtonTransition();
        buttons.isStart = true;
        pdm.StartTimeline();
        tsm.isEventStart = true;
    }


    public void Continue()
    {
        //ステージセレクト画面
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
