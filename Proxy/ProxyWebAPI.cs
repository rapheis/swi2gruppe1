namespace swi2gruppe1.Proxy

{
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

        public static Film[] GetFilmArray() {
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

            Film[] filmArray = new Film[]
            {
                film1, film2, film3, film4, film5
            };

            return filmArray;
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



    }
}