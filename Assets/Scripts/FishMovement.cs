using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    public bool isMoving = false;
    public float timer = 0;
    public float idleDuration = 3;
    public float movingDuration = 1;
    public Vector2 moveDirection = Vector2.zero;
    private Random random;
    private FishingManager fishingManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = -Random.Range(0, 3f);
        moveDirection = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f));
        idleDuration = 3 + Random.Range(0, 3f);
        movingDuration = 1 + Random.Range(0, 1f);
        fishingManager = GameObject.Find("Game").GetComponent<FishingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Fish>().fighting)
        {
            Vector3 newPosition = fishingManager.Lure.transform.position;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > idleDuration)
            {
                isMoving = true;
                gameObject.transform.localPosition += new Vector3(moveDirection.x, 0, moveDirection.y) * Time.deltaTime;

            }
            if (timer > (idleDuration + movingDuration))
            {
                isMoving = false;
                timer -= (idleDuration + movingDuration);
                moveDirection = new Vector2(Random.Range(0, 1f), Random.Range(0, 1f));
                idleDuration = 3 + Random.Range(0, 3f);
                movingDuration = 1 + Random.Range(0, 1f);
            }
        }
    }
}
