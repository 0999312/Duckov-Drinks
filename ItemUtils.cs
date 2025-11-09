using Duckov.Buffs;
using Duckov.ItemUsage;
using Duckov.Modding;
using Duckov.Utilities;
using ItemStatsSystem;
using ItemStatsSystem.Items;
using SodaCraft.Localizations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

namespace DuckovDrinks
{
    public static class ItemUtils {
        private class ResourceHolder : MonoBehaviour
        {
            public Texture2D iconTexture;

            public Sprite iconSprite;
        }

        private static void createUsage(Item item, ItemData config) {
            if (config.usages == null)
                return;

            item.AddComponent<UsageUtilities>();
            UsageUtilities usageUtilities = item.GetComponent<UsageUtilities>();

            if (config.usages.useSound != string.Empty) {
                usageUtilities.hasSound = true;
                usageUtilities.useSound = config.usages.useSound;
            }
            if (config.usages.actionSound != string.Empty) {
                usageUtilities.hasSound = true;
                usageUtilities.actionSound = config.usages.actionSound;
            }
            if (config.usages.useDurability && config.maxDurability > 0) {
                usageUtilities.useDurability = true;
                usageUtilities.durabilityUsage = config.usages.durabilityUsage;
            }

            FieldInfo useTimeField = typeof(UsageUtilities).GetField("useTime", BindingFlags.Instance | BindingFlags.NonPublic);
            if (useTimeField != null)
                useTimeField.SetValueOptimized(usageUtilities, config.usages.useTime);
            SetPrivateField(item, "usageUtilities", usageUtilities);

            foreach (var behavior in config.usages.behaviors)
            {
                 createBehavior(item, behavior, item.UsageUtilities);
            }

        }

        public static void createBehavior(Item item, UsageBehaviorData behaviorData, UsageUtilities usageUtilities)
        {
            if (behaviorData == null)
                return ;

            switch (behaviorData.type)
            {
                case "FoodDrink":
                    {
                        FoodData? foodData = behaviorData as FoodData;
                        if (foodData != null)
                        {
                            FoodDrink foodDrinkBehavior = item.AddComponent<FoodDrink>();
                            foodDrinkBehavior.energyValue = foodData.energyValue;
                            foodDrinkBehavior.waterValue = foodData.waterValue;
                            usageUtilities.behaviors.Add(foodDrinkBehavior);
                            return;
                        }
                        break;
                    }
                case "Drug":
                    {
                        HealData? healData = behaviorData as HealData;
                        if (healData != null)
                        {
                            Drug drugBehavior = item.AddComponent<Drug>();
                            drugBehavior.healValue = healData.healValue;
                            usageUtilities.behaviors.Add(drugBehavior);
                            return;
                        }
                        break;
                    }
                case "AddBuff":
                    {
                        AddBuffData? addBuffData = behaviorData as AddBuffData;
                        Buff? buff = addBuffData != null ? AddBuffData.findBuff(addBuffData.buff) : null;
                        if (addBuffData != null && buff != null)
                        {
                            AddBuff addBuffBehavior = item.AddComponent<AddBuff>();
                            addBuffBehavior.buffPrefab = buff;
                            addBuffBehavior.chance = addBuffData.chance;
                            usageUtilities.behaviors.Add(addBuffBehavior);
                            return;
                        }
                        break;
                    }
                case "RemoveBuff":
                    {
                        RemoveBuffData? removeBuffData = behaviorData as RemoveBuffData;
                        if (removeBuffData != null)
                        {
                            RemoveBuff buffBehavior = item.AddComponent<RemoveBuff>();
                            buffBehavior.buffID = removeBuffData.buffID;
                            buffBehavior.removeLayerCount = removeBuffData.removeLayerCount;
                            usageUtilities.behaviors.Add(buffBehavior);
                            return;
                        }
                        break;
                    }
                default:
                    break;
            }
            Debug.LogError($"unexpected usage type: {behaviorData.type}");
        }

