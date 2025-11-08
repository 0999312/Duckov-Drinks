using Duckov.UI;
using Duckov.Utilities;
using ItemStatsSystem;
using System;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

namespace DuckovDrinks
{
    
    public class ModBehaviour : Duckov.Modding.ModBehaviour
    {
        
        void Awake()
        {

            Debug.Log("Drinks awaked. Presented by Zaia");
            SodaCraft.Localizations.LocalizationManager.OnSetLanguage += (lang) => {
                if (I18n.localizedNames.ContainsKey(lang))
                {
                    I18n.loadFileJson($"/{I18n.localizedNames[lang]}");
                }
                else
                {
                    I18n.loadFileJson($"/{I18n.localizedNames[SystemLanguage.English]}");
                }
            };
        }

        protected override void OnBeforeDeactivate()
        {
            CraftingUtils.RemoveAllAddedFormulas();
            CraftingUtils.RemoveAllAddedDecomposeFormulas();
        }


        protected override void OnAfterSetup()
        {
            ItemUtils.CreateCustomItem(Items.drink01);
            ItemUtils.CreateCustomItem(Items.drink02);
            ItemUtils.CreateCustomItem(Items.drink03);
            ItemUtils.CreateCustomItem(Items.drink04);

            CraftingUtils.AddCraftingFormula("1140001", 0L, new (int, long)[2]
            {
            (30002, 1L),
            (1181, 1L),
            }, 115, 1, new string[1] { "WorkBenchAdvanced" });

            CraftingUtils.AddCraftingFormula("1140002", 0L, new (int, long)[2]
            {
            (30002, 1L),
            (888, 1L),
            }, 30004, 1, new string[1] { "WorkBenchAdvanced" });
            I18n.loadFileJson($"/{I18n.localizedNames[SodaCraft.Localizations.LocalizationManager.CurrentLanguage]}");
        }


        void OnDestroy()
        {

        }
        void OnEnable()
        {

        }
        void OnDisable()
        {

        }


    }
}