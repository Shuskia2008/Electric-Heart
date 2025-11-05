using UnityEngine;

public class Non_GroundChecker : MonoBehaviour
{
    public bool NonGROUNDDetection = false;

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
            NonGROUNDDetection = true;
            Debug.Log("CEILLLLLLLIIIIIIINNNNNGGG");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        NonGROUNDDetection = false;
        Debug.Log("NOOOOOOOOOOOOOOOOOOO-CEILLLLLLLIIIIIIINNNNNGGG");
    }
}
