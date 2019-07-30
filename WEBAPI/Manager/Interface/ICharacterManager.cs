using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Models;

namespace WEBAPI.Manager.Interface
{
    public interface ICharacterManager
    {
        Task<int> SaveCharacter(GameCharacter character, string userId);
        List<GameCharacter> GetAllCharacters();
        GameCharacter GetCharacter(int characterId);
        Task<int> SaveDesignedCharacter(GameCharacter character, string userId);
        List<GameCharacter> GetAllUserCharacters(string userId);

    }
}
