using System;

public class EventsController 
{
    public Action baseEvent;
    public void AddListener(Action Listerner) => baseEvent += Listerner;
    public void RemoveListener(Action Listerner) => baseEvent -= Listerner;
    public void InvokeEvent() => baseEvent?.Invoke();
}
