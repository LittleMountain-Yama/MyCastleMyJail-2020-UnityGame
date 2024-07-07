using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    List<IUpdate> _subscribers = new List<IUpdate>();
    List<IFixUpdate> _fixSubscribers = new List<IFixUpdate>();
    List<ILateUpdate> _lateSubscribers = new List<ILateUpdate>();

    static UpdateManager _instance;

    [SerializeField] GameObject pauseUI;
    public static UpdateManager Instance { get { return _instance; } private set { }}

    public bool pause { get; private set; }
    bool pausable, pauseSound;

    private void Awake()
    {
        _instance = this;
        _subscribers = new List<IUpdate>();
        pausable = true;
    }

    #region Updates
    void Update()
    {
        if (pause) return;

        AllUpdates();
    }

    void AllUpdates()
    {        
        for (int i = 0; i < _subscribers.Count; i++)
        {
            _subscribers[i].OnUpdate();           
        }                    
    }

    private void FixedUpdate()
    {
        if (pause) return;

        AllFixUpdates();
    }

    void AllFixUpdates()
    {
        for (int i = 0; i < _fixSubscribers.Count; i++)
        {
            _fixSubscribers[i].OnFixedUpdate();
        }
    }

    private void LateUpdate()
    {
        if (pause) return;

        AllLateUpdates();
    }

    void AllLateUpdates()
    {
        for (int i = 0; i < _lateSubscribers.Count; i++)
        {
            _lateSubscribers[i].OnLateUpdate();
        }
    }
    #endregion

    #region Pause
    public void PauseGame()
    {
        //EventManager.TriggerEvent(EventManager.EventsType.Event_Pause);
    }

    void PauseSetter(params object[] param)
    {
        if (!pausable) return;

        pause = !pause;

        //if(pauseSound) AudioSystem.PlaySound(AudioSystem.SoundType.Pause_Ring, transform);

        //EventManager.TriggerEvent(EventManager.EventsType.Event_Cursor_State, pause);

        PauseUI();
    }

    void PauseUI()
    {
        if (pauseUI == null) return;

        //pauseUI.SetActive(pause);
    }

    void PausableState(params object[] param)
    {
        pausable = (bool)param[0];
    }
    #endregion

    #region Manager   
    public void AddToUpdate(IUpdate element)
    {
        if (!_subscribers.Contains(element))
            _subscribers.Add(element);
    }

    public void RemoveFromUpdate(IUpdate element)
    {
        if (_subscribers.Contains(element))
            _subscribers.Remove(element);
    }

    public void AddToFixUpdate(IFixUpdate element)
    {
        if (!_fixSubscribers.Contains(element))
            _fixSubscribers.Add(element);
    }

    public void RemoveFromFixUpdate(IFixUpdate element)
    {
        if (_fixSubscribers.Contains(element))
            _fixSubscribers.Remove(element);
    }
    #endregion
}
