using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kusaController : MonoBehaviour
{

    public bool isDeleteCommnet = false;

    public float speed = 0.5f;

    public kusaGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-speed, 0, 0);

        if(transform.position.x < -7.0f){
            /*if(isDeleteCommnet){
                Destroy(this.gameObject);
            }else{
                //float newY = 1.0f;
                transform.position = new Vector3(9.0f, this.transform.position.y,  this.transform.position.z); 

                //Generatorから新しいのを一つ作る\
                generator.GenerateNewKusa();
                Destroy(this.gameObject);
            }*/
            //generator.GenerateNewKusa();
            Destroy(this.gameObject);
        }
                    
        
    }
}
