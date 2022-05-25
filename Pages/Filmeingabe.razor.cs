using System;
using swi2gruppe1.Data;
using Microsoft.AspNetCore.Components;
using swi2gruppe1.Proxy;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;


namespace swi2gruppe1.Pages
{
    public partial class Filmeingabe
    {
        private Film film = new Film();
        private int returnCode;

        // zu Testzwecken
        private string httpLink = swi2gruppe1.AppConfiguration.APIURL;

        // Seitenparameter: ID, wenn leer, dann neu erfassen, sonst bestehende ID holen
        [Parameter]
                
        public string? ID { set; get; }
        //[Inject] NavigationManager _nav { get; set; }

        protected override async Task OnParametersSetAsync()
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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Bild noch anzeigen, sofern vorhanden
            //await ShowImage();
        }

        // nach EditForm geändertes Objekt an WebAPI senden

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

        // Bild hochladen
        private async Task ImageLoad(InputFileChangeEventArgs e)
        {
            // Bild auf Standardgrösse und jpeg setzen
            IBrowserFile browserFile = await e.File.RequestImageFileAsync("image/jpeg", 400, 300);
            var resizedImage = await Image.LoadAsync(browserFile.OpenReadStream());
            // Model nachführen
            film.Bild = resizedImage.ToBase64String(JpegFormat.Instance);
            // URI-Info wegnehmen
            //weatherForecast.Bild = weatherForecast.Bild.Substring(23);
            // Bild anzeigen
            //await ShowImage();
        }
        // Bild anzeigen
        private async Task ShowImage()
        {
            if (film.Bild != null)
            {
                byte[] imageBytes = Convert.FromBase64String(film.Bild);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                DotNetStreamReference dotnetImageStream = new DotNetStreamReference(ms);
                // siehe JavaScript-Programm in wwwroot/js
                await JS.InvokeVoidAsync("setImageUsingStreaming", "ImagePreview", dotnetImageStream);
                ms.Close();
                ms.Dispose();
            }
        }
    }
}