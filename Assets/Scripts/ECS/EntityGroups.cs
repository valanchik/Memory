using System.Collections.Generic;

namespace Ecs
{
   public enum EntityType
    {
        Common
    }
    public class EntityTypeStorage
    {
        private Dictionary<EntityType, int> types = new Dictionary<EntityType, int>();

        public void CreateType(EntityType type, int entity)
        {
            types.Add(type, entity);
        }

        public int GetEntityByType(EntityType type)
        {
            if (types.ContainsKey(type))
            {
                return types[type];
            }

            return -1;
        }
    }
}