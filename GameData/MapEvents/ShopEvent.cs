using DiceBattleGame.GameData.Characters;

namespace DiceBattleGame.GameData.MapEvents
{
    [EventType("Shop")]
    internal class ShopEvent : MapEvent
    {
        public ShopEvent() : base("Shop") { }

        public override void initializeEvent(int difficultyLevel)
        {
            // this goes empty
        }

        public override T GetEventData<T>()
        {
            //shop does not return special data
            return default!;
        }
    }
}
