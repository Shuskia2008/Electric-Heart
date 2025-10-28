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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && l.WallDetection == true)
        {
            myRigidbody.linearVelocityX = movespeed;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && r.WallDetection == true)
        {
            myRigidbody.linearVelocityX = -movespeed;
        }

        myAnimator.SetFloat("X velocity", myRigidbody.linearVelocityX);

    }
}
