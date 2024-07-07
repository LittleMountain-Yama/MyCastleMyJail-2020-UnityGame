using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour, IOpen
{
    public GameObject waypoint;
    AudioSource _as;
    public AudioClip au;

    bool isActivated;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();     
    }

    private void Update()
    {
        if(isActivated)
        {
            _as.clip = au;
            _as.Play();

            if (transform.position.y < waypoint.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + (1*Time.deltaTime), transform.position.z);
            }
            else
            {
                StartCoroutine(Destroy());
            }            
        }
    }

    public void ActivateDoor()
    {
        isActivated = true;
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(Destroy());
        this.gameObject.SetActive(false);
    }

}
