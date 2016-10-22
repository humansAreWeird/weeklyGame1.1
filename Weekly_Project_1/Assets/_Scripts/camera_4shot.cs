using UnityEngine;
using System.Collections;

public class camera_4shot : MonoBehaviour {
    public Rigidbody playerRb;

    public float positionSpeed = 60f;
    public float rotationSpeed = .1f;

    private float x;
    private float z;

    private Vector3 Ppp;
    private Vector3 Ppn;
    private Vector3 Pnn;
    private Vector3 Pnp;

    void Start () {
        playerRb.GetComponent<Rigidbody>();

        Ppp = new Vector3(-60f, 40f, -5f);
        Ppn = new Vector3(-5f, 40f, 60f);
        Pnn = new Vector3(60f, 40f, 5f);
        Pnp = new Vector3(5f, 40f, -60f);
    }
	
	void FixedUpdate () {
        x = playerRb.transform.position.x;
        z = playerRb.transform.position.z;
        
	    if (x > 0 && z > 0) {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Ppp, Time.deltaTime * positionSpeed);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(25, 70, 0), Time.deltaTime);
        }
        else if (x > 0 && z < 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Ppn, Time.deltaTime * positionSpeed);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(25, 160, 0), Time.deltaTime);
        }
        else if (x < 0 && z < 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Pnn, Time.deltaTime * positionSpeed);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(25, 250, 0), Time.deltaTime);

        }
        else if (x < 0 && z > 0)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Pnp, Time.deltaTime * positionSpeed);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(25, 340, 0), Time.deltaTime);
        }
    }
}
