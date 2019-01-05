﻿using System;
using System.Data.SqlClient;

using League.Data.Sql.Interface;
using League.Data.Sql.Repository;

namespace League.Data.Sql
{
    public class LeagueSqlSession : ILeagueSqlSession, IDisposable
    {
        private bool m_disposed;

        private SqlConnection m_connection;
        private SqlTransaction m_transaction;

        private TeamRepository m_teamRepository;
        private SeasonRepository m_seasonRepository;
        private SeasonDivisionRepository m_seasonDivisionRepository;
        private SeasonDivisionMembershipRepository m_seasonDivisionMembershipRepository;

        public LeagueSqlSession(string connectionString)
        {
            m_disposed = false;

            // open database connection
            m_connection = new SqlConnection(connectionString);
            m_connection.Open();

            // create explicit transaction
            m_transaction = m_connection.BeginTransaction();
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

        public SeasonRepository Seasons
        {
            get
            {
                if (m_seasonRepository == null)
                {
                    m_seasonRepository = new SeasonRepository(this);
                }

                return m_seasonRepository;
            }
        }

        public SeasonDivisionRepository SeasonDivisions
        {
            get
            {
                if (m_seasonDivisionRepository == null)
                {
                    m_seasonDivisionRepository = new SeasonDivisionRepository(this);
                }

                return m_seasonDivisionRepository;
            }
        }

        public SeasonDivisionMembershipRepository SeasonDivisionMemberships
        {
            get
            {
                if (m_seasonDivisionMembershipRepository == null)
                {
                    m_seasonDivisionMembershipRepository = new SeasonDivisionMembershipRepository(this);
                }

                return m_seasonDivisionMembershipRepository;
            }
        }

        #endregion

        #region IDisposable and Cleanup

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposeManagedResources)
        {
            if (disposeManagedResources && !m_disposed)
            {
                m_connection.Close();
            }

            m_disposed = true;
        }

        #endregion
    }
}