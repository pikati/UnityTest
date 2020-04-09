﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputManager : MonoBehaviour
{
    private InputAction move, cameraCtrl, ChangeDayNight, Create, iceDecide, iceMove, decide, cancel;
    private PlayerInput input;
    #region Player
    public Vector2 direction { get; private set; }
    public Vector2 cameraDirection { get; private set; }
    public bool isChange { get; private set; }
    public bool isCreate { get; private set; }
    #endregion

    #region Ice
    public Vector2 iceDirection { get; private set; }
    public bool isIceDecide { get; private set; }
    #endregion

    #region General
    public bool isDecide { get; private set; }
    public bool isCancel { get; private set; }
    #endregion

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        var actionMap = input.currentActionMap;
        move = actionMap["Move"];
        cameraCtrl = actionMap["Camera"];
        ChangeDayNight = actionMap["ChangeDayNight"];
        Create = actionMap["Create"];
        SwitchActionMap("Ice");
        actionMap = input.currentActionMap;
        iceDecide = actionMap["Decide"];
        iceMove = actionMap["Move"];
        SwitchActionMap("UI");
        actionMap = input.currentActionMap;
        decide = actionMap["Decide"];
        cancel = actionMap["Cancel"];
        SwitchActionMap("Player");
    }

    // Update is called once per frame
    void Update()
    {
        direction = move.ReadValue<Vector2>();
        cameraDirection = cameraCtrl.ReadValue<Vector2>();
        isChange = ChangeDayNight.triggered;
        isCreate = Create.triggered;
        isIceDecide = iceDecide.triggered;
        iceDirection = iceMove.ReadValue<Vector2>();
        isDecide = decide.triggered;
        isCancel = cancel.triggered;
    }

    public void SwitchActionMap(string actionMapName)
    {
       input.SwitchCurrentActionMap(actionMapName);
    }
}
