﻿using System;
using System.Collections.Generic;
using MovieTheater.Data.Contracts;
using MovieTheater.Framework.Core.Commands.Abstractions;
using MovieTheater.Framework.Core.Commands.Contracts;
using MovieTheater.Models.Factory.Contracts;

namespace MovieTheater.Framework.Core.Commands
{
    public class CreateSeatCommand : Command, ICommand
    {
        public CreateSeatCommand(IMovieTheaterDbContext dbContext, IModelsFactory modelsFactory) 
            : base(dbContext, modelsFactory)
        {
        }

        public override string Execute(List<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}