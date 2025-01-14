using System.Collections;
using UnityEngine;
using DG.Tweening;

public class VanishPlatform : MonoBehaviour
{
    [SerializeField] private float _vanishingTime;
    [SerializeField] private GameObject[] _childrenObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (var child in _childrenObject)
            {
                child.GetComponent<SpriteRenderer>().DOFade(0, _vanishingTime).SetEase(Ease.Linear);
                StartCoroutine(VanishingPlatform(child));
            }
        }
    }

    IEnumerator VanishingPlatform(GameObject child)
    {
        yield return new WaitForSeconds(_vanishingTime);
        child.SetActive(false);

        yield return new WaitForSeconds(3);
        child.SetActive(true);
        child.GetComponent<SpriteRenderer>().DOFade(1, 1).SetEase(Ease.Linear);
    }
}
