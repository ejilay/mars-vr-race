using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public Transform Rig;

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = Rig.localPosition; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            Rig.localPosition = startPos;
            Rig.localRotation = Quaternion.identity;
        }
	}
}
