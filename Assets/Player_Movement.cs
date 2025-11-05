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
    public Non_GroundChecker u;
    public bool hasTouchedGrass = false;
    public float UnclingTimer;
    public float ClingTimer;
    public float WallDetectionTimer;
    public float HasJumpedTimer;
    public float LMoveDisabled;
    public float RMoveDisabled;
    public bool HasDetectedWall = false;
    public float MoveDisableTime;

    //THE_WALL_JUMP_SYSTEM


    //---THE_WALL_JUMP_TIME_SYSTEM---

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Wall Jump Clinging -START-TIME
        UnclingTimer = 10; 
        ClingTimer = 10;
        LMoveDisabled = 10;
        RMoveDisabled = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //WallDetection -UPDATE-TIME
        WallDetectionTimer = WallDetectionTimer + Time.deltaTime;
        //HasJumped -UPDATE-TIME
        HasJumpedTimer = HasJumpedTimer + Time.deltaTime;
        //Wall Jump LMove -UPDATE-TIME
        LMoveDisabled = LMoveDisabled + Time.deltaTime;
        //Wall Jump RMove -UPDATE-TIME
        RMoveDisabled = RMoveDisabled + Time.deltaTime;
        //Wall Jump Clinging -UPDATE-TIME
        ClingTimer = ClingTimer + Time.deltaTime;
        //Wall Jump Unclinging -UPDATE-TIME
        UnclingTimer = UnclingTimer + Time.deltaTime;
        //Wall Jump Clinging -TIMER-START-RESET
        if (r.WallDetection == true && u.NonGROUNDDetection == false && Input.GetKey(KeyCode.RightArrow) && hasTouchedGrass == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            ClingTimer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        if (l.WallDetection == true && u.NonGROUNDDetection == false && Input.GetKey(KeyCode.LeftArrow) && hasTouchedGrass == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            ClingTimer = 0;
            hasTouchedGrass = false;
            myRigidbody.gravityScale = 0;
        }
        //Wall Jump LMove -TIMER-START-RESET-----------------------------------------------------
        if ((Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.Space) == true) && l.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false && u.NonGROUNDDetection == false && LMoveDisabled > 0.5f)
        {
            LMoveDisabled = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true && LMoveDisabled < MoveDisableTime)
        {
            //NOTHING
        }
        //Wall Jump RMove -TIMER-START-RESET-----------------------------------------------------------------
        if ((Input.GetKey(KeyCode.UpArrow) == true || Input.GetKey(KeyCode.Space) == true) && r.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false && u.NonGROUNDDetection == false && RMoveDisabled > 0.5f && (WallDetectionTimer < HasJumpedTimer))
        {
            RMoveDisabled = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && RMoveDisabled < MoveDisableTime)
        {
            //NOTHING
        }
        //Wall Jump Clinging -TIMER-FINISH-UNCLINGING
        if (ClingTimer > 0.3f)
        {
            myRigidbody.gravityScale = 5;
            
        }
        if (hasTouchedGrass == false && (Input.GetKeyDown(KeyCode.LeftArrow) == true || Input.GetKeyDown(KeyCode.RightArrow) == true || Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true))
        {
            myRigidbody.gravityScale = 5;
            
        }
        if ((l.WallDetection == true) && (Input.GetKeyUp(KeyCode.LeftArrow) == true) && (hasTouchedGrass == false) && (GetComponentInChildren<GroundChecker>().GroundDetection == false))
        {
            UnclingTimer = 0;
        }
        if ((r.WallDetection == true) && (Input.GetKeyUp(KeyCode.RightArrow) == true) && (hasTouchedGrass == false) && (GetComponentInChildren<GroundChecker>().GroundDetection == false))
        {
            UnclingTimer = 0;
        }
        if (UnclingTimer < 0.3f)
        {
        myRigidbody.gravityScale = 5;
        }
        //More Timer Stuff
        //GroundDetectionTimer
        if ((l.WallDetection == true || r.WallDetection == true) && HasDetectedWall == false)
        {
            WallDetectionTimer = 0;
            HasDetectedWall = true;
        }
        if ((l.WallDetection == false && r.WallDetection == false) && HasDetectedWall == true)
        {   
            HasDetectedWall = false;
        }

        //HasJumpedTimer
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && GetComponentInChildren<GroundChecker>().GroundDetection == true && (l.WallDetection == false || r.WallDetection == false))
        {
            HasJumpedTimer = 0;
        }
        //Wall Jump LMove -TIMER-FINISH------------------------------------------------------------------------
        if (LMoveDisabled > MoveDisableTime)
        {
            if (Input.GetKey(KeyCode.LeftArrow) == true && l.WallDetection == false && LMoveDisabled > MoveDisableTime)
            {
                myRigidbody.linearVelocityX = -movespeed;
            }
        }
        //Wall Jump RMove -TIMER-FINISH-------------------------------------------------------------------------------
        if (RMoveDisabled > MoveDisableTime)
        {
            if (Input.GetKey(KeyCode.RightArrow) == true && r.WallDetection == false && RMoveDisabled > MoveDisableTime)
            {
                myRigidbody.linearVelocityX = movespeed;
            }
        }

        //---THE_WALL_JUMP_MECHANIC_SYSTEM---

        //Wall Jump -PUSH
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && l.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = movespeed * 1.2f;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && r.WallDetection == true && GetComponentInChildren<GroundChecker>().GroundDetection == false)
        {
            myRigidbody.linearVelocityX = -movespeed * 1.2f;
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
        if ((Input.GetKeyDown(KeyCode.UpArrow) == true || Input.GetKeyDown(KeyCode.Space) == true) && GetComponentInChildren<GroundChecker>().GroundDetection == true && (l.WallDetection == false || r.WallDetection == false) && (WallDetectionTimer > HasJumpedTimer))
        {
            myRigidbody.linearVelocityY = jumpForce;
            myAnimator.SetTrigger("Jump");
            Debug.Log("JUMP");
        }
        
        //THE_MOVE_SYSTEM

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow) == true && l.WallDetection == false && LMoveDisabled > MoveDisableTime)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }
        if (Input.GetKey(KeyCode.RightArrow) == true && r.WallDetection == false && RMoveDisabled > MoveDisableTime)
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
