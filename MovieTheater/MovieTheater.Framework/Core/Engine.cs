﻿using System;
using Bytes2you.Validation;
using MovieTheater.Framework.Common.Contracts;
using MovieTheater.Framework.Core.Contracts;
using MovieTheater.Framework.Core.Providers.Contracts;

namespace MovieTheater.Framework.Core
{
    public class Engine : IEngine
    {
        private const string CommandParserCheck = "Engine Parser provider";
        private const string ReaderCheck = "Engine Reader provider";
        private const string WriterCheck = "Engine Writer provider";

        private IParser commandParser;
        private IReader reader;
        private IWriter writer;

        public Engine(IParser commandParser, IReader reader, IWriter writer)
        {
            Guard.WhenArgument(commandParser, CommandParserCheck).IsNull().Throw();
            Guard.WhenArgument(reader, ReaderCheck).IsNull().Throw();
            Guard.WhenArgument(writer, WriterCheck).IsNull().Throw();

            this.commandParser = commandParser;
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            var intro = this.commandParser.Process("intro");
            this.writer.Write(intro);

            while (true)
            {
                var fullCommand = this.reader.Read();

                if (fullCommand.ToLower() == "exit")
                {
                    this.writer.Write("Program terminated.");

                    break;
                }

                try
                {
                    var executionResult = this.commandParser.Process(fullCommand);
                    this.writer.Write(executionResult);
                }
                catch (ArgumentException ex)
                {
                    this.writer.Write(ex.Message);
                }
            }
        }
    }
}