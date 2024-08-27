using eTickets.Data.Enums;
using eTickets.Models.Domain;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //cinema id 
                var cinemaID1 = "d46b1e8d-5d33-45b3-a53d-a317f5aa78d2";
                var cinemaID2 = "05abb585-a756-4fb7-b81a-ec2e02e4d913";
                var cinemaID3 = "632ba92f-9cce-4304-a70d-95f43d1c6bc1";
                var cinemaID4 = "95c7bfcf-cb1d-44ce-859f-291b3c8b43cb";
                var cinemaID5 = "d09be3a5-3649-4ac3-af68-d1c604e2490d";
                //cinemas
                if (!context.Cinemas.Any())
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {

                        new Cinema
                        {
                            Id = Guid.Parse(cinemaID1),
                            Name = "Cinema 1",
                            Logo = "https://static.vecteezy.com/system/resources/previews/005/188/413/original/cinema-logo-template-isolated-on-white-background-vector.jpg",
                            Description = "This is the description of the first cinema",
                        },
                        new Cinema
                        {
                            Id = Guid.Parse(cinemaID2),
                            Name = "Cinema 2",
                            Logo = "https://static.vecteezy.com/system/resources/previews/005/188/413/original/cinema-logo-template-isolated-on-white-background-vector.jpg",
                            Description = "This is the description of the second cinema",
                        },
                        new Cinema
                        {
                            Id = Guid.Parse(cinemaID3),
                            Name = "Cinema 3",
                            Logo = "https://static.vecteezy.com/system/resources/previews/005/188/413/original/cinema-logo-template-isolated-on-white-background-vector.jpg",
                            Description = "This is the description of the third cinema",
                        },
                        new Cinema
                        {
                            Id = Guid.Parse(cinemaID4),
                            Name = "Cinema ",
                            Logo = "https://static.vecteezy.com/system/resources/previews/005/188/413/original/cinema-logo-template-isolated-on-white-background-vector.jpg",
                            Description = "This is the description of the fourth cinema",
                        },
                        new Cinema
                        {
                            Id = Guid.Parse(cinemaID5),
                            Name = "Cinema 5",
                            Logo = "https://static.vecteezy.com/system/resources/previews/005/188/413/original/cinema-logo-template-isolated-on-white-background-vector.jpg",
                            Description = "This is the description of the fifth cinema",
                        },
                    });
                    context.SaveChanges();
                }

                var actorID1 = "e371ce20-4144-4fca-a158-c859f4538c05";
                var actorID2 = "4b83fea0-b089-4953-9118-bd6315ca5239";
                var actorID3 = "7e319376-5de1-48f8-a162-4b9304f88574";
                var actorID4 = "db8b863d-b65d-4bcb-a5ff-6cfe92e3c1f1";
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>() {
                        new Actor
                        {
                            Id = Guid.Parse(actorID1),
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://th.bing.com/th/id/OIP.Zj1ipLlmaji9t1IFHij3ugHaLF?w=122&h=183&c=7&r=0&o=5&pid=1.7"
                        },
                        new Actor
                        {
                            Id = Guid.Parse(actorID2),
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://th.bing.com/th/id/OIP.Zj1ipLlmaji9t1IFHij3ugHaLF?w=122&h=183&c=7&r=0&o=5&pid=1.7"
                        },
                        new Actor {
                            Id = Guid.Parse(actorID3),
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePictureURL = "https://th.bing.com/th/id/OIP.Zj1ipLlmaji9t1IFHij3ugHaLF?w=122&h=183&c=7&r=0&o=5&pid=1.7"
                        },
                        new Actor {
                            Id = Guid.Parse(actorID4),
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the fourth actor",
                            ProfilePictureURL = "https://th.bing.com/th/id/R.060325f4d7f8a1e1fde6538bcb9a257d?rik=PcHl1OvmDHTy1Q&riu=http%3a%2f%2fsubcultureentertainment.com%2fwp-content%2fuploads%2f2014%2f01%2fChris-Hemsworth.jpg&ehk=7Ucrrr1jfEgj3FlRkcsRb37LILcI58aEWVGrAH3jFKU%3d&risl=&pid=ImgRaw&r=0"
                        }
                    });
                    context.SaveChanges();
                }

                var producerID1 = "866a36e5-454c-4b62-b018-8e0b30aaf20c";
                var producerID2 = "87a0db5e-e253-4898-90e1-f4091ec9d7cd";
                var producerID3 = "0dc7ae60-0f40-46dc-9a3e-11155c1751bd";

                //producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>() {
                        new Producer
                        {
                            Id = Guid.Parse(producerID1),
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first producer",
                            ProfilePictureURL = "https://support.musicgateway.com/wp-content/uploads/2020/12/Copy-of-800-x-500-Blog-Post-1-4.png",

                        },
                        new Producer
                        {
                            Id = Guid.Parse(producerID2),
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second producer",
                            ProfilePictureURL = "https://support.musicgateway.com/wp-content/uploads/2020/12/Copy-of-800-x-500-Blog-Post-2-4.jpg",

                        },
                        new Producer
                        {
                            Id = Guid.Parse(producerID3),
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the third producer",
                            ProfilePictureURL = "https://support.musicgateway.com/wp-content/uploads/2020/12/Copy-of-800-x-500-Blog-Post-3-4.jpg",
                        }

                    });
                    context.SaveChanges();
                }

                var movieID1 = "e6054d37-5083-4454-ba92-23fc307c6b9b";
                var movieID2 = "49d9261c-59b8-485b-9526-664f8a94ea91";
                var movieID3 = "f29daeda-4eaa-46cc-b63d-f7304151ab39";
                var movieID4 = "56dbedea-c6e4-4a2e-85ee-f3d55524d5d1";
                var movieID5 = "9a09a914-a947-4d9a-a147-ee5711972072";
                //movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie
                        {
                            Id = Guid.Parse(movieID1),
                            Name = "Movie 1",
                            Description = "This is the description of the first movie",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/R.005715b2dcda5ad9ecb970db507c5c63?rik=%2b5XMshW%2fWJ3qyg&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = Guid.Parse(producerID1),
                            MovieCategory = MovieCategory.Drama,
                        } ,
                        new Movie
                        {
                            Id = Guid.Parse(movieID2),
                            Name = "Movie 2",
                            Description = "This is the description of the second movie",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/R.82322c815c6ab49813aefa47bd4329ff?rik=%2bTQqYey6lDho8g&riu=http%3a%2f%2fstatic2.wikia.nocookie.net%2f__cb20120501184841%2fmarvelmovies%2fimages%2f4%2f4b%2fAmazing_Spider-Man_theatrical_poster_02.jpg&ehk=c7PKqwuDT0A%2b9SSoYzq8lZIhEuHFweeOSwCNzKjKu%2fI%3d&risl=&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = Guid.Parse(producerID1),
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie {
                            Id = Guid.Parse(movieID3),
                            Name = "Movie 3",
                            Description = "This is the description of the third movie",
                            Price = 88.50,
                            ImageURL = "https://th.bing.com/th/id/R.27a1f62f0895aa52617727b7a8381199?rik=knUnfvfEZSKIew&riu=http%3a%2f%2fcomic-cons.xyz%2fwp-content%2fuploads%2fmarvel-cinematic-universe-the-avengers-infinity-war-movie-poster.jpg&ehk=XXfDtc61WptIXpd%2bbgcdlOvMfqIo3r9KRiOeZGhAz1s%3d&risl=&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(-17),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = Guid.Parse(producerID3),
                            MovieCategory = MovieCategory.Action,
                        },
                        new Movie
                        {
                            Id = Guid.Parse(movieID4),
                            Name = "Movie 4",
                            Description = "This is the description of the fourth movie",
                            Price = 39.50,
                            ImageURL = "https://th.bing.com/th/id/R.ac91f92be00113dd86b8dc16f86747a8?rik=0fz1rM%2bGeCqdcw&riu=http%3a%2f%2fwww.stunningmesh.com%2fwp-content%2fuploads%2f2011%2f05%2fstunningmesh-3d-movie-poster-3.jpg&ehk=l4A1p8TVClgDY58232pE4DYGrSOkDyM2peUtx7OWokQ%3d&risl=&pid=ImgRaw&r=0",
                            StartDate = DateTime.Now.AddDays(-3),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = Guid.Parse(producerID2),
                            MovieCategory = MovieCategory.Cartoon,
                        },
                        new Movie
                        {
                            Id = Guid.Parse(movieID5),
                            Name = "Movie 5",
                            Description = "This is the description of the fifth movie",
                            Price =53.50,
                            ImageURL = "https://th.bing.com/th/id/OIP.VnbVDS_USZtYm7KqhULwHgHaK-?w=205&h=304&c=7&r=0&o=5&pid=1.7",
                            StartDate = DateTime.Now.AddDays(-9),
                            EndDate = DateTime.Now.AddDays(10),
                            ProducerId = Guid.Parse(producerID3),
                            MovieCategory = MovieCategory.Horror,
                        }
                    });
                    context.SaveChanges();
                }

                //Actor_Movies
                if (!context.ActorsMovies.Any())
                {
                    context.ActorsMovies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID1),
                            MovieId = Guid.Parse(movieID1),
                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID2),
                            MovieId = Guid.Parse(movieID1),
                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID2),
                            MovieId = Guid.Parse(movieID2),

                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID3),
                            MovieId = Guid.Parse(movieID3),
                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID4),
                            MovieId = Guid.Parse(movieID4),
                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID3),
                            MovieId = Guid.Parse(movieID4),
                        },
                        new Actor_Movie
                        {
                            ActorId = Guid.Parse(actorID4),
                            MovieId = Guid.Parse(movieID5),
                        }
                    });
                    context.SaveChanges();
                }
                //cinema_movies
                if (!context.CinemasMovies.Any())
                {
                    context.CinemasMovies.AddRange(new List<Cinema_Movie>()
                    {
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID1),
                            MovieId = Guid.Parse(movieID1),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID2),
                            MovieId = Guid.Parse(movieID1),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID1),
                            MovieId = Guid.Parse(movieID2),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID2),
                            MovieId = Guid.Parse(movieID3),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID3),
                            MovieId = Guid.Parse(movieID3),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID3),
                            MovieId = Guid.Parse(movieID4),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID3),
                            MovieId = Guid.Parse(movieID5),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID4),
                            MovieId = Guid.Parse(movieID5),
                        },
                        new Cinema_Movie
                        {
                            CinemaId = Guid.Parse(cinemaID5),
                            MovieId = Guid.Parse(movieID5),
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
