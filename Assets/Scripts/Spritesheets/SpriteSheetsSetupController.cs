using Infrastructure;
using LocalPackages.MVC;

namespace Spritesheets
{
    public sealed class SpriteSheetsSetupController : IController
    {
        private readonly IGameContext _context;
        private readonly SpriteSheetsModel _model;

        public SpriteSheetsSetupController(IGameContext context, SpriteSheetsModel model)
        {
            _context = context;
            _model = model;
        }

        public void Activate()
        {
            foreach (var atlasId in _context.Data.Atlases)
            {
                _model.LoadAtlasRequest.Call(atlasId);
            }
        }

        public void Deactivate() { }
    }
}