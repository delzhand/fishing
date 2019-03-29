using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineOutText : MonoBehaviour
{
    private Lure lure;
    private FishingManager fishingManager;

    // Start is called before the first frame update
    void Start()
    {
        lure = GameObject.Find("Lure").GetComponent<Lure>();
        fishingManager = GameObject.Find("Game").GetComponent<FishingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (fishingManager.Mode)
        {
            case FishingMode.waiting:
            case FishingMode.casting:
                this.GetComponent<Text>().text = "";
                break;
            default:
                this.GetComponent<Text>().text = "Line Out: " + lure.CurrentDistance;
                break;
        }
    }
}
