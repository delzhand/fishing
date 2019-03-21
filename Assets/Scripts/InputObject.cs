using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject : MonoBehaviour
{
    public float inputDuration = 0;
    public bool receiving = false;
    public bool DebugOutput = false;

    public void OnMouseDown()
    {
        Receive();
    }

    public void OnMouseUp()
    {
        if (receiving)
        {
            Reject();
        }
    }

    public void OnMouseExit()
    {
        if (receiving)
        {
            Reject();
        }
    }

    public virtual void Receive()
    {
        receiving = true;
        inputDuration = 0;
        if (DebugOutput)
        {
            Debug.Log(name + " receiving input.");
        }
    }

    public virtual void Reject()
    {
        receiving = false;
        if (DebugOutput)
        {
            Debug.Log(name + " active for " + inputDuration);
        }
    }

    public virtual void Update()
    {
        if (receiving)
        {
            inputDuration += Time.deltaTime;
        }
    }
}
