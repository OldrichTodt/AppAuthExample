using System.Threading.Tasks;

namespace AppAuthExample
{
    public interface ILoginProvider
    {
        Task LoginAsync();
    }
}