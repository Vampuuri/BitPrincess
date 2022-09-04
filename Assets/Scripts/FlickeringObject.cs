using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public float onTime = 2f;
    public float offTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ObjectOn());
    }

    private IEnumerator ObjectOn()
    {
        spriteRenderer.enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(onTime);
        StartCoroutine(ObjectOff());
    }

    private IEnumerator ObjectOff()
    {
        spriteRenderer.enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(offTime);
        StartCoroutine(ObjectOn());
    }
}
