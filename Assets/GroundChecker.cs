using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool GroundDetection = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
             GroundDetection = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GroundDetection = false;
    }
}
