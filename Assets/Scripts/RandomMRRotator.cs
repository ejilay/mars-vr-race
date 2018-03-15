using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMRRotator : MonoBehaviour {

    public float Multiplier = 0.1f;

    Transform[] transforms;
    Quaternion[] quaternions;


	// Use this for initialization
	void Start () {
        var mrs = GetComponentsInChildren<MeshRenderer>();
        transforms = new Transform[mrs.Length];
        quaternions = new Quaternion[mrs.Length];
        int i = 0;
        foreach (MeshRenderer mr in mrs)
        {
            transforms[i] = mr.transform;
            quaternions[i] = Quaternion.Euler(Random.insideUnitSphere*Multiplier);
            i++;
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        int i = 0;
		foreach (Transform t in transforms)
        {
            t.transform.localRotation *= quaternions[i];
            i++;
        }
	}
}
