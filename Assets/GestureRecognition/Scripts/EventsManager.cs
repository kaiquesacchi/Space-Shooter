﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }

    public event Action<int, Boolean> MoveHandTrigger;
    public event Action<int> UploadImagesTrigger;
    public event Action<int, string, string, bool> LoginTrigger;
    public event Action<int> GetParametersRequestTrigger;
    public event Action<int, CustomParametersResponse> GetParametersResponseTrigger;

    public void OnHandMovementTrigger(int instanceId, Boolean isOpenHand)
    {
        MoveHandTrigger?.Invoke(instanceId, isOpenHand);
    }

    public void OnUploadImagesTrigger(int instanceId)
    {
        UploadImagesTrigger?.Invoke(instanceId);
    }

    public void OnLoginTrigger(int instanceId, string username, string password, bool remember_login)
    {
        LoginTrigger?.Invoke(instanceId, username, password, remember_login);
    }

    public void OnGetParametersRequestTrigger(int instanceId)
    {
        GetParametersRequestTrigger?.Invoke(instanceId);
    }

    public void OnGetParametersResponseTrigger(int instanceId, CustomParametersResponse response)
    {
        GetParametersResponseTrigger?.Invoke(instanceId, response);
    }
}
