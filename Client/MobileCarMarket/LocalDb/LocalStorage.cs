namespace MobileCarMarket.LocalDb
{
    using System;

    using SQLite.Net.Cipher.Interfaces;

    public class LocalStorage
    {
        private static string dbFile;
        private static string keySeed;

        protected LocalStorage()
        {

        }

        public static ISecureDatabase GetInstance
        {
            get
            {
                return new SQLiteStorage(dbFile, keySeed);
            }
        }

        public static string KeySeed
        {
            get
            {
                return LocalStorage.keySeed;
            }
        }

        public static void Initialize(string dbFile, string keySeed)
        {
            if(LocalStorage.dbFile != null)
            {
                throw new InvalidOperationException("LocalDb already initialized");
            }

            LocalStorage.dbFile = dbFile;
            LocalStorage.keySeed = keySeed;
        }
    }
}
