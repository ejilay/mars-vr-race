using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class AsteroidMaker : MonoBehaviour {
	public GameObject asteroidPrefab;
	public float fieldRadius;
	//public float velocity;
	//public float movementSpeed;
	//public float rotationSpeed;
	public int Ammount;
	public float SizeMin;
	public float SizeMax;




	// Use this for initialization
	void Start () {

		for(int i = 0; i < Ammount; ++i)
		{
			GameObject newAsteroid = (GameObject)Instantiate(asteroidPrefab, Random.insideUnitSphere * fieldRadius, Random.rotation);
			float size = Random.Range(SizeMin, SizeMax);
			newAsteroid.transform.localScale = Vector3.one * size;
			// if the asteroid has a rigidbody...
			//newAsteroid.rigidbody.velocity = Random.insideUnitSphere * movementSpeed;
			//newAsteroid.rigidbody.angularVelocity = Random.insideUnitSphere * rotationSpeed;	
		}


	}

}
