using SqlSugar;
using System;
using System.Threading;

namespace Ls.Sass.Storage
{

    public interface IStorageContext : IDisposable
    {
        ISqlSugarClient SugarClient { get; }
        void BeginTrans();
        void Rollback();
        void Commit();
    }

    public abstract class StorageContext : IStorageContext
    {
        private static readonly AsyncLocal<int> _level = new();
        protected readonly ISqlSugarClient _sugarClient;

        public ISqlSugarClient SugarClient
        {
            get { return _sugarClient; }
        }

        public StorageContext(ISqlSugarClient sugarClient)
        {
            _sugarClient = sugarClient;
        }

        public void BeginTrans()
        {
            _level.Value += 1;
        }

        public void Rollback()
        {
           
        }

        public void Commit()
        {
          
        }

        public void Dispose()
        {
          
        }
    }
}
