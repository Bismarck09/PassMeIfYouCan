using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnteringLevel : MonoBehaviour
{
    public void EnteringLevelViaMenu(int level)
    {
        SceneManager.LoadScene(level);
    }
}
