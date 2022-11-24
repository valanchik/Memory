using System.Collections.Generic;

namespace Ecs
{
   public enum EntityGroup
    {
        Common
    }
    public class EntityTypeStorage
    {
        private Dictionary<EntityGroup, int> types = new Dictionary<EntityGroup, int>();

        public void CreateType(EntityGroup group, int entity)
        {
            types.Add(group, entity);
        }

        public int GetEntityByType(EntityGroup group)
        {
            if (types.ContainsKey(group))
            {
                return types[group];
            }

            return -1;
        }
    }
}