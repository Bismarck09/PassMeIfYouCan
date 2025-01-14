using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _platformSpeed;
    [SerializeField] private Vector3 _target;

    private void Start()
    {
        transform.DOMove(_target, _platformSpeed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }

}
