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