using GameData.LocalPackages.GameData;
using Inventory.Resource;

namespace GameData.Inventory
{
    public sealed class InventoryFillableGameData : FillableGameData<ResourceType, InventoryResourceData>
    {
        private const string AtlasId = "inventory_icons";
        
        public override void FillData()
        {
            Add
            (
                key: ResourceType.RubyPotion,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.RubyPotion)),
                    nameof(ResourceType.RubyPotion),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ManaPotion,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ManaPotion)),
                    nameof(ResourceType.ManaPotion),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.MoonElixir,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.MoonElixir)),
                    nameof(ResourceType.MoonElixir),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.HoneyFlask,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.HoneyFlask)),
                    nameof(ResourceType.HoneyFlask),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.EmeraldCrystalCluster,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.EmeraldCrystalCluster)),
                    nameof(ResourceType.EmeraldCrystalCluster),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LavenderCrystalShard,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LavenderCrystalShard)),
                    nameof(ResourceType.LavenderCrystalShard),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.Moonstone,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.Moonstone)),
                    nameof(ResourceType.Moonstone),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.FireGemstone,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.FireGemstone)),
                    nameof(ResourceType.FireGemstone),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ShortSword,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ShortSword)),
                    nameof(ResourceType.ShortSword),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.CrescentAxe,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.CrescentAxe)),
                    nameof(ResourceType.CrescentAxe),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeafwoodBow,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeafwoodBow)),
                    nameof(ResourceType.LeafwoodBow),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.FeatherArrowQuiver,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.FeatherArrowQuiver)),
                    nameof(ResourceType.FeatherArrowQuiver),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.OakWand,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.OakWand)),
                    nameof(ResourceType.OakWand),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SunShield,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SunShield)),
                    nameof(ResourceType.SunShield),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SilverDagger,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SilverDagger)),
                    nameof(ResourceType.SilverDagger),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.BronzeLantern,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.BronzeLantern)),
                    nameof(ResourceType.BronzeLantern),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.WizardHat,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.WizardHat)),
                    nameof(ResourceType.WizardHat),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ForestHood,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ForestHood)),
                    nameof(ResourceType.ForestHood),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.AdventurerBoots,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.AdventurerBoots)),
                    nameof(ResourceType.AdventurerBoots),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeatherGloves,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeatherGloves)),
                    nameof(ResourceType.LeatherGloves),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.BlueCloak,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.BlueCloak)),
                    nameof(ResourceType.BlueCloak),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeatherSatchel,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeatherSatchel)),
                    nameof(ResourceType.LeatherSatchel),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.AncientSpellbook,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.AncientSpellbook)),
                    nameof(ResourceType.AncientSpellbook),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SealedScroll,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SealedScroll)),
                    nameof(ResourceType.SealedScroll),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.GoldenKey,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.GoldenKey)),
                    nameof(ResourceType.GoldenKey),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SapphireRing,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SapphireRing)),
                    nameof(ResourceType.SapphireRing),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SunAmulet,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SunAmulet)),
                    nameof(ResourceType.SunAmulet),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.MushroomCluster,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.MushroomCluster)),
                    nameof(ResourceType.MushroomCluster),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.HealingHerbs,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.HealingHerbs)),
                    nameof(ResourceType.HealingHerbs),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.IridescentFeather,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.IridescentFeather)),
                    nameof(ResourceType.IridescentFeather),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.CoinPouch,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.CoinPouch)),
                    nameof(ResourceType.CoinPouch),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.TreasureChest,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.TreasureChest)),
                    nameof(ResourceType.TreasureChest),
                    maxCount: 64
                )
            );
        }

        private InventoryResourceData resource_data(SpriteData spriteData, string name, int maxCount) => new(spriteData, name, maxCount);
        private SpriteData sprite(string atlasId, string spriteId) => new(atlasId, spriteId);
    }
}