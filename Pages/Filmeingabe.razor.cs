using System;
using swi2gruppe1.Data;
using Microsoft.AspNetCore.Components;
using swi2gruppe1.Proxy;

namespace swi2gruppe1.Pages
{
    public partial class Filmeingabe
    {
        private Film film = new Film();
        private int returnCode;

        // Seitenparameter: ID, wenn leer, dann neu erfassen, sonst bestehende ID holen
        [Parameter]
        public string? ID { set; get; }
        [Inject] NavigationManager _nav { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ID == null)
            {
                film = new Film();

            }
            else
            {
                // hier von Get laden mit der ID
                int id = int.Parse(ID);
                if (id == 0)
                {
                    film = new Film();
                }
                else
                {
                    Film[] films = await new WebAPIProxy().GetFilmsAsync(id, "");
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

            if (film.Id == 0)
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
            var url = @"/filmuebersicht";
            _nav.NavigateTo(url);
            return Task.CompletedTask;
        }

    

    }
}

