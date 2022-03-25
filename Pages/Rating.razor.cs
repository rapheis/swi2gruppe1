using System;
using swi2gruppe1.Data;
using Microsoft.AspNetCore.Components;

namespace swi2gruppe1.Pages
{
    using swi2gruppe1.Data;
    using swi2gruppe1.Proxy;

    public partial class Rating
    {
        
        //private Film[] film = WebAPIProxy.GetFilmAsync();

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

        private async Task IncrementCountLike(Film film)
        {

            if (currentCount <= 9)
            {
                currentCount++;
            }

            IsDisabledLike = true;

        }

        private void IncrementCountLikeXXX(int buttonIDLikeXXX) //@parameter string ButtonID
        {
            actualButtonIDLike = buttonIDLikeXXX;



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

        private async Task IncrementCountDislike(Film film) //@parameter string ButtonID
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

            IsDisabledDislike = true;
        }

        private string buttonResponseRating = "";

        private void ButtonResponseChangeRating()
        {
            buttonResponseRating = "Deine Bewertung wurde gespeichert. Du kannst deine Filmempfehlungen unter Empfehlungen anschauen.";

        }





        //ab hier Trempsche Lösung

        private Film film = new Film();
        private int returnCode;

        // Seitenparameter: ID, wenn leer, dann neu erfassen, sonst bestehende ID holen
        [Parameter]
        public string? Name { set; get; }
        [Inject] NavigationManager _nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Name == null)
            {
                film = new Film();

            }
            else
            {
                // hier von Get laden mit der ID
                string? name = Name;
                if (name.Equals(""))
                {
                    film = new Film();
                }
                else
                {
                    Film[] films = await new WebAPIProxy().GetFilmAsync("");
                    if (films.Length == 1)
                    {
                        film = films[0];
                    }
                    else
                    {
                        film = new Film();
                    }
                }
            }
        }

        private async Task SendObjekt()
        {
            if (film.Name == null)
            {
                returnCode = await new WebAPIProxy().PostFilmAsync(film);

            }
            else
            {
                returnCode = await new WebAPIProxy().PutFilmAsync(film);
            }
            await Back();

        }
        // Objekt löschen
        private async Task DeleteObjekt()
        {
            returnCode = await new WebAPIProxy().DeleteFilmAsync(film);
            await Back();

        }

        private Task Back()
        {
            var url = @"/Rating";
            _nav.NavigateTo(url);
            return Task.CompletedTask;
        }


    }
}
