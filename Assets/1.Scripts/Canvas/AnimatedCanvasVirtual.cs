using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedCanvasVirtual : MonoBehaviour, IAnimatedCanvas
{
    [SerializeField] protected float AnimDuration = 0.5f;
    public virtual IEnumerator OnOpen()
    {
        gameObject.SetActive(true);
        if (transform.GetComponent<CanvasGroup>())
        {
            transform.GetComponent<CanvasGroup>().alpha = 0f;
            transform.GetComponent<CanvasGroup>().gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(AnimDuration);
    }

    public virtual IEnumerator OnClose()
    {
        if (transform.GetComponent<CanvasGroup>())
        {
            transform.GetComponent<CanvasGroup>().gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        yield return new WaitForSeconds(AnimDuration);
    }
}
