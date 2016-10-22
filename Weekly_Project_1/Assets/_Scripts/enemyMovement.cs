using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

    public float speed;
    public float jump;

    public Rigidbody rb;
    public Collider cd;

    private Vector3 movement;
    private int randomMove;



	void Start () {
        rb.GetComponent<Rigidbody>();
	}

    void Update()
    {
        if (gameObject.transform.position.y < 2.55f)
        {
            randomMove = Random.Range(0, 3);

            if (randomMove == 0)
                movement = new Vector3(speed, jump, 0f);
            else if (randomMove == 1)
                movement = new Vector3(-speed, jump, 0f);
            else if (randomMove == 2)
                movement = new Vector3(0f, jump, speed);
            else if (randomMove == 3)
                movement = new Vector3(0f, jump, -speed);

            rb.AddForce(movement * Time.deltaTime * 100);
        }
    }

    void OnTriggerEnter(Collider other)
    {
            Destroy(this.gameObject);
    }

}
