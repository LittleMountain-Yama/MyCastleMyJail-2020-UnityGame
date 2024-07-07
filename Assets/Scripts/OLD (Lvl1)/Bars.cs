using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bars : MonoBehaviour
{
    public GameObject textBox, highlight, player, camera;
    public Text textContent;
    public Image fade;

    AudioSource _as;
    public AudioClip au;
    Player _p;
   
    float distance;
    bool isFinished;

    private void Awake()
    {
        _p = FindObjectOfType<Player>();
        _as = GetComponent<AudioSource>();

        Color temp = fade.color;
        temp.a = 0f;
        fade.color = temp;
    }

    private void Update()
    {
        distance = Vector3.Distance(_p.transform.position, transform.position);

        if ((distance < 2) && (!isFinished))
        {
            textBox.SetActive(true);
            highlight.SetActive(true);

            if (_p.hasSaw)
            {
                textContent.text = "Interact";

                if (Input.GetKeyDown(KeyCode.F))
                {
                    isFinished = true;
                    _as.clip = au;
                    _as.Play();
                }
            }
            else
            {
                textContent.text = "The bars seems kinda thin...";
            }
        }
        else
        {
            textBox.SetActive(false);
            highlight.SetActive(false);
        }

        if(isFinished)
        {
            Color temp = fade.color;
            temp.a += 1*Time.deltaTime;
            fade.color = temp;

            StartCoroutine(Finish());      
        }
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);
        Destroy(player.gameObject);
        StopCoroutine(Finish());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
