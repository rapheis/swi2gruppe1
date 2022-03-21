using System;
namespace swi2gruppe1.Pages
{
    using swi2gruppe1.Data;
    using swi2gruppe1.Proxy;

    public partial class Recommendation
    {
        private Film film = ProxyWebAPI.GetFilm();

        private Film[] recommendedFilm = ProxyWebAPI.GetRecommendedFilm();

        public Film Film { get => film; set => film = value; }
        public Film[] RecommendedFilm { get => recommendedFilm; set => recommendedFilm = value; }

        public async Task SendFilm()
        {
            ProxyWebAPI.SendFilm(Film);
        }

        private string buttonResponseRecom = "";

        private void ButtonResponseChangeRecom()
        {
            buttonResponseRecom = "Deine Empfehlung wurde per E-Mail versendet. Danke für dein Vertrauen.";
        }


    }

}

