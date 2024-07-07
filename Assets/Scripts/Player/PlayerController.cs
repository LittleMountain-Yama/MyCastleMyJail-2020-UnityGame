using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IUpdate
{
    protected delegate void DelegateUpdate();
    protected DelegateUpdate updateDelegate;

    [SerializeField] LayerMask activableMask;

    void Start()
    {
        UpdateManager.Instance.AddToUpdate(this);

        updateDelegate += ActivableDetector;
    }

    public void OnUpdate()
    {
        updateDelegate();
    }

    void ActivableDetector()
    {
        var temp = Physics.OverlapSphere(transform.position, PlayerValues.Default.interactRadius, activableMask);
        
        if(temp.Length > 0)
        {
            //Debug.Log("I detected" + temp[0].name);

            temp[0].GetComponent<BaseInteractable>().OnInteractable();

            if (Input.GetKeyDown(KeyCode.F)) temp[0].GetComponent<BaseInteractable>().Trigger();
        }        
    }
}
