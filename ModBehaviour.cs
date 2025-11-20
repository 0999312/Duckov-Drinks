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
            Debug.Log($"{Constants.MODID} awaked, version :{Constants.VERSION}. Presented by Zaia");
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
            ItemUtils.CreateCustomItem(Items.WhiteSugar);
            ItemUtils.CreateCustomItem(Items.drink05);

            ItemUtils.CreateCustomItem(Items.sodaCanLemon);
            ItemUtils.CreateCustomItem(Items.sodaCanApple);
            ItemUtils.CreateCustomItem(Items.sodaCanOrange);

            I18n.loadFileJson($"/{I18n.localizedNames[SodaCraft.Localizations.LocalizationManager.CurrentLanguage]}");

            //CraftingUtils.AddCraftingFormula("1140001", 0L, new (int, long)[2]
            //{
            //(30002, 1L),
            //(30005, 1L)
            //}, 115, 1, new string[1] { "WorkBenchAdvanced" });

            //CraftingUtils.AddCraftingFormula("1140002", 0L, new (int, long)[3]
            //{
            //(30002, 1L),
            //(30005, 1L),
            //(888, 1L),
            //}, 30004, 1, new string[1] { "WorkBenchAdvanced" });

            //CraftingUtils.AddCraftingFormula("1140003", 0L, new (int, long)[2]
            //{
            //(30005, 1L),
            //(106, 1L),
            //}, 30007, 1, new string[1] { "WorkBenchAdvanced" });

            //CraftingUtils.AddCraftingFormula("1140004", 0L, new (int, long)[2]
            //{
            //(888, 1L),
            //(106, 1L),
            //}, 30008, 1, new string[1] { "WorkBenchAdvanced" });

            //CraftingUtils.AddDecomposeFormula(1181, 0L, new (int, long)[1]
            //{
            //(30005, 1L)
            //});

            //CraftingUtils.AddDecomposeFormula(68, 0L, new (int, long)[1]
            //{
            //(30005, 2L)
            //});

            //CraftingUtils.AddDecomposeFormula(30006, 0L, new (int, long)[1]
            //{   
            //(30009, 2L)
            //});

            //CraftingUtils.AddCraftingFormula("1140005", 0L, new (int, long)[3]
            //{
            //(30009, 1L),
            //(30005, 1L),
            //(428, 1L),
            //}, 30006, 1, new string[1] { "WorkBenchAdvanced" });

            //CraftingUtils.AddCraftingFormula("1140006", 0L, new (int, long)[3]
            //{
            //(14, 1L),
            //(30005, 2L),
            //(107, 1L),
            //}, 1256, 1, new string[1] { "WorkBenchAdvanced" });
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