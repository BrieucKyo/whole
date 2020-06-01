﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDetectedInteraction : Interaction
{
    public override string GetAction() {
        return action = "StartScene";
    }

    public override bool Listen()
    {
        return GameManager.Instance.kinectManager.IsUserDetected();
    }
}