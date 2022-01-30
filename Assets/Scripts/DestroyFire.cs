using UnityEngine;
using System.Collections;

public class DestroyFire : MonoBehaviour
{
    public float destroyDelay = 3;

    private void Start()
    {
        StartCoroutine(CooldownDF());
    }

    public IEnumerator CooldownDF()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
