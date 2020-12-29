using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;
    private int extraJumps;
    [HideInInspector] public int extraJumpsValue;


    private bool isGrouned;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpsValue;
    }



    private void FixedUpdate() {

        isGrouned = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();


        void Flip() {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }


    }

    void Update() {
        if (isGrouned == true) {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrouned == true) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

}
