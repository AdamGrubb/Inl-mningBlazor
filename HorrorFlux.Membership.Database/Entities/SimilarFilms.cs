﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HorrorFlux.Membership.Database.Entities;

public class SimilarFilms
{

    public int ParentFilmId { get; set; }
    public int SimilarFilmId { get; set; }
}
