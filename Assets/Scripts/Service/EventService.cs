

public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
    get
        {
        if(instance==null)
        {
           instance=new EventService();
         }
            return instance;
        }


 
     }

    public EventsController OnLightSwitchToggled { get; private set; }
    public EventsController<int> OnkeyPickedup { get; private set; }
    public EventService()
    {
        OnLightSwitchToggled = new EventsController();
        OnkeyPickedup = new EventsController<int>();

    }
}




