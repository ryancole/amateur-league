﻿using System.Data;
using System.Data.SqlClient;

using League.Data.Sql.Repository;

namespace League.Data.Sql
{
    public class LeagueSqlSession
    {
        private SqlConnection m_connection;
        private SqlTransaction m_transaction;

        private TeamRepository m_teamRepository;

        public LeagueSqlSession(string connectionString)
        {
            // open database connection
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();

            // create explicit transaction
            m_transaction = m_connection.BeginTransaction();
        }

        ~LeagueSqlSession()
        {
            if (m_connection.State != ConnectionState.Closed)
            {
                m_connection.Close();
            }
        }

        #region Methods

        internal SqlCommand CreateCommand()
        {
            var command = m_connection.CreateCommand();

            command.Transaction = m_transaction;

            return command;
        }

        public void Commit()
        {
            m_transaction.Commit();
        }

        #endregion

        #region Properties

        public TeamRepository Teams
        {
            get
            {
                if (m_teamRepository == null)
                {
                    m_teamRepository = new TeamRepository(this);
                }

                return m_teamRepository;
            }
        }

        #endregion
    }
}
