using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace SimpleSso
{
    public class SsoManager : ISsoManager
    {
        private string _connectionString;
        private DbType _dbType;
        private int _tokenLifeTime;
        public const string QueryStringToken = "ssso";
        public SsoManager(string connectionString, DbType dbType = DbType.MsSql, int tokenLifeTime = 30)
        {
            _connectionString = connectionString;
            _dbType = dbType;
            _tokenLifeTime = tokenLifeTime;
        }
        public string CreateToken(string loginId, string source)
        {
            if (string.IsNullOrWhiteSpace(loginId))
                throw new ArgumentNullException("loginId");
            var token = Guid.NewGuid().ToString();
            using (var connection = CreateConnection())
            {
                connection.Execute("insert into SimpleSso values(@Token,@LoginId,@CreatedDateUtc,@Source)",
                    new { Token = token, LoginId = loginId, CreatedDateUtc = DateTime.UtcNow, source });
            }
            return token;
        }
        public string VerifyToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return null;
            using (var connection = CreateConnection())
            {
                var result = connection.QuerySingleOrDefault<SimpleSsoModel>("select Token,LoginId,CreatedDateUtc,Source from SimpleSso where Token=@Token",
                    new { Token = token });
                if (result != null && result.CreatedDateUtc.AddSeconds(_tokenLifeTime) >= DateTime.UtcNow)
                {
                    //connection.Execute("delete from SimpleSso where Token=@Token", new { Token = token });
                    return result.LoginId;
                }
                return null;
            }
        }
        public int DeleteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return 0;
            using (var connection = CreateConnection())
            {
                return connection.Execute("delete from SimpleSso where Token=@Token", new { Token = token });
            }
        }
        private IDbConnection CreateConnection()
        {
            switch (_dbType)
            {
                case DbType.MsSql:
                    return new SqlConnection(_connectionString);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
