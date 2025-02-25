using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSceneController : MonoBehaviour
{
    parameterController para;

    // Start is called before the first frame update
    void Start()
    {
        para = GameObject.Find("UnityroomApiClient").GetComponent<parameterController>();
        para.isHonkeFalse();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    
}
