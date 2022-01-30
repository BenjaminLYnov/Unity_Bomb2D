using UnityEngine;
using System;

public class ShootBomb : MonoBehaviour
{
    public float force = 3;

    private bool keyShoot = true;

    private void FixedUpdate()
    {
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Bomb" && Input.GetAxisRaw("Shoot") > 0)
        {
            Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();

            int direction = getDirection();

            if (direction == 0)
                rb.AddForce(transform.up * force, ForceMode2D.Impulse);
            else if (direction == 1)
                rb.AddForce(-transform.right * force, ForceMode2D.Impulse);
            else if (direction == 2)
                rb.AddForce(-transform.up * force, ForceMode2D.Impulse);
            else if (direction == 3)
                rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        }
    }

    int getDirection()
    {
        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
            return 0;
        else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0)
            return 3;
        else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0)
            return 1;
        else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
            return 2;

        return -1;
    }
}
