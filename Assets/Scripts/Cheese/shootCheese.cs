using UnityEngine;

public class shootCheese : MonoBehaviour
{
    public float maxForce;
    public float maxSpeed;
    private Rigidbody2D rb;
    private Vector2 initialMousePos;

    bool isPressed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
    }

    void FixedUpdate()
    {
        if (isPressed)
        {
            Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.velocity = direction.normalized * 10f;
        }
    }
}

