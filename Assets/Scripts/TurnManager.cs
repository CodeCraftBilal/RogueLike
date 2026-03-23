using UnityEngine;

public class TurnManager
{
    public event System.Action OnTick;
    private int m_TurnCount;

    public TurnManager()
    {
        m_TurnCount = 1;
    }

    public void Tick()
    {
        m_TurnCount +=1;
        OnTick?.Invoke();
        Debug.Log("Current Turn Count " + m_TurnCount);
    }
}
