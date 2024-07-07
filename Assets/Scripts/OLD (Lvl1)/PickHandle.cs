using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickHandle : MonoBehaviour
{
    public GameObject textBox, highlight;   
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

        if ((distance < 2) && (!_p.hasHandle))
        {
            textBox.SetActive(true);
            highlight.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                _p.hasHandle = true;
                _as.clip = au;
                _as.Play();
                textBox.SetActive(false);
                highlight.SetActive(false);
                StartCoroutine(Destroy());
            }
        }
        else
        {
            textBox.SetActive(false);
            highlight.SetActive(false);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(Destroy());
        Destroy(this.gameObject);
    }
}
