using GameData.LocalPackages.GameData;

namespace GameData.Atlases
{
    public class AtlasesFillableData : FillableGameData<string>
    {
        public override void Fill()
        {
            Add("inventory_icons");
        }
    }
}