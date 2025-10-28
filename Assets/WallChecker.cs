using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public bool WallDetection = false;

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
            WallDetection = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        WallDetection = false;
    }
}
