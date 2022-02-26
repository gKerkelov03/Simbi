﻿using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    public sealed class UserManager
    {
        private static readonly UserManager instance = new UserManager();

        private SHA256 sha = SHA256.Create();
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private UserManager()
        {            
        }

        public ApplicationUser TryGetUserWithCredentials(string username, string password) =>
            this.dbContext.Users.Single(user => user.Password == this.Hash(password) && user.Username == username);

          
        public void TryCreateUserWithCredentials(string username, string password)
        {
            var suchUserAlreadyExists = this.dbContext.Users.Any(user => user.Password == password || user.Username == username);

            if (suchUserAlreadyExists)
            {
                throw new ArgumentException("Such user already exists");
            }

            this.dbContext.Users.Add(new ApplicationUser()
            {
                Username = username,
                Password = password
            });
        }

        private string Hash(string password) =>        
            string.Join("", this.sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
        
        public static UserManager Instance
        {
            get
            {
                return instance;
            }
        }
    }
}