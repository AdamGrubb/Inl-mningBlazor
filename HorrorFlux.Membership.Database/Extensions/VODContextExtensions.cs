//using HorrorFlux.Common.DTOs;
//using HorrorFlux.Membership.Database.Entities;
//using HorrorFlux.Membership.Database.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HorrorFlux.Membership.Database.Extensions;

//public static class VODContextExtensions
//{
//    public static async Task SeedMembershipData(this IDbService service)
//    {
//       try
//        {
//            await service.AddAsync<Film, FilmDTO>(new FilmDTO
//            {
//                Title = "Super",
//                

//                FilmPoster = "/MoviePoster/Super.png", //Testa så att den här fungerar som den ska.
//                
//                DirectorId = 1,
//                DirectorName = "James Gun",




//        public int DirectorId { get; set; }
//    public DirectorDTO Director { get; set; }
//    public List<SimilarFilmsDTO> SimilarFilms { get; set; }
//    public List<FilmGenreDTO> FilmGenres { get; set; }

//}
//            catch
//            {

//            }
    
//        }
//    }
//}
