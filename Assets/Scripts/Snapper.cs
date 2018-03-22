using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour {

    public bool Hand = false;

    Snapper snapped;

   public List<Snapper> snappers = new List<Snapper>();

    public float SnapDistance = 0.1f;

    public TransformSync TransformSync;

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        if (!Hand)
        {
            startPos = this.transform.localPosition;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if  (!Hand && snapped == null)
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
        if (!Hand && snapped != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                snapped = null;
                this.transform.localPosition = startPos;
                TransformSync.sourceTransform = null;
            }
        }
	}
}
