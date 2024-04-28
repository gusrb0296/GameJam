using UnityEngine;

public class shootCheese : MonoBehaviour
{
    public float maxForce;
    public float maxSpeed;
    public Rigidbody2D rb;
    private Vector2 initialMousePos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.velocity = direction.normalized * 10f;
            //isPressed = true;
        }
        //else
        //{
        //    isPressed = false;
        //}
    }

    void FixedUpdate()
    {
        //if (isPressed)
        //{
        //    Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    rb.velocity = direction.normalized * 10f;
        //}
    }
}

