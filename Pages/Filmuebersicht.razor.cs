using System;
using swi2gruppe1.Data;
using Microsoft.AspNetCore.Components;
using swi2gruppe1.Proxy;

namespace swi2gruppe1.Pages
{
    public partial class Filmuebersicht
    {
        private Film[]? films;
        private string name = "";
        [Inject] NavigationManager _nav { get; set; }


        protected override async Task OnInitializedAsync()
        {
            films = await new WebAPIProxy().GetFilmsAsync(0, name);
        }
        /*
         *  Seite neu laden
         */
        public async Task NeuLaden()
        {
            films = await new WebAPIProxy().GetFilmsAsync(0, name);
        }
        /*
         * Beabeiten von den einzelnen Objekten
         */
        private async Task bearbeiteObjekt(Film filmObj)
        {
            // hier nun das Objekt in Wettereingabe bearbeiten
            var url = @"/filmeingabe/" + filmObj.Id;
            _nav.NavigateTo(url);
        }

    }
}

