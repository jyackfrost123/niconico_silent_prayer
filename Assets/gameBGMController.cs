using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBGMController : MonoBehaviour
{

    void OnEnable() {
        gameObject.GetComponent<AudioSource>().Play();
    }

}
