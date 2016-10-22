using UnityEngine;
using System.Collections;

public class rotating_Around : MonoBehaviour {
    public Rigidbody playerRb;
    public float rotationSpeed = 1f;
    public float angleTolerance = 10f;

    private float camera_Angle;
    private float player_Angle;
            
	void Start () {
        playerRb.GetComponent<Rigidbody>();
	}

    void Update() {
        camera_Angle = SignedAngleBetween(gameObject.transform.position, Vector3.forward, playerRb.transform.position);
        player_Angle = SignedAngleBetween(playerRb.transform.position, Vector3.forward, gameObject.transform.position);
            //Vector3.Angle(playerRb.transform.position, Vector3.forward);
    }

    void FixedUpdate () {
        float a = player_Angle + camera_Angle;
        Debug.Log("angle camara  " + camera_Angle + "angle player" + player_Angle + "sum " + a + "pos" + playerRb.transform.position);
        if (Mathf.Abs(camera_Angle - player_Angle) > 180f+angleTolerance || Mathf.Abs(camera_Angle - player_Angle) < 180f - angleTolerance)
        {
            if (camera_Angle > (player_Angle + 180f) % 360f)
                transform.RotateAround(Vector3.zero, Vector3.up, -rotationSpeed * 5 * Time.deltaTime);
            else
                transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * 5 * Time.deltaTime);
        }
    }

    float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        float angle360 =  (signed_angle + 180) % 360;

        return angle360;
    } 
}
