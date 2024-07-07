using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerText : MonoBehaviour
{
    [SerializeField] string text;
    [SerializeField] bool deactivate;

    void OnTriggerEnter(Collider other)
    {
        var temp = other.gameObject.GetComponent<PlayerController>();

        if(temp != null)
        {
            EventManager.TriggerEvent(EventManager.EventsType.Event_Text_ChangeText, text, 2f);
            AudioSystem.PlaySound(AudioSystem.SoundType.Text_Trigger, this.transform);

            if(deactivate) this.gameObject.SetActive(false);
        }
    }
}
