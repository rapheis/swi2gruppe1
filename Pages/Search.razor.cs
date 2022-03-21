using System;
namespace swi2gruppe1.Pages
{
    using swi2gruppe1.Data;
    using swi2gruppe1.Proxy;

    public partial class Search
    {
        private Film[] searchedFilm = ProxyWebAPI.GetSearchFilm();
    }

}
