﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    Vector3 pos;
    float delta = 5.0f;
    float speed = 3.0f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
