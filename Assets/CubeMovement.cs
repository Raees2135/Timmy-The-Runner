using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forward = 5.0f;
    public float sideways = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, forward * Time.deltaTime);
        }
        if (Input.GetKey("s")){
            rb.AddForce(0, 0, -forward * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideways * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideways * Time.deltaTime, 0, 0);
        }

    }
}
