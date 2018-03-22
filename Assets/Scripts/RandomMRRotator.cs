using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RandomMRRotator : MonoBehaviour {

    public float Multiplier = 0.1f;

    Transform[] transforms;
    Quaternion[] quaternions;
    MeshFilter[] mfs;

    public Mesh GopherMesh;

    public float Percent = 0.005f;

	// Use this for initialization
	void Start () {
        var mrs = GetComponentsInChildren<MeshRenderer>();
        transforms = new Transform[mrs.Length];
        quaternions = new Quaternion[mrs.Length];
        mfs = new MeshFilter[mrs.Length];
        int i = 0;
        foreach (MeshRenderer mr in mrs)
        {
            transforms[i] = mr.transform;
            quaternions[i] = Quaternion.Euler(Random.insideUnitSphere*Multiplier);
            mfs[i] = mr.gameObject.GetComponent<MeshFilter>();
            i++;
        }
        if (GopherMesh != null)
        {
            reshuffle(mfs);
            float count = Percent * mfs.Length;
            Debug.Log(count);
            for (i = 0; i < count; i++)
            {
                mfs[i].mesh = GopherMesh;
            }
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

    void reshuffle(MeshFilter[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            MeshFilter tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }

}