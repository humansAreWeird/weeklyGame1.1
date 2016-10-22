using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    public float speed = 5f;
    public float jump = 1f;

    private float x;
    private float z;

    private Vector3 movement;
    private Vector3 position_Change;
    private float horizontalMovement;
    private float verticalMovement;

    private bool isMoving = false;
    private bool isSpining = false;

    public Rigidbody rb;
    public Collider col;

    void Start() {
        rb.GetComponent<Rigidbody>();
        col.GetComponent<Collider>();
        col.isTrigger = (false);
    }

    void Update() {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        verticalMovement = Input.GetAxisRaw("Vertical") * speed;

        if (horizontalMovement != 0f || verticalMovement != 0f)
            if (isMoving == false) {
                movement = new Vector3(horizontalMovement, jump, verticalMovement);
                Debug.Log(movement);
                movement = Quaternion.AngleAxis(gameObject.transform.eulerAngles.y, Vector3.up) * movement;
                Debug.Log(movement);
                rb.AddForce(movement * Time.deltaTime * 60);
                isMoving = true;
            }

        if (horizontalMovement == 0f && verticalMovement == 0f && rb.transform.position.y < 7.55f)
            isMoving = false;

        x = gameObject.transform.position.x;
        z = gameObject.transform.position.z;


        
        if (Input.GetKeyDown("space"))
            if (isSpining == false)
            {
                isSpining = true;
                isMoving = true;
                col.isTrigger = true;
                rb.isKinematic = true;
                gameObject.transform.rotation = Quaternion.Euler(90f, gameObject.transform.rotation.y, 0f);
                position_Change = new Vector3(x, 2.5f, z);
                gameObject.transform.position = (position_Change);
            }

        if (isSpining == true)
            gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * 1000f);

        if (Input.GetKeyUp("space")){
            gameObject.transform.rotation = Quaternion.Euler(0f, gameObject.transform.rotation.y, 0f);
            position_Change = new Vector3(x, 7.5f, z);
            gameObject.transform.position = (position_Change);
            col.isTrigger = false;
            rb.isKinematic = false;
            isSpining = false;
            isMoving = false;
        } 

        if (isSpining == false)
        {
            if (x > 0 && z > 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 90f, gameObject.transform.rotation.z);
            }
            else if (x > 0 && z < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180f, gameObject.transform.rotation.z);
            }
            else if (x < 0 && z < 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 270f, gameObject.transform.rotation.z);
            }
            else if (x < 0 && z > 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 0f, gameObject.transform.rotation.z);
            }
        }

    }



}
