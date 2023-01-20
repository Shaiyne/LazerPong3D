using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AISignals : Singleton<AISignals>
{
    public UnityAction onStopAndOtherAICanMove = delegate { };
}
