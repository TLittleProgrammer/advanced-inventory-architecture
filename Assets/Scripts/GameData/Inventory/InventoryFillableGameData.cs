using Data.Inventory;
using GameData.LocalPackages.GameData;

namespace DefaultNamespace.GameData.Inventory
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
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ManaPotion,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ManaPotion)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.MoonElixir,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.MoonElixir)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.HoneyFlask,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.HoneyFlask)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.EmeraldCrystalCluster,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.EmeraldCrystalCluster)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LavenderCrystalShard,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LavenderCrystalShard)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.Moonstone,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.Moonstone)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.FireGemstone,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.FireGemstone)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ShortSword,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ShortSword)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.CrescentAxe,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.CrescentAxe)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeafwoodBow,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeafwoodBow)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.FeatherArrowQuiver,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.FeatherArrowQuiver)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.OakWand,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.OakWand)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SunShield,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SunShield)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SilverDagger,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SilverDagger)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.BronzeLantern,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.BronzeLantern)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.WizardHat,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.WizardHat)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.ForestHood,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.ForestHood)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.AdventurerBoots,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.AdventurerBoots)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeatherGloves,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeatherGloves)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.BlueCloak,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.BlueCloak)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.LeatherSatchel,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.LeatherSatchel)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.AncientSpellbook,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.AncientSpellbook)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SealedScroll,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SealedScroll)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.GoldenKey,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.GoldenKey)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SapphireRing,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SapphireRing)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.SunAmulet,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.SunAmulet)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.MushroomCluster,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.MushroomCluster)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.HealingHerbs,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.HealingHerbs)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.IridescentFeather,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.IridescentFeather)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.CoinPouch,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.CoinPouch)),
                    maxCount: 64
                )
            );
            Add
            (
                key: ResourceType.TreasureChest,
                value: resource_data
                (
                    spriteData: sprite(AtlasId, nameof(ResourceType.TreasureChest)),
                    maxCount: 64
                )
            );
        }

        private InventoryResourceData resource_data(SpriteData spriteData, int maxCount) => new(spriteData, maxCount);
        private SpriteData sprite(string atlasId, string spriteId) => new(atlasId, spriteId);
    }
}