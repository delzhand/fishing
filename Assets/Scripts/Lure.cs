using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    public float maxTimer;
    public float timer;
    public float distance;
    public Vector3 startPosition;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.Find("Player");
        transform.Find("Ripples").GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
                player.GetComponent<InputManager>().mode = FishingMode.reeling;
                transform.Find("Ripples").GetComponent<ParticleSystem>().Play();
            }

            float percent = timer / maxTimer;
            Vector3 newPosition = startPosition;
            newPosition.z += distance * (1 - percent);
            newPosition.y = startPosition.y * Mathf.Cos(Mathf.Pow(1 - percent, 2) * Mathf.PI / 2);
            transform.position = newPosition;
            GameObject.Find("Camera Rig").transform.position = new Vector3(0, 0, transform.position.z);
        }
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
        Vector3 target = new Vector3(startPosition.x, 0, startPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        GameObject.Find("Camera Rig").transform.position = new Vector3(0, 0, transform.position.z);

        if (Vector3.Distance(target, transform.position) < .1f)
        {
            transform.position = startPosition;
            player.GetComponent<InputManager>().mode = FishingMode.waiting;
            transform.Find("Ripples").GetComponent<ParticleSystem>().Stop();
        }
    }
}
