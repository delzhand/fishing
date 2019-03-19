using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleButton : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider == this.GetComponent<Collider>())
                {
                    if (player.GetComponent<InputManager>().mode == FishingMode.waiting) {
                        GameObject.Find("Power Meter").GetComponent<PowerMeter>().StartMeter();
                        player.GetComponent<InputManager>().mode = FishingMode.casting;
                    }
                    else if (player.GetComponent<InputManager>().mode == FishingMode.casting)
                    {
                        GameObject.Find("Power Meter").GetComponent<PowerMeter>().StopMeter();
                        player.GetComponent<InputManager>().mode = FishingMode.throwing;
                        float power = GameObject.Find("Power Meter").GetComponent<PowerMeter>().value;
                        GameObject.Find("Lure").GetComponent<Lure>().ThrowLure(power);
                    }
                }
            }
        }
        else if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Stationary))
        {
            if (player.GetComponent<InputManager>().mode == FishingMode.reeling)
            {
                GameObject.Find("Lure").GetComponent<Lure>().ReelIn();
            }
        }

    }
}
