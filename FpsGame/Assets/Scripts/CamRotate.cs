using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float speed = 150;

    float angleX, angleY;
    
    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        Vector3 dir = new Vector3(-v, h, 0);
        transform.Rotate(dir * speed * Time.deltaTime);

        transform.eulerAngles += dir * speed * Time.deltaTime;

        Vector3 angle = transform. eulerAngles;
        angle += dir * speed * Time.deltaTime;
        if (angle.x)
        {

        }
        angleX += h * speed * Time.deltaTime;
        angleY += v * speed * Time.deltaTime;
        angleY = Mathf.Clamp(angleY, -60, 60);
    }
}
