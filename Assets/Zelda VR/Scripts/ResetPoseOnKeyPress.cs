﻿using UnityEngine;

public class ResetPoseOnKeyPress : MonoBehaviour 
{
    public KeyCode key = KeyCode.Space;


	void Update () 
	{
		if(Input.GetKeyUp(key))
        {
            //TODO: robert OVRManager.display.RecenterPose();
        }
    }
}
