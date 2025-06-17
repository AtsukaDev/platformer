using UnityEngine;



public class KnightScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform groundCheck ;
    public LayerMask ground;
    public float groundCheckRadius = 0.01f;
    public bool isGrounded = false;
    public int nbJumps = 0;
    public float jumpForce = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // Move de gauche à droite
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * 5f, rb.linearVelocity.y);

        // Check si le joueur touche le sol
        this.isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);
        if (this.isGrounded)
        {
            //Debug.Log("touche le sol");
            this.nbJumps = 1;
        }

        // Si le joueur saute
        if (Input.GetButtonDown("Jump") && nbJumps > 0)
        {
            this.nbJumps--;
            this.rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            //Debug.Log(nbJumps.ToString());
            
        }



    }
}
