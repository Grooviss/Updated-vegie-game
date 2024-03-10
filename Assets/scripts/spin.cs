using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationspeed = 180f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationspeed * Time.deltaTime);
    }
}
