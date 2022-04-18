﻿using Microsoft.Data.SqlClient;
using MultiTenant.Core.Configurations;
using MultiTenant.Core.Database;
using MultiTenant.Core.Dtos;
using MySql.Data.MySqlClient;
using Npgsql;

namespace MultiTenant.Core.Services
{
    internal class TenantConnectionStringBuilderService :
        ITenantConnectionStringBuilderService
    {
        private DatabaseConnectionBuilderModel _connectionBuilderModel;
        private string _identifier;

        public string CreateConnectionString(DatabaseConnectionBuilderModel model)
        {
            _connectionBuilderModel = model;
            if (_connectionBuilderModel.Decision == DatabaseDecision.Isolated)
            {
                switch (_connectionBuilderModel.Provider)
                {
                    case DatabaseProviders.MsSQL:
                        return CreateIsolatedSqlServerConnectionString(new IsolatedResources(
                            _connectionBuilderModel.Provider, _connectionBuilderModel.Host,
                            _connectionBuilderModel.Port, _connectionBuilderModel.Username,
                            _connectionBuilderModel.Password));
                    case DatabaseProviders.MySQL:
                        return CreateIsolatedMySqlConnectionString(new IsolatedResources(
                            _connectionBuilderModel.Provider, _connectionBuilderModel.Host,
                            _connectionBuilderModel.Port, _connectionBuilderModel.Username,
                            _connectionBuilderModel.Password));
                    case DatabaseProviders.POSTGRES:
                        return CreateIsolatedNpgSqlConnectionString(new IsolatedResources(
                            _connectionBuilderModel.Provider, _connectionBuilderModel.Host,
                            _connectionBuilderModel.Port, _connectionBuilderModel.Username,
                            _connectionBuilderModel.Password));
                    case DatabaseProviders.ORACLE:
                        throw new Exception("Oracle Database not supported yet.");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else if (_connectionBuilderModel.Decision == DatabaseDecision.Shared)
            {
                switch (_connectionBuilderModel.Provider)
                {
                    case DatabaseProviders.MsSQL:
                        break;
                    case DatabaseProviders.MySQL:
                        break;
                    case DatabaseProviders.POSTGRES:
                        break;
                    case DatabaseProviders.ORACLE:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }

        public string CreateConnectionString(DatabaseConnectionBuilderModel model, string identifier)
        {
            _identifier = identifier;
            return CreateConnectionString(model);
        }

        private string GenerateDatabaseName()
        {
            var autoGenerated = _connectionBuilderModel.GenerateDatabaseName;
            if (autoGenerated)
            {
                return $"Tenant-{_identifier}";
            }

            return _connectionBuilderModel.DatabaseName;
        }

        private string CreateIsolatedSqlServerConnectionString(IsolatedResources isolatedResources)
        {
            return new SqlConnectionStringBuilder()
            {
                DataSource = isolatedResources.Host,
                UserID = isolatedResources.Username,
                TrustServerCertificate = true,
                Password = isolatedResources.Password,
                InitialCatalog = GenerateDatabaseName()
            }.ToString();
        }

        private string CreateIsolatedNpgSqlConnectionString(IsolatedResources isolatedResources)
        {
            return new NpgsqlConnectionStringBuilder()
            {
                Host = isolatedResources.Host,
                Username = isolatedResources.Username,
                Password = isolatedResources.Password,
                Port = isolatedResources.Port,
                Database = GenerateDatabaseName()
            }.ToString();
        }

        private string CreateIsolatedMySqlConnectionString(IsolatedResources isolatedResources)
        {

            return new MySqlConnectionStringBuilder()
            {
                Server = isolatedResources.Host,
                UserID = isolatedResources.Username,
                Password = isolatedResources.Password,
                Port = (uint)isolatedResources.Port,
                Database = GenerateDatabaseName()
            }.ToString();
        }
    }
}
