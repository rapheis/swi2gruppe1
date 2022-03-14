using System;
using System.Net.Http;
namespace swi2gruppe1.Proxy

{
    using System.Net;
    using swi2gruppe1.Data;
    

    public class ProxyWebAPI
    {
        public static Film GetFilm()
        {
            Console.WriteLine("hier wäre der WebAPI Get-Aufruf des Films...");
            Film film = new Film();
            film.ID = 1;
            film.Name = "Avengers Infinity War";
            film.Picture = "Beispiel-Bild";
            return film;
        }

        public static Film[] GetRandomFilm() {
            Film film1 = new Film();
            film1.ID = 1;
            film1.Name = "Avengers Infinity War";
            film1.Picture = "Beispiel-Bild";

            Film film2 = new Film();
            film2.ID = 2;
            film2.Name = "Spiderman";
            film2.Picture = "Beispiel-Bild";

            Film film3 = new Film();
            film3.ID = 3;
            film3.Name = "Antman";
            film3.Picture = "Beispiel-Bild";

            Film film4 = new Film();
            film4.ID = 4;
            film4.Name = "Dr. Strange";
            film4.Picture = "Beispiel-Bild";

            Film film5 = new Film();
            film5.ID = 5;
            film5.Name = "Black Widow";
            film5.Picture = "Beispiel-Bild";

            Film[] randomFilm = new Film[]
            {
                film1, film2, film3, film4, film5
            };

            return randomFilm;
        }

        public static Film[] GetRecommendedFilm()
        {
            Film film11 = new Film();
            film11.ID = 11;
            film11.Name = "Black Panther";
            film11.Picture = "Beispiel-Bild";

            Film film12 = new Film();
            film12.ID = 12;
            film12.Name = "Eternals";
            film12.Picture = "Beispiel-Bild";

            Film film13 = new Film();
            film13.ID = 13;
            film13.Name = "Iron man";
            film13.Picture = "Beispiel-Bild";

            Film film14 = new Film();
            film14.ID = 14;
            film14.Name = "Thor";
            film14.Picture = "Beispiel-Bild";

            Film film15 = new Film();
            film15.ID = 15;
            film15.Name = "Blade";
            film15.Picture = "Beispiel-Bild";

            Film[] recommendedFilm = new Film[]
            {
                film11, film12, film13, film14, film15
            };

            return recommendedFilm;
        }

        public static Film[] GetSearchFilm()
        {
            Film film21 = new Film();
            film21.ID = 21;
            film21.Name = "Guardians of the Galaxy";
            film21.Picture = "Beispiel-Bild";

            Film film22 = new Film();
            film22.ID = 22;
            film22.Name = "Captain America";
            film22.Picture = "Beispiel-Bild";

            Film film23 = new Film();
            film23.ID = 23;
            film23.Name = "Guardians of the Galaxy 2";
            film23.Picture = "Beispiel-Bild";

            Film[] searchedFilm = new Film[]
            {
                film21, film22, film23
            };

            return searchedFilm;
        }

        public static void SendFilm(Film film)
        {
            Console.WriteLine("hier würde das WebAPI aufgerufen.." + film.ID +
            " " + film.Name);
        }

        public static User GetUser()
        {
            Console.WriteLine("hier wäre der WebAPI Get-Aufruf des Users...");
            User user = new User();
            user.ID = 1;
            user.Firstname = "Max";
            user.Lastname = "Muster";
            user.Email = "max.muster@ost.ch";
            user.Nickname = "maxinator12";
            user.Picture = "Beispiel-Bild";
            return user;
        }
        public static void SendUser(User user)
        {
            Console.WriteLine("hier würde das WebAPI aufgerufen.." + user.ID +
            " " + user.Firstname + " " + user.Lastname + " " + user.Nickname + " " + user.Email);
        }



        public static Rating GetRating()
        {
            Console.WriteLine("hier wäre der WebAPI Get-Aufruf des Ratings...");
            Rating rating = new Rating();
            rating.Score = 5;
            return rating;
        }
        public static void SendRating(Rating rating)
        {
            Console.WriteLine("hier würde das WebAPI aufgerufen.." + rating.Score);
        }

        //First steps to get the data from the movie DB
        static async Task GetRequest()
        {
            var httpClient = HttpClientFactory.Create();

            var url = "https://api.themoviedb.org/3/discover/movie?api_key=a347abe5eb9af9fbfa2ef6035d858f19&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1&year=2018&with_watch_monetization_types=flatrate";
            HttpResponseMessage httpResponseMessage =
            await httpClient.GetAsync(url);
            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var content = httpResponseMessage.Content;
                var data = await content.ReadAsStringAsync();

                Console.WriteLine(data);


            }
            else
            {
                Console.WriteLine($"Error: " + httpResponseMessage.StatusCode);
            }

        }

    }
}