        public static Sprite LoadEmbeddedSprite(string resourceName, int NEW_ITEM_ID)
        {
            try
            {
                string dllPath = Assembly.GetExecutingAssembly().Location;
                string modDirectory = Path.GetDirectoryName(dllPath);
                StringBuilder assetLoc = new StringBuilder($"assets/{Constants.MODID}/textures/");
                assetLoc.Append(resourceName);
                string fileLoc = Path.Combine(modDirectory, assetLoc.ToString());
                if(File.Exists(fileLoc) == false)
                {
                    Debug.LogError("EmbeddedSprite is missing: " + fileLoc);
                    return null;
                }

                byte[] ImageArray = File.ReadAllBytes(fileLoc);
                Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, mipChain: false);
                if (!texture2D.LoadImage(ImageArray))
                {
                    Debug.LogError($"Invaild sprite image, Resource:{resourceName}");
                    return null;
                }
                texture2D.filterMode = FilterMode.Bilinear;
                texture2D.Apply();
                Sprite sprite = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f);
                GameObject gameObject = new GameObject($"IconHolder_{NEW_ITEM_ID}");
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                ResourceHolder resourceHolder = gameObject.AddComponent<ResourceHolder>();
                resourceHolder.iconTexture = texture2D;
                resourceHolder.iconSprite = sprite;
                Debug.Log($"Loaded texture resource:{resourceName}");
                return sprite;
            }
            catch (Exception arg)
            {
                Debug.LogError($"Except on loading sprite: {arg}");
                return null;
            }
        }

        public static void CreateCustomItem(ItemData config)
        {
            try
            {
                GameObject gameObject = new GameObject($"GameObject_{config.localizationKey}");
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
                gameObject.AddComponent<Item>();
                Item component = gameObject.GetComponent<Item>();
                SetItemProperties(component, config);
                SetItemIcon(component,config);
                RegisterItem(component);
            }
            catch (Exception arg)
            {
                Debug.LogError($"Exception at creating item: {arg}");
            }
        }

        public static void SetItemProperties(Item item, ItemData config)
        {
            SetPrivateField(item, "typeID", config.itemId);
            SetPrivateField(item, "order", config.order);
            SetPrivateField(item, "weight", config.weight);
            SetPrivateField(item, "value", config.value);
            SetPrivateField(item, "displayName", config.localizationKey);
            SetPrivateField(item, "quality", config.quality);
            
            item.MaxStackCount = config.maxStackCount;
            item.MaxDurability = config.maxDurability;
            item.Durability = config.maxDurability;

            ItemUtils.createUsage(item, config);
            item.Tags.Clear();
            foreach (string tagName in config.tags)
            {
                item.Tags.Add(GetTargetTag(tagName));
            }
        }

        public static Tag GetTargetTag(string tagName)
        {
            Tag[] source = Resources.FindObjectsOfTypeAll<Tag>();
            return source.FirstOrDefault((Tag t) => t.name == tagName);
        }

        public static bool SetPrivateField(Item item, string fieldName, object value)
        {
            FieldInfo field = typeof(Item).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                field.SetValueOptimized(item, value);
                return true;
            }
            Debug.LogWarning($"Couldn't find field: {fieldName}");
            return false;
        }

        public static object GetPrivateField(Item item, string fieldName)
        {
            FieldInfo field = typeof(Item).GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                return field.GetValueOptimized(item);
            }
            Debug.LogWarning($"Couldn't find field: {fieldName}");
            return null;
        }

        private static void SetItemIcon(Item item, ItemData config)
        {
            FieldInfo field = typeof(Item).GetField("icon", BindingFlags.Instance | BindingFlags.NonPublic);

            if (field != null)
            {
                Sprite sprite = ItemUtils.LoadEmbeddedSprite(config.embeddedSpritePath, config.itemId);
                field.SetValueOptimized(item, sprite);
            }
        }

        public static void RegisterItem(Item item)
        {
            ItemAssetsCollection.AddDynamicEntry(item);
            Debug.Log($"Registered custom item: {item.TypeID} - {item.DisplayName}");
        }
    }
}  
