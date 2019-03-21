using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public FishingMode Mode;
    public Lure Lure;
    public InputObject InputObject;

    // Start is called before the first frame update
    void Start()
    {
        Mode = FishingMode.waiting;
        Lure = GameObject.Find("Lure").GetComponent<Lure>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
