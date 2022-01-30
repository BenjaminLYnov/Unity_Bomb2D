using UnityEngine;
using System;

public class Firing : MonoBehaviour
{
    public GameObject fireHorizontal;
    public GameObject fireVertical;

    public GameObject fireEndUp;
    public GameObject fireEndDown;
    public GameObject fireEndRight;
    public GameObject fireEndLeft;

    void Start()
    {
        createDirectionalFire();
    }

    private void createDirectionalFire()
    {
        int distanceFire = 0;

        // Fire Up
        distanceFire = getFireDistance(Vector2.up);

        if (distanceFire == 1)
            Instantiate(fireEndUp, new Vector3(transform.position.x, transform.position.y + 1.5f, 0), Quaternion.identity);
        else
            for (int i = 1; i < distanceFire; i++)
            {
                Instantiate(fireHorizontal, new Vector3(transform.position.x, transform.position.y + 1.5f * i, 0), Quaternion.identity);
                if (i == distanceFire - 1)
                    Instantiate(fireEndUp, new Vector3(transform.position.x, transform.position.y + 1.5f * (i + 1), 0), Quaternion.identity);
            }


        // Fire Down
        distanceFire = getFireDistance(Vector2.down);
        if (distanceFire == 1)
            Instantiate(fireEndDown, new Vector3(transform.position.x, transform.position.y - 1.5f, 0), Quaternion.identity);
        else
            for (int i = 1; i < distanceFire; i++)
            {
                Instantiate(fireHorizontal, new Vector3(transform.position.x, transform.position.y - 1.5f * i, 0), Quaternion.identity);
                if (i == distanceFire - 1)
                    Instantiate(fireEndDown, new Vector3(transform.position.x, transform.position.y - 1.5f * (i + 1), 0), Quaternion.identity);
            }

        // Fire Left
        distanceFire = getFireDistance(Vector2.left);
        if (distanceFire == 1)
            Instantiate(fireEndLeft, new Vector3(transform.position.x - 1.5f, transform.position.y, 0), Quaternion.identity);
        else
            for (int i = 1; i < distanceFire; i++)
            {
                Instantiate(fireVertical, new Vector3(transform.position.x - 1.5f * i, transform.position.y, 0), Quaternion.identity);
                if (i == distanceFire - 1)
                    Instantiate(fireEndLeft, new Vector3(transform.position.x - 1.5f * (i + 1), transform.position.y, 0), Quaternion.identity);
            }

        // Fire Right
        distanceFire = getFireDistance(Vector2.right);
        if (distanceFire == 1)
            Instantiate(fireEndRight, new Vector3(transform.position.x + 1.5f, transform.position.y, 0), Quaternion.identity);
        else
            for (int i = 1; i < distanceFire; i++)
            {
                Instantiate(fireVertical, new Vector3(transform.position.x + 1.5f * i, transform.position.y, 0), Quaternion.identity);
                if (i == distanceFire - 1)
                    Instantiate(fireEndRight, new Vector3(transform.position.x + 1.5f * (i + 1), transform.position.y, 0), Quaternion.identity);
            }
    }

    private int getFireDistance(Vector2 vector2)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, vector2, 8);
        float distanceFire = 5;

        // If it hits something...
        if (hit.collider != null && hit.transform.tag == "Wall")
        {
            if (hit.distance < 8)
            {
                distanceFire = hit.distance * 5 / 8;
                if (distanceFire < 1)
                    return 0;
                else
                    distanceFire = (float)Math.Round(distanceFire, 0);
            }
        }

        return (int)distanceFire;
    }

}
