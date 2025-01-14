using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompletedLevels : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private Button[] _buttons;

    private int _levelComplete;

    private void Start()
    {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");

        switch (_levelComplete)
        {
            case 1:
                _buttons[0].interactable = true;
                Destroy(_panels[0]);
                break;
            case 2:
                _buttons[0].interactable = true;
                Destroy(_panels[0]);
                _buttons[1].interactable = true;
                Destroy(_panels[1]);
                break;
            case 3:
                _buttons[0].interactable = true;
                Destroy(_panels[0]);
                _buttons[1].interactable = true;
                Destroy(_panels[1]);
                _buttons[2].interactable = true;
                Destroy(_panels[2]);
                break;
            case 4:
                _buttons[0].interactable = true;
                Destroy(_panels[0]);
                _buttons[1].interactable = true;
                Destroy(_panels[1]);
                _buttons[2].interactable = true;
                Destroy(_panels[2]);
                _buttons[3].interactable = true;
                Destroy(_panels[3]);
                break;
        }
    }
}
