using UnityEngine;
using System.Collections;

public class rotating_Aroud : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.up, 60 * Time.deltaTime);
    }
}
