using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

    public LayerMask ground;
    [HideInInspector] public bool grounded;

    private Rigidbody rigidbody;
    private BoxCollider bc;

    private float distToGround;

    // Use this for initialization
    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        bc = gameObject.GetComponent<BoxCollider>();
    }

    private void OnCollisionStay(Collision collision) {
        GameObject colGO = collision.gameObject;
        if (colGO.layer == ground) {
            grounded = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rigidbody.velocity = new Vector2(0, jumpHeight);
        } else if (Input.GetKey(KeyCode.A)) {
            rigidbody.velocity = new Vector2(-moveSpeed, 0);
        } else if (Input.GetKey(KeyCode.D)) {
            rigidbody.velocity = new Vector2(moveSpeed, 0);
        }
    }
}
