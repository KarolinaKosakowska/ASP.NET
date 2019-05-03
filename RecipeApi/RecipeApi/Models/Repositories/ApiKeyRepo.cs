﻿using RecipeApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models.Repositories
{

    public class ApiKeyRepo : IApiKeyRepo
    {
        private readonly RecipeContext context;

        public ApiKeyRepo(RecipeContext context)
        {
            this.context = context;

        }
                
    
        public bool CheckApiKey(string key)
        {
            return context.Keys.Any(k => k.Name == key);
        }

        public Dictionary<string, string> GetDictionary()
        {
            var list = context.Keys.Where(a => a.ExpirationDate >= DateTime.Now).ToList();
            var names = list.Select(a => a.Name).Distinct().ToList();
            var dictionary = new Dictionary<string, string>();
            names.ForEach(n =>
            {
                dictionary.Add(n, list.First(k => k.Name == n).Role);

            });
            return dictionary;
        }

        public Task<List<string>> GetKeys()
        {
            throw new NotImplementedException();
        }
    }
}
