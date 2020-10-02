using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floortrap2 : MonoBehaviour
{
    Rigidbody2D rigid2D;
    GameObject cat;
    



    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.cat = GameObject.Find("cat");
        
    }

    
    void Update()
    {
        if (this.gameObject.transform.position.x == this.cat.transform.position.x)
        {
            transform.Translate(0, -0.1f, 0);

            if (transform.position.y < -10.0f)
            {
                Destroy(gameObject);
            }
        }
    }

}
