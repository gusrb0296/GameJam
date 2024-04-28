using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoCheese : MonoBehaviour
{
    public float crabspeed;
    private GameObject cheese;
    private Rigidbody2D rb;
    private Vector2 movement;

    bool isgotoCheese = true;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        cheese = GameObject.FindWithTag("Cheese");
        if (cheese == null)
        {
            Debug.LogError("Cheese object not found in the scene.");
        }
    }

    private void Update()
    {
        Vector3 cheesePosition = cheese.transform.position;
        Vector3 direction = cheesePosition - transform.position;

        if(direction.magnitude <= 0.25f)
        {
            isgotoCheese = false;
            print("¸ØÃã");
        }

        if(isgotoCheese)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle -= 90f;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction) * crabspeed * Time.deltaTime);
    }
}
