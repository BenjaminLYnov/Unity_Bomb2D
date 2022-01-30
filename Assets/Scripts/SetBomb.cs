using UnityEngine;

public class SetBomb : MonoBehaviour
{
    public GameObject bomb;
    public float cooldownSetBomb = 3;

    private float timerSetBombe = 0;

    private void FixedUpdate()
    {
        if (timerSetBombe < 3)
            timerSetBombe += Time.fixedDeltaTime;

        if (Input.GetAxisRaw("SetBomb") > 0 && timerSetBombe >= cooldownSetBomb)
        {
            timerSetBombe = 0;
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }
}
