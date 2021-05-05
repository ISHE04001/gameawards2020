using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    

    void Start()
    {
        GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfGrounded();

        void CheckIfGrounded()
        {
            Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
            if (colliders != null)
            {
                isGrounded = true;

            }
            else
            {
                if (isGrounded)
                {

                }
                isGrounded = false;
            }
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        int layer_mask = LayerMask.GetMask("Ground");
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layer_mask);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;




            }
           
            }
        }
    }



