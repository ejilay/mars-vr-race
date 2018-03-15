using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour {

    public bool Hand = false;

    Snapper snapped;

   public List<Snapper> snappers = new List<Snapper>();

    public float SnapDistance = 0.1f;

    public TransformSync TransformSync;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if  (snapped == null)
        {
            foreach (Snapper snapper in snappers)
            {
                if (!this.Hand  && snapper.Hand && Vector3.Distance(this.transform.position, snapper.transform.position) <= SnapDistance)
                {
                    snapped = snapper;
                    TransformSync.sourceTransform = snapped.transform;
                    break;
                }
            }
        }
	}
}
