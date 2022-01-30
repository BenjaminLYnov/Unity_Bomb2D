using UnityEngine;
using System.Collections;

public class BombExplose : MonoBehaviour
{
    public float exploseDelay = 3;
    public GameObject fire;

    private Collider2D col;

    private void Start()
    {
        col = GetComponent<Collider2D>();
        StartCoroutine(CooldownExplose());
    }

    public IEnumerator CooldownExplose()
    {
        yield return new WaitForSeconds(exploseDelay);
        Instantiate(fire, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D other) {
        col.isTrigger = false;
    }
}
