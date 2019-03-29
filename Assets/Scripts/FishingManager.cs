using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public FishingMode Mode;
    public Lure Lure;
    public LeftButton LeftButton;
    public RightButton RightButton;
    public ActionButton ActionButton;

    // Start is called before the first frame update
    void Start()
    {
        Mode = FishingMode.waiting;
        Lure = GameObject.Find("Lure").GetComponent<Lure>();
        LeftButton = GameObject.Find("LeftButton").GetComponent<LeftButton>();
        RightButton = GameObject.Find("RightButton").GetComponent<RightButton>();
        ActionButton = GameObject.Find("ActionButton").GetComponent<ActionButton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
