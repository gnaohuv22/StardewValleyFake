using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{

    public Action onTimeTick;
    private void Start()
    {
        GameManager.instance.timeController.Subscrbe(this);
    }

    public void Invoke()
    {
        onTimeTick?.Invoke();
    }
    private void OnDestroy()
    {
        GameManager.instance.timeController.Unsubscrbe(this);
    }
}
