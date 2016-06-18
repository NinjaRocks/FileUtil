using Ninja.FileUtil.Provider;

namespace Ninja.FileUtil
{
    public interface IFileProvider
    {
        ReadFile[] GetFiles();
    }
}