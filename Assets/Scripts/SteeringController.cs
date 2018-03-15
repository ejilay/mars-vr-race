using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringController : MonoBehaviour {

    public Transform DestinationTransform;

    public Transform LeftSnapperTransform;
    public Transform RightSnapperTransform;

    public float YRotationSpeed = 1f;

    public Transform WheelToRotate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var rotateVector = RightSnapperTransform.localPosition - LeftSnapperTransform.localPosition;
        rotateVector.z = 0;

        
        float sign = (RightSnapperTransform.localPosition.y < LeftSnapperTransform.localPosition.y) ? 1.0f : -1.0f;
        var angle = Vector3.Angle(rotateVector, Vector3.right)/180f;
        

        angle = Mathf.Clamp01(angle) * sign;
        

        float displace = (RightSnapperTransform.localPosition.z + LeftSnapperTransform.localPosition.z)/2;

        displace /= 0.30f;
        var rotation = new Vector3(displace, angle, -angle / 3f);
        
        rotation = rotation * YRotationSpeed;
        RotateCar(rotation);

        RotateWheel(rotation);


	}

    void RotateCar(Vector3 rotation)
    {
        DestinationTransform.localRotation *= Quaternion.Euler(rotation);
    }

    void RotateWheel(Vector3 rotation)
    {
        var currentRot = WheelToRotate.localRotation.eulerAngles;
        currentRot.x = -rotation.y * 90f;
        WheelToRotate.localRotation = Quaternion.Euler(currentRot);
    }
}
