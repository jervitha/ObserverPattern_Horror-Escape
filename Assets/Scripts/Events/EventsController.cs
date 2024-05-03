using System;

public class EventsController 
{
    public Action baseEvent;
    public void AddListener(Action Listerner) => baseEvent += Listerner;
    public void RemoveListener(Action Listerner) => baseEvent -= Listerner;
    public void InvokeEvent() => baseEvent?.Invoke();
}


public class EventsController<T>
{
    public Action<T> baseEvent;
    public void AddListener(Action<T> Listerner) => baseEvent += Listerner;
    public void RemoveListener(Action<T> Listerner) => baseEvent -= Listerner;
    public void InvokeEvent(T type) => baseEvent?.Invoke(type);
}
