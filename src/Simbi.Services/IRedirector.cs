using Simbi.Common;

namespace Simbi.Services
{
    public interface IRedirector
    {
        void RedirectTo(PageName page, object currentPage);
    }
}