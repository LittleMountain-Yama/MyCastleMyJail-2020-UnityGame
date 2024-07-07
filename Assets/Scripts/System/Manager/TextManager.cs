using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour,IUpdate
{
    [SerializeField] Text text;
    [SerializeField] GameObject image;

    protected delegate void DelegateUpdate();
    protected DelegateUpdate updateDelegate;

    float limit, counter;

    void Awake()
    {
        EventManager.SubscribeToEvent(EventManager.EventsType.Event_Text_ChangeText, TextChange);
        updateDelegate += Timer;
    }

    void Start()
    {
        text = GetComponentInChildren<Text>();

        image.gameObject.SetActive(false);
    }

    void TextChange(params object[] param)
    {
        if (text != null)
        {
            image.gameObject.SetActive(true);
            text.gameObject.SetActive(true);
            text.text = (string)param[0];
        }

        limit = (float)param[1];
        UpdateManager.Instance.AddToUpdate(this);
    }

    public void OnUpdate()
    {
        updateDelegate();
    }

    float ratio = 1;
    void Timer()
    {
        counter += Time.deltaTime * ratio;

        if (counter >= limit)
        {
            counter = 0;
            StartCoroutine(SmallDelay());
        }
    }

    void Test()
    {
        text.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(0.1f);
        StopCoroutine(SmallDelay());

        Test();
        UpdateManager.Instance.RemoveFromUpdate(this);
    }
}
