﻿using System.Data.Entity;
using MovieTheater.CLI.NinjectModules;
using MovieTheater.Data.Contexts;
using MovieTheater.Framework.Core.Contracts;
using Ninject;

namespace MovieTheater.CLI
{
    public class StartUp
    {
        public static void Main()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieTheaterDbContext, Configuration>());

            // TODO: Not working at this point
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieTheaterDbContextLite, ConfigurationLite>());
            // var data2 = new MovieTheaterDbContextLite();
            // var foodShop = new FoodShop() { Name = "KFC" };
            // data2.FoodShops.Add(foodShop);
            // data2.SaveChanges();
            IKernel kernel = new StandardKernel(new MovieTheaterModule());
            IEngine engine = kernel.Get<IEngine>();

            engine.Start();
        }
    }
}