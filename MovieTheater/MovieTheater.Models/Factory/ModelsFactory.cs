﻿using System;
using MovieTheater.Models.Factory.Contracts;
using System.Collections.Generic;

namespace MovieTheater.Models.Factory
{
    public class ModelsFactory : IModelsFactory
    {
        public Theater CreateTheater(string theaterName, City city)
        {
            Theater theater = new Theater() { Name = theaterName, City = city };

            return theater;
        }

        public Theater CreateTheater(string theaterName, City city, ICollection<User> users)
        {
            Theater theater = new Theater() { Name = theaterName, City = city, Users = users };

            return theater;
        }

        public City CreateCity(string cityName)
        {
            City city = new City() { Name = cityName };

            return city;
        }

        public Movie CreateMovie()
        {
            Movie movie = new Movie();

            return movie;
        }

        public Hall CreateHall()
        {
            Hall hall = new Hall();

            return hall;
        }

        public Ticket CreateTicket()
        {
            Ticket ticket = new Ticket();

            return ticket;
        }

        public User CreateUser(string firstName, string lastName, City city)
        {
            User user = new User() { FirstName = firstName, LastName = lastName, City = city };

            return user;
        }
    }
}