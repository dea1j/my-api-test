using System;
using Dapper;
using MAUIapi.Context;
using MAUIapi.Contracts;
using MAUIapi.Models;

namespace MAUIapi.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DapperContext _context;

        public ImageRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task UploadImage(ImageEntity imageEntity)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "INSERT INTO ImageEntity VALUES (@ImageData, @Timestamp);";
                await connection.ExecuteAsync(sql, imageEntity);
            }

        }
    }
}

