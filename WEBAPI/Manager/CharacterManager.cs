﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Manager.Interface;
using WEBAPI.Models;

namespace WEBAPI.Manager
{
    public class CharacterManager: ICharacterManager
    {
        private AuthenticationContext _context;
        public CharacterManager(AuthenticationContext context)
        {
            _context = context;
        }

        public List<GameCharacter> GetAllCharacters()
        {
            var gameCharacters = new List<GameCharacter>();
            var characters = _context.Characters.Select(m => m).ToList();
            gameCharacters.AddRange(characters.Select(m => MapToGameCharacter(m)));
            return gameCharacters;
        }

        public List<GameCharacter> GetAllUserCharacters(string userId)
        {
            var userCharacters = new List<GameCharacter>();
            var characters = _context.UserCharacters.Select(m => m).Where(m => m.UserId == userId).ToList();
            userCharacters.AddRange(characters.Select(m => MapToUserCharacter(m)));
            return userCharacters;
        }

        private GameCharacter MapToUserCharacter(UserCharacter m)
        {
            var result = JsonConvert.DeserializeObject<GameCharacter>(m.CharacterDescription);
            return result;
        }

        public GameCharacter GetCharacter(int characterId)
        {
            var character = _context.Characters.First(m => m.CharacterId == characterId);
            return MapToGameCharacter(character);
        }

        public async Task<int> SaveCharacter(GameCharacter character, string userId)
        {
            if (_context.Characters.Any(m => m.CharacterName == character.CharacterName))
                return 2;
            var characterDescription = JsonConvert.SerializeObject(character);
            var gameCharacter = new Character()
            {
                CharacterName = character.CharacterName,
                CharacterDescription = characterDescription,
                CreatedByUserId = userId
            };
            _context.Characters.Add(gameCharacter);
            var x = await _context.SaveChangesAsync();
            return x;
        }

        public async Task<int> SaveDesignedCharacter(GameCharacter character, string userId)
        {
            if (_context.UserCharacters.Any(m => m.CharacterName == character.Name && m.UserId == userId))
                return 2;
            var characterDescription = JsonConvert.SerializeObject(character);
            var gameCharacter = new UserCharacter()
            {
                CharacterType = character.CharacterName,
                CharacterName = character.Name,
                CharacterDescription = characterDescription,
                UserId = userId
            };
            _context.UserCharacters.Add(gameCharacter);
            var result = await _context.SaveChangesAsync();
            return result;
        }

        private GameCharacter MapToGameCharacter(Character m)
        {
            var result = JsonConvert.DeserializeObject<GameCharacter>(m.CharacterDescription);
            result.CharacterId = m.CharacterId;
            return result;
        }


    }
}
