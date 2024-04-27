using UnityEngine;

public class shootCheese : MonoBehaviour
{
    public float maxForce;
    public float maxSpeed;
    private Rigidbody2D rb;
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
            rb.AddForce(direction.normalized * maxForce, ForceMode2D.Impulse);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}

