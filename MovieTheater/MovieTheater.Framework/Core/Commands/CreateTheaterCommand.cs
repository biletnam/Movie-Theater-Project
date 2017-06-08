﻿using System;
using System.Collections.Generic;
using System.Linq;
using MovieTheater.Data;
using MovieTheater.Framework.Core.Commands.Contracts;
using MovieTheater.Models.Factory.Contracts;

namespace MovieTheater.Framework.Core.Commands
{
    public class CreateTheaterCommand : ICommand
    {
        private MovieTheaterDbContext dbContext;
        private IModelsFactory factory;

        public CreateTheaterCommand(MovieTheaterDbContext dbContext, IModelsFactory factory)
        {
            this.dbContext = dbContext;
            this.factory = factory;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Any(x => x == string.Empty))
            {
                throw new ArgumentException("Some of the passed parameters are empty!");
            }

            var cityName = parameters[1];
            var city = dbContext.Cities.FirstOrDefault(c => c.Name == cityName);

            if (city == null)
            {
                city = this.factory.CreateCity(cityName);
            }

            var theater = this.factory.CreateTheater(parameters[0], city);

            this.dbContext.Theaters.Add(theater);
            this.dbContext.SaveChanges();

            return $"Successfully created a new Theater with ID {theater.Id}!";
            
        }
    }
}