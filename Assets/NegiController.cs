using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegiController : MonoBehaviour
{

    private float negiRotation;
    public float addRotation = 2.0f;

    public float startX;
    public float EndX;
    // Start is called before the first frame update
    void Start()
    {
        negiRotation = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        negiRotation -= addRotation;
        transform.eulerAngles  = new Vector3( 0f, 0f, negiRotation);

        if(negiRotation < -360.0f) Destroy(this.gameObject);
    }
}
