using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSync : MonoBehaviour {

    public Transform sourceTransform;

    public Transform[] destinations;

    [Header("Position")]
    public bool SyncPos;
    public Vector3 PosAxis01 = Vector3.one;


    [Header("Rotation")]
    public bool SyncRotate;
    public Vector3 RotAxis01 = Vector3.one;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sourceTransform == null)
        {
            return;
        }

        foreach (Transform t in destinations)
        {
            if (SyncPos)
            {
                var scaledPos = sourceTransform.position;
                scaledPos.Scale(PosAxis01);
                t.position = scaledPos;
            }
            if (SyncRotate)
            {
                if (RotAxis01.sqrMagnitude != 1)
                {
                    var euler = sourceTransform.rotation.eulerAngles;
                    euler.x = euler.x * RotAxis01.x;
                    euler.y = euler.y * RotAxis01.y;
                    euler.z = euler.z * RotAxis01.z;
                    t.rotation = Quaternion.Euler(euler);
                } else
                {
                    t.rotation = sourceTransform.rotation;
                }
            }
        }
	}
}
