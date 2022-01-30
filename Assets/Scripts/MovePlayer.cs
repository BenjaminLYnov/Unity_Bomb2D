using UnityEngine;
using System;

public class MovePlayer : MonoBehaviour
{
    public float speedMove = 10;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;

        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        if (zMov > 0 || zMov < 0)
            xMov = 0;

        Vector2 direction = new Vector2(xMov, zMov).normalized;
        transform.Translate(direction * speedMove * Time.fixedDeltaTime);
    }
}
