using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : InputObject
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        if (!receiving && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.Receive();
        }

        if (receiving && Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.Reject();
        }
    }
}
