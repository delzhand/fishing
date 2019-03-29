using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 120; i++)
        {
            Random random = new Random();
            Vector3 startPosition = new Vector3();
            startPosition.x = Random.Range(-15f, 15f);
            startPosition.y = -Random.Range(0, 3) - .1f;
            startPosition.z = Random.Range(0f, 50f);
            GameObject.Instantiate(Resources.Load("Prefabs/Fish"), startPosition, Quaternion.Euler(90, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
