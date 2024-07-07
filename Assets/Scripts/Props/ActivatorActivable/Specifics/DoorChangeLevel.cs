using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorChangeLevel : BaseInteractable
{
    [SerializeField] GameObject player;

    void Awake()
    {
        offset = transform.forward * 2;
    }

    public override void Trigger()
    {
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
