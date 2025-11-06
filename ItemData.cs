using Duckov.Buffs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DuckovDrinks
{
    public class ItemData
    {
        public int itemId;

        public int order = 0;

        public string displayName = string.Empty;

        public string localizationKey = string.Empty;

        public string localizationDesc = string.Empty;

        public string localizationDescValue = string.Empty;

        public float weight;

        public int value;

        public int maxStackCount = 1;

        public float maxDurability = 0f;

        public int quality;

        public string embeddedSpritePath = string.Empty;

        public List<string> tags = new List<string>();

        public UsageData? usages;  
    }

    public class UsageData {
        public string actionSound = string.Empty;
        public string useSound = string.Empty;
        public bool useDurability = false;
        public int durabilityUsage = 1;
        public float useTime = 2;

        public List<UsageBehaviorData> behaviors = new List<UsageBehaviorData>();
    }
    public abstract class UsageBehaviorData
    {
        public abstract string type { get;}
    }
    public class FoodData : UsageBehaviorData
    {
        public float energyValue;
        public float waterValue;

        public override string type { get; } = "FoodDrink";
    }

    public class HealData : UsageBehaviorData
    {
        public int healValue;

        public override string type { get; } = "Drug"; 
    }

    public class AddBuffData : UsageBehaviorData
    {
        public Buff buff;
        public float chance = 1f;

        
       public override string type { get; } = "AddBuff"; 
    }

    public class RemoveBuffData : UsageBehaviorData
    {
        public int buffID;
        public int removeLayerCount = 2;

        public override string type { get; } = "RemoveBuff";
    }
}
