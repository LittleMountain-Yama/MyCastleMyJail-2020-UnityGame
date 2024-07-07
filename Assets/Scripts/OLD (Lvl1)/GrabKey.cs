using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabKey : MonoBehaviour
{
    public GameObject textBox, highlight, destroy;   

    Player _p;
    AudioSource _as;
    public AudioClip au;

    float distance;    

    private void Awake()
    {
        _p = FindObjectOfType<Player>();
        _as = GetComponent<AudioSource>();
    }

    private void Update()
    {
        distance = Vector3.Distance(_p.transform.position, transform.position);

        if ((distance < 2.3f) && (!_p.hasSaw))
        {
            textBox.SetActive(true);
            highlight.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {                
                _p.hasSaw = true;
                Destroy(destroy.gameObject);
                _as.clip = au;
                _as.Play();
            }
        }
        else
        {
            textBox.SetActive(false);
            highlight.SetActive(false);
        }
    }
}
