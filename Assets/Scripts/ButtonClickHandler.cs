using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private PlayerMovement _playerMovement;

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerMovement.Jump();
    }
}
