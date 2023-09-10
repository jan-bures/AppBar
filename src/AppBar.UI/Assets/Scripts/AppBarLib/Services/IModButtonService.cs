using System.Collections.Generic;
using AppBarLib.Models;

namespace AppBarLib.Services
{
    internal interface IModButtonService
    {
        public void Register(ModButton button);
        public void Unregister(ModButton button);

        public ModButton GetById(string id);
        public IEnumerable<ModButton> FindByGameState(GameState state);
    }
}