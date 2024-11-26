using Mechadroids;
using System;
using UnityEngine;

public class WorkshopLoad
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoad()
    {
        var scriptable = Resources.Load<PlayerSettings>("CharacterSettings");
        Debug.Log(scriptable.moveSpeed);

    }
}
