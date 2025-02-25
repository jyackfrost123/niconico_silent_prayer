using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startBackController : MonoBehaviour
{

    parameterController para;

    public Sprite[] sprites;

    private UnityEngine.UI.Image image;

    // Start is called before the first frame update
    void Start()
    {
        para = GameObject.Find("UnityroomApiClient").GetComponent<parameterController>();
        image = this.GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!para.isHonke){
            image.sprite = sprites[0];
        }else{
            image.sprite = sprites[1];
        }
    }
}
