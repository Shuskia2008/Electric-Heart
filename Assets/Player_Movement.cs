using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public Animator myAnimator;
    public float movespeed;
    public float jumpForce;
    public float walljumpForce;
    public WallChecker l;
    public WallChecker r;
    public float Timer;
    public bool hasTouchedGrass = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer + Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && GetComponentInChildren<GroundChecker>().GroundDetection == true)
        {
            myRigidbody.linearVelocityY = jumpForce;
            myAnimator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && GetComponentInChildren<GroundChecker>().GroundDetection == false && (l.WallDetection == true || r.WallDetection == true))
        {
            myRigidbody.linearVelocityY = walljumpForce;
            myAnimator.SetTrigger("Jump");
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true && l.WallDetection == false)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && r.WallDetection == false)
        {
            myRigidbody.linearVelocityX = movespeed;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && l.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = movespeed;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && r.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }

        /*if ((r.WallDetection == true || l.WallDetection == true) && hasTouchedGrass == true)
        {
            myRigidbody.gravityScale = 0;
            Timer = 0;
            hasTouchedGrass = false;
        }
        if (Timer > 0.3f)
        {
            myRigidbody.gravityScale = 5;
        }
        */
        if (r.WallDetection == true && Input.GetKey(KeyCode.RightArrow) && hasTouchedGrass == true)
        {
            Timer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        if (l.WallDetection == true && Input.GetKey(KeyCode.LeftArrow) && hasTouchedGrass == true)
        {
            Timer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        if (Timer > 0.3f)
        {
            myRigidbody.gravityScale = 5;
            hasTouchedGrass = true;
        }
        if (hasTouchedGrass = false && (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.LeftArrow) == true))
        {
            myRigidbody.gravityScale = 5;
            hasTouchedGrass = true;
        }
        //transform.position += new Vector3(myRigidbody.linearVelocityX * Time.deltaTime, myRigidbody.linearVelocityY * Time.deltaTime, 0);

        //float acceleration = 1f;
        //float speed = 0f;
        //speed += acceleration * Time.deltaTime * 0.5f;
        //transform.position += Vector3.right * speed * Time.deltaTime;
        //speed += acceleration * Time.deltaTime * 0.5f;

        myAnimator.SetFloat("X velocity", myRigidbody.linearVelocityX);

        //transform.position += new Vector3(myRigidbody.linearVelocityX * Time.deltaTime, myRigidbody.linearVelocityY * Time.deltaTime, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            hasTouchedGrass = true;
        }

    }
}
