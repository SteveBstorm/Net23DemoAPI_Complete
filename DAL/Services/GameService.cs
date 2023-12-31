﻿using DAL.Entities;
using DAL.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class GameService : IGameRepository
    {
        private readonly IDbConnection connection;

        public GameService(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            string sql = "SELECT * FROM Game";
            return await connection.QueryAsync<Game>(sql);
        }

        public async Task<Game> GetById(int Id)
        {
            string sql = "SELECT * FROM Game WHERE Id = @Id";
        
            var param = new { Id = Id };
            return await connection.QueryFirstAsync<Game>(sql, param);
        }

        public void CreateGame(Game g)
        {
            string sql = "INSERT INTO Game (Title, Note, ReleaseYear, Genre)" +
                " VALUES (@Title, @Note, @ReleaseYear, @Genre)";

            connection.Execute(sql, g);
        }
    }
}
