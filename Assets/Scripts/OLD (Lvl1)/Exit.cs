using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject button;

    private void Awake()
    {
        StartCoroutine(ShowButton());
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        //Application.Quit();
    }

    IEnumerator ShowButton()
    {
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(ShowButton());
        button.SetActive(true);
    }
}
