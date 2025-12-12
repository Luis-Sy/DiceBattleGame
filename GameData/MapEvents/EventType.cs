using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    internal class EventType : Attribute
    {
        // this class is used to define different types of map events
        // search for this attribute to identify event types
        public string TypeName { get; }
        public EventType(string typeName)
        {
            TypeName = typeName;
        }
    }
}
