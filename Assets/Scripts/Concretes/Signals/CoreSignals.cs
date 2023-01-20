using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoreSignals : Singleton<CoreSignals>
{
    public UnityAction onGameBegin = delegate { };
    public UnityAction onGameEnded = delegate { };
    public UnityAction onGameRestart = delegate { };
    public UnityAction on2DGameOpen = delegate { };
    public UnityAction on3DGameOpen = delegate { };
}
