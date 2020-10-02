using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floortrap : MonoBehaviour
{
    GameObject cat;

    void Start()
    {
        this.cat = GameObject.Find("cat");
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if(transform.position.y< -10.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = this.cat.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if(d < r1 + r2)
        {
            Destroy(cat);
            SceneManager.LoadScene("GameScene");
        }
    }
}
