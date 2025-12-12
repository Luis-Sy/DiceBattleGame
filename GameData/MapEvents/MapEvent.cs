namespace DiceBattleGame.GameData.MapEvents
{
    public abstract class MapEvent // this is the generic class used to represent map events during a campaign
    {
        protected string eventType = "undefined"; // type of map event (e.g., combat, shop, rest, story, etc.)

        public MapEvent()
        {
            // base constructor for map events
        }

        public MapEvent(int targetLevel)
        {
            // overloaded constructor for map events with target level scaling
            initializeEvent(targetLevel);
        }

        public virtual void initializeEvent(int targetLevel)
        {
            // override in derived classes to create specific map events
            // parameter is to scale event difficulty or content based on target level
        }

        public MapEvent GetMapEvent()
        {
            return this;
        }

        public virtual T? GetEventData<T>()
        {
            // override in derived classes to return specific event data
            return default;
        }
    }
}