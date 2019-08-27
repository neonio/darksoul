using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool isAvailable = false;
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    

    public float tDirectForward;
    public float tDirectSide;
    public float currentDirectForward;
    public float currentDirectSide;
    public float currentMag;
    public Vector3 currentVector;

    private float velocityDirectForward;
    private float velocityDirectSide;

    public float dropTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDirections();
    }

    private void CalculateDirections()
    {
        tDirectForward = (Input.GetKey(keyUp) ? 1f : 0f) - (Input.GetKey(keyDown) ? 1f : 0f);
        tDirectSide = (Input.GetKey(keyRight) ? 1f : 0f) - (Input.GetKey(keyLeft) ? 1f : 0f);

        if (!isAvailable)
        {
            tDirectForward = 0;
            tDirectSide = 0;
            return;
        }

        currentDirectForward = Mathf.SmoothDamp(currentDirectForward, tDirectForward, ref velocityDirectForward, dropTime);
        currentDirectSide = Mathf.SmoothDamp(currentDirectSide, tDirectSide, ref velocityDirectSide, dropTime);
        currentMag = Mathf.Sqrt(currentDirectForward * currentDirectForward + currentDirectSide * currentDirectSide);
        currentVector = currentDirectForward * transform.forward + currentDirectSide * transform.right;
    }
}
