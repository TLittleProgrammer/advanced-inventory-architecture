using EntryPoint;
using Infrastructure;

namespace Spritesheets
{
    public class SpriteSheetsMechanicLoader : SyncExecutable
    {
        protected override void SyncExecute(IGameContext context)
        {
            var model = new SpriteSheetsModel(context.Logger);
            
            context.Models.SpriteSheets = model;
            context.Controllers.Add(new SpriteSheetsController(context, model));
            context.Controllers.Add(new SpriteSheetsSetupController(context, model));
        }
    }
}