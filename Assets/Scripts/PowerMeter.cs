using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMeter : MonoBehaviour
{
    public bool isStarted = false;
    private float timer = 0;
    public float value = 0;
    public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            timer += Time.deltaTime;
            value = Mathf.Pow(-Mathf.Abs(Mathf.Sin(timer/speed * Mathf.PI - Mathf.PI / 2)) + 1, 2);
            this.transform.Find("Power").transform.localScale = new Vector3(value, 1, 1);
            this.transform.Find("Power").transform.localPosition = new Vector3(value / 2 - .5f, 0, -1.2f);
        }
    }

    public void StartMeter()
    {
        isStarted = true;
        timer = 0;
        value = 0;
    }

    public void StopMeter()
    {
        isStarted = false;
    }
}
