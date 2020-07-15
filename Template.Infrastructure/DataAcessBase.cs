using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Template.Infrastructure
{
    public abstract class DataAccessBase : IDisposable
    {
        private IDbConnection SQL => _connection;
        private ConnectionState State => _connection?.State ?? ConnectionState.Closed;
        
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private readonly string _connectionString;

        protected DataAccessBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected void Open()
        {
            if (_connection == null)
                _connection = new SqlConnection(_connectionString);

            if (State == ConnectionState.Broken || State == ConnectionState.Closed)
                _connection.Open();
        }

        protected void Close()
        {
            if (_connection != null && State != ConnectionState.Closed)
                _connection.Close();
        }

        protected void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        private void BeginTransaction(IsolationLevel il)
        {
            if (State != ConnectionState.Open)
                _connection.Open();

            _transaction = _connection.BeginTransaction(il);
        }

        protected void CommitTransaction()
        {
            _transaction?.Commit();
        }

        protected void RollBackTransaction()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _transaction?.Dispose();
            SQL?.Dispose();
        }

        internal protected async Task<int> ExecuteScalarAsync(string command, object param)
        {
            return await SQL.ExecuteScalarAsync<int>(command, param, commandType: CommandType.Text);
        }

        internal protected Task<int> ExecuteAsync(string command)
        {
            return SQL.ExecuteAsync(command, null, _transaction, null, CommandType.Text);
        }

        internal protected Task<int> ExecuteAsync(string command, object param)
        {
            return SQL.ExecuteAsync(command, param, _transaction, null, CommandType.Text);
        }

        internal protected Task<IEnumerable<T>> QueryAsync<T>(string command)
        {
            return SQL.QueryAsync<T>(command, null, _transaction, null, CommandType.Text);
        }

        internal protected async Task<IEnumerable<T>> QueryAsync<T>(string command, object param)
        {
            return await SQL.QueryAsync<T>(command, param, _transaction, null, CommandType.Text);
        }

        internal protected async Task<T> QueryFirstOrDefaultAsync<T>(string command)
        {
            return await SQL.QueryFirstOrDefaultAsync<T>(command, null, _transaction, null, CommandType.Text);
        }

        internal protected async Task<T> QueryFirstOrDefaultAsync<T>(string command, object param)
        {
            return await SQL.QueryFirstOrDefaultAsync<T>(command, param, _transaction, null, CommandType.Text);
        }
    }
}