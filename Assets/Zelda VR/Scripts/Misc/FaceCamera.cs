﻿using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public bool yAxisOnly;

    Transform _target;


    void Awake()
    {
        //robert _target = CommonObjects.PrimaryCamera.transform;
    }

    void LateUpdate()
    {
        //robert transform.LookAt(_target);
        /*robert
        if (yAxisOnly)
        {
            Vector3 fwd = transform.forward;
            fwd.y = 0;
            transform.forward = fwd;
        }
        */
    }
}