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

        private int actualButtonIDLike = 0;
        private int actualButtonIDDislike = 0;

        

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

        protected bool IsDisabledLike { get; set; }
        protected bool IsDisabledDislike { get; set; }

        private void IncrementCountLike(int buttonIDLike) //@parameter string ButtonID
        {
            actualButtonIDLike = buttonIDLike;
            

            
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

            IsDisabledLike = true;
        }

        private void IncrementCountDislike(int buttonIDDislike) //@parameter string ButtonID
        {
            actualButtonIDDislike = buttonIDDislike;
            

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

            IsDisabledDislike = true;
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

