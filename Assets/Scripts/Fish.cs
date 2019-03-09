using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum FishType
{
    crappie,
    bass,
    drum,
    sunfish,
    bluegill,
    catfish,
    trout
}

public class Fish : MonoBehaviour
{
    public float currentStamina;
    public int maxStamina;
    public int size;
    public FishType fishType;
    public float speed = 1;

    void InitFish()
    {
        Array values = Enum.GetValues(typeof(FishType));
        Random random = new Random();
        this.fishType = (FishType)values.GetValue(random.Next(values.Length));
        this.size = random.Next(5, 10);
        this.maxStamina = size * 25;
        this.currentStamina = this.maxStamina;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitFish();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
