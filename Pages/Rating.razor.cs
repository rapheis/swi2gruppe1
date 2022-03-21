using System;
namespace swi2gruppe1.Pages
{
    using swi2gruppe1.Data;
    using swi2gruppe1.Proxy;

    public partial class Rating
    {
        private Film film = ProxyWebAPI.GetFilm();

        private Film[] randomFilm = ProxyWebAPI.GetRandomFilm();

        private int currentCount = 0;

        private HashSet<int> ratedFilmIDs = new HashSet<int>();


        private void IncrementCount() //@parameter string ButtonID
        {
            /*
            var numberOfbuttonID = ButtonID.Split("-").Last();
            int filmID = int.Parse(numberOfbuttonID);
            ratedFilmIDs.Add(filmID); 
            currentCount = ratedFilmIDs.Count; 
            */
            if (currentCount <= 9)
            {
                currentCount++;
            }

        }



        public async Task SendFilm()
        {
            ProxyWebAPI.SendFilm(film);
        }

        private string buttonResponseRating = "";

        private void ButtonResponseChangeRating() {
            buttonResponseRating = "Deine Bewertung wurde gespeichert. Du kannst deine Filmempfehlungen unter Empfehlungen anschauen.";
            
        }

    }

}

