﻿using System.Collections.Generic;
using System.Text;
using MovieTheater.Data.Contracts;
using MovieTheater.Framework.Core.Commands.Abstractions;
using MovieTheater.Framework.Core.Commands.Contracts;
using MovieTheater.Models.Factory.Contracts;

namespace MovieTheater.Framework.Core.Commands.Common
{
    public class DisplayHelpCommand : MovieTheaterCommand, ICommand
    {
        public DisplayHelpCommand(IMovieTheaterDbContext dbContext, IModelsFactory modelsFactory) : 
            base(dbContext, modelsFactory)
        {
        }

        public override string Execute(List<string> parameters)
        {
            var output = new StringBuilder();

            output.AppendLine("Below is the full list of supported commands:");
            output.AppendLine(" - Type \"createtheater [theater name] [city name]\" to create a new theater.");
            output.AppendLine(" - Type \"createmovie [movie title] [movie year] [movie duration] [movie director]\" to create a new movie.");
            output.AppendLine(" - Type \"createticket [Movie Name]  [Hall Id] [Price] [User Name] [Seat Number]\" to create a new ticket");
            output.AppendLine(" - Type \"createuser [first name] [last name] [city]\" to create a new user");
            output.AppendLine(" - Type \"createhall [Hall Number]  [Theater]\" to create a new hall");
            output.AppendLine(" - Type \"createhallschedule [Hall Number]  [Hall] [Projection Time](optional)\" to create a new hall schedule");
            output.AppendLine(" - Type \"exit\" to quit the program.");

            return output.ToString();
        }
    }
}
