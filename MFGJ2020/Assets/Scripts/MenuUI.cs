using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
    public GameObject instructions;
    public GameObject title;
    public GameObject credits;

    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void TransitionTo(GameObject start, GameObject target)
    {
        start.SetActive(false);
        StartCoroutine("WaitForSeconds(1f)");
        target.SetActive(true);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}

