namespace MobileCarMarket.LocalDb
{
    using System;

    using SQLite.Net.Cipher.Data;
    using SQLite.Net.Interop;

    using Models;
    
    public class SQLiteStorage : SecureDatabase
    {
        public SQLiteStorage(string dbFile, string keySeed)
            : this(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dbFile)
        {

        }

        protected SQLiteStorage(ISQLitePlatform platform, string dbFile) 
            : base(platform, dbFile)
        {

        }

        protected override void CreateTables()
        {
            this.CreateTable<Photo>();
        }
    }
}

