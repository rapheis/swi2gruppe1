namespace swi2gruppe1.Pages

{
    using swi2gruppe1.Data;
    using swi2gruppe1.Proxy;

    public partial class UserView
    {
        private User user = ProxyWebAPI.GetUser();



        public async Task SendInformation()
        {
            ProxyWebAPI.SendUser(user);
        }

    }
}
