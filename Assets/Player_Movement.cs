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
    public bool hasTouchedGrass = false;
    public float ClingTimer;
    public float LMoveDisabled;
    public float RMoveDisabled;

                //THE_WALL_JUMP_SYSTEM


                //---THE_WALL_JUMP_TIME_SYSTEM---

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Wall Jump Clinging -START-TIME
        ClingTimer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Wall Jump LMove -UPDATE-TIME
        LMoveDisabled = LMoveDisabled + Time.deltaTime;
        //Wall Jump RMove -UPDATE-TIME
        RMoveDisabled = RMoveDisabled + Time.deltaTime;
        //Wall Jump Clinging -UPDATE-TIME
        ClingTimer = ClingTimer + Time.deltaTime;
        //Wall Jump Clinging -TIMER-START-RESET
        if (r.WallDetection == true && Input.GetKey(KeyCode.RightArrow) && hasTouchedGrass == true)
        {
            ClingTimer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        if (l.WallDetection == true && Input.GetKey(KeyCode.LeftArrow) && hasTouchedGrass == true)
        {
            ClingTimer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        //Wall Jump LMove -TIMER-START-RESET
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && l.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            LMoveDisabled = 0;
            mmm
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true && l.WallDetection == false && LMoveDisabled < 0.5f)
        {
            myRigidbody.linearVelocityX = -movespeed * 0.5f;
        }
        //Wall Jump RMove -TIMER-START-RESET
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && r.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            RMoveDisabled = 0;
            nnn
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && r.WallDetection == false && RMoveDisabled < 0.5f)
        {
            myRigidbody.linearVelocityX = movespeed * 0.5f;
        }
        //Wall Jump Clinging -TIMER-FINISH
        if (ClingTimer > 0.3f)
        {
            myRigidbody.gravityScale = 5;
            hasTouchedGrass = true;
        }
        if (hasTouchedGrass = false && (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true || Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true))
        {
            myRigidbody.gravityScale = 5;
            hasTouchedGrass = true;
        }
        //Wall Jump LMove -TIMER-FINISH
        if (LMoveDisabled > 0.5f)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }
        //Wall Jump RMove -TIMER-FINISH
        if (RMoveDisabled > 0.5f)
        {
            myRigidbody.linearVelocityX = movespeed;
        }

        //---THE_WALL_JUMP_MECHANIC_SYSTEM---

        //Wall Jump -PUSH
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && l.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = movespeed;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && r.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }
        //Wall Jump -LIMITER-JUMP
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && GetComponentInChildren<GroundChecker>().GroundDetection == false && (l.WallDetection == true || r.WallDetection == true))
        {
            myRigidbody.linearVelocityY = walljumpForce;
            myAnimator.SetTrigger("Jump");
            hasTouchedGrass = true;
        }

                    //THE_JUMP_SYSTEM

        //Jump -LIMITER-JUMP
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && GetComponentInChildren<GroundChecker>().GroundDetection == true)
        {
            myRigidbody.linearVelocityY = jumpForce;
            myAnimator.SetTrigger("Jump");
        }

                    //THE_MOVE_SYSTEM

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow) == true && l.WallDetection == false)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && r.WallDetection == false)
        {
            myRigidbody.linearVelocityX = movespeed;
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
        if (collision.gameObject.CompareTag("ground") && GetComponentInChildren<GroundChecker>().GroundDetection == true && (l.WallDetection == false && r.WallDetection == false))
        {
            hasTouchedGrass = true;
        }
    
    }
    
}
