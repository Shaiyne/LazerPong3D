using UnityEngine;
using UnityEngine.Events;

public class UISignals : Singleton<UISignals>
{
    public UnityAction onScoreImageCreate = delegate { };
    public UnityAction onScorePoint = delegate { };
}
