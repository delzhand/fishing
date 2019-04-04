using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    public float maxTimer;
    public float timer;
    public float distance;
    public float CurrentDistance;
    public Vector3 startPosition;
    private FishingManager fishingManager;
    private LureTarget lureTarget;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        fishingManager = GameObject.Find("Game").GetComponent<FishingManager>();
        lureTarget = GameObject.Find("LureTarget").GetComponent<LureTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(fishingManager.Mode)
        {
            case FishingMode.throwing:
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    timer = 0;
                    fishingManager.Mode = FishingMode.reeling;
                    transform.Find("Ripples").GetComponent<ParticleSystem>().Play();
                }

                float horizontal = 0;
                if (fishingManager.LeftButton.Receiving())
                {
                    horizontal -= 1;
                }
                if (fishingManager.RightButton.Receiving())
                {
                    horizontal += 1;
                }

                float percent = timer / maxTimer;
                Vector3 newPosition = startPosition;
                newPosition.x += transform.position.x + (horizontal * .01f);
                newPosition.z += distance * (1 - percent);
                newPosition.y = startPosition.y * Mathf.Cos(Mathf.Pow(1 - percent, 2) * Mathf.PI / 2);
                transform.position = newPosition;
                GameObject.Find("Camera Rig").transform.position = new Vector3(0, 0, transform.position.z);
                break;
            case FishingMode.reeling:
                float offset = 0;
                if (fishingManager.LeftButton.Receiving())
                {
                    offset -= 1;
                }
                if (fishingManager.RightButton.Receiving())
                {
                    offset += 1;
                }
                lureTarget.transform.position = new Vector3(offset * 2, 0, 0);
                break;
            default:
                lureTarget.transform.position = new Vector3(0, 0, 0);
                break;
        }

        Vector3 target = new Vector3(startPosition.x, 0, startPosition.z);
        CurrentDistance = Vector3.Distance(target, transform.position);
    }

    public void ThrowLure(float power)
    {
        maxTimer = power * 5;
        timer = power * 5;
        distance = power * 35;
    }

    public void ReelIn()
    {
        float step = 5f * Time.deltaTime;
        Vector3 target = lureTarget.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        GameObject.Find("Camera Rig").transform.position = new Vector3(0, 0, transform.position.z);

        if (Vector3.Distance(target, transform.position) < .1f)
        {
            transform.position = startPosition;
            fishingManager.Mode = FishingMode.waiting;
            transform.Find("Ripples").GetComponent<ParticleSystem>().Stop();
            fishingManager.ActionButton.Reject();
            timer = 0;
        }
    }
}
