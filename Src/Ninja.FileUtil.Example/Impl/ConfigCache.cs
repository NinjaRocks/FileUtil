using System.Runtime.Caching;
using Ninja.FileUtil.Configuration;
using Ninja.FileUtil.Example.Model;

namespace Ninja.FileUtil.Example.Impl
{
    public static class ConfigCache
    {
        public static SettingDto Get()
        {
            var cache = MemoryCache.Default;
            var cacheSettings = (SettingDto)cache["settings"];

            var settings = cacheSettings ?? new SettingDto(Settings.GetSection());
            cache.Add("settings", settings, new CacheItemPolicy());

            return settings;
        }

        public static SettingDto Update(SettingDto settings)
        {
            var cache = MemoryCache.Default;
            var cacheSettings = settings ?? new SettingDto(Settings.GetSection());
            cache.Add("settings", cacheSettings, new CacheItemPolicy());

            return cacheSettings;
        }
    }
}