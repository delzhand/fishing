﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButton : InputObject
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    public override void Receive()
    {
        base.Receive();
        switch (fishingManager.Mode)
        {
            case FishingMode.waiting:
                GameObject.Find("Power Meter").GetComponent<PowerMeter>().StartMeter();
                fishingManager.Mode = FishingMode.casting;
                break;
            case FishingMode.casting:
                PowerMeter p = GameObject.Find("Power Meter").GetComponent<PowerMeter>();
                p.StopMeter();
                GameObject.Find("Lure").GetComponent<Lure>().ThrowLure(p.value);
                fishingManager.Mode = FishingMode.throwing;
                break;
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        switch (fishingManager.Mode)
        {
            case FishingMode.reeling:
                if (receiving)
                {
                    fishingManager.Lure.ReelIn();
                }
                break;
        }
    }
}
