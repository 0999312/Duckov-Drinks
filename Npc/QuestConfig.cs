using Duckov.Quests;
using FeatherMod;
using FeatherMod.Items;
using FeatherMod.Utils;
using System.Collections.Generic;

namespace DuckovDrinks.Npc
{
    /// <summary>
    /// 老政任务线配置。
    /// 任务通过 QuestGiverIdentifier 绑定到老政。
    /// 使用新版 Identifier-first API（itemIdentifier 替代 typeID）。
    /// </summary>
    public static class QuestConfig
    {
        /// <summary>任务 "安顿下来" — 提交基本物资，解锁苹果/橘子购买</summary>
        public static readonly Identifier QuestSettleIn = new Identifier(Constants.MODID, Constants.QUEST_LAOZHENG_SETTLE);

        public static void Register()
        {
            RegisterSettleIn();
        }

        private static void RegisterSettleIn()
        {
            GameItemLookup.TryGetIdentifier(888, out var apple);
            GameItemLookup.TryGetIdentifier(1011, out var orange);
            var quest = new QuestData
            {
                Id = QuestSettleIn,
                displayName = "quest_laozheng_settle",
                description = "quest_laozheng_settle_desc",
                QuestGiverIdentifier = new Identifier(Constants.MODID, NpcConfig.QuestGiverId),
                requireLevel = 1,
                tasks = new List<TaskData>
                {
                    new TaskRequireItem
                    {
                        itemIdentifier = new Identifier(Constants.MODID, Constants.ITEM_WHITE_SUGAR),
                        requiredAmount = 3,
                    },
                    new TaskRequireItem
                    {
                        itemIdentifier = new Identifier(Constants.MODID, Constants.ITEM_WHOLE_MILK),
                        requiredAmount = 2,
                    },
                },
                rewards = new List<RewardData>
                {
                    new RewardMoney { amount = 1000 },
                    new RewardUnlockItem { itemIdentifier = apple },
                    new RewardUnlockItem { itemIdentifier = orange },
                },
            };

            QuestUtils.RegisterQuest(QuestSettleIn, quest);
            QuestUtils.TryGetQuestIdentifier(40, out var first_xavier);
            QuestUtils.AddQuestRelation(QuestSettleIn, first_xavier);
        }
    }
}
