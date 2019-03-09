using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class FishMovement : MonoBehaviour
{

    public bool isMoving = false;
    public float timer = 0;
    public float idleDuration = 3;
    public float movingDuration = 1;
    public Vector2 moveDirection = Vector2.zero;
    private Random random;

    // Start is called before the first frame update
    void Start()
    {
        random = new Random();
        moveDirection = new Vector2(random.Next(1), random.Next(1));
    }

    // Update is called once per frame
    void Update()
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
            moveDirection = new Vector2(random.Next(1), random.Next(1));
        }
    }
}
