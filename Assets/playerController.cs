using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public GameObject negi;

    public float negiX;
    public float negiY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNegi(){
        Instantiate(negi, new Vector3(negiX * Random.Range(-1.0f, 1.0f), negiY* Random.Range(-1.0f, 1.0f), 12.3f), Quaternion.identity);
    }
}
