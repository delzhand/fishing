using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lure : MonoBehaviour
{
    public float maxTimer;
    public float timer;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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
            }

            float percent = timer / maxTimer;
            Vector3 newPosition = startPosition;
            newPosition.z += 35 * (1 - percent);
            newPosition.y = startPosition.y * Mathf.Cos(Mathf.Pow(1 - percent, 2) * Mathf.PI / 2);
            transform.position = newPosition;
            GameObject.Find("Camera Rig").transform.position = new Vector3(0, 0, transform.position.z);
        }
    }

    public void ThrowLure(float power)
    {
        maxTimer = power * 10;
        timer = power * 10;
    }
}
