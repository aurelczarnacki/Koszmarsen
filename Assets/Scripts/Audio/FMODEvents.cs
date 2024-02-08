using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour
{
    #region Singleton
    public static FMODEvents Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    [field: SerializeField] public EventReference mainMusic { get; private set; }

    [field: SerializeField] public EventReference slide { get; private set; }

    [field: SerializeField] public EventReference heartbeat { get; private set; }
    [field: SerializeField] public EventReference heal { get; private set; }

    [field: SerializeField] public EventReference ghostMode { get; private set; }
    [field: SerializeField] public EventReference speed { get; private set; }
    [field: SerializeField] public EventReference coin { get; private set; }
}

