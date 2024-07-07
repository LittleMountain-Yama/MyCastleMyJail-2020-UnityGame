using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public GameObject textBox, waypoint, handle, highlight;
    public Door door;
    public Text textContent;

    AudioSource _as;
    Player _p;
    public List<AudioClip> au;

    public float distance;
    bool isActivated;
    public bool hasHandle;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        _p = FindObjectOfType<Player>();
        isActivated = false;

        if(!hasHandle)
        {
            handle.SetActive(false);
        }
    }

    private void Update()
    {
        distance = Vector3.Distance(_p.transform.position, transform.position);

        if ((distance < 2f) && (isActivated == false))
        {     
            textBox.SetActive(true);
            highlight.SetActive(true);

            if (hasHandle)            
            {
                textContent.text = "Press F to interact";
                if (Input.GetKeyDown(KeyCode.F))
                {
                    door.ActivateDoor();
                    isActivated = true;
                    handle.transform.position = waypoint.transform.position;

                    _as.clip = au[1];
                    _as.Play();
                }
            }
            else
            {
                textContent.text = "Something is missing";

                if(_p.hasHandle)
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hasHandle = true;
                        handle.SetActive(true);

                        _as.clip = au[0];
                        _as.Play();
                    }
                }
            }
        }
        else
        {
            textBox.SetActive(false);
            highlight.SetActive(false);
        }
       
    }
}
