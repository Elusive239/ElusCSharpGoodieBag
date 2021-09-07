﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

//https://www.youtube.com/watch?v=e2iaRVf4sho
namespace ElusDiscordBot
{
    class Program
    {
        static void Main(string[] args) =>  new Program().RunBotAsync().GetAwaiter().GetResult();

        DiscordSocketClient client;
        CommandService commands;
        IServiceProvider services;

        public async Task RunBotAsync(){
            client = new DiscordSocketClient();
            commands = new CommandService();
            services = new ServiceCollection()
            .AddSingleton(client)
            .AddSingleton(commands)
            .BuildServiceProvider();

            string token = System.IO.File.ReadAllText("Token.txt");
            client.Log += client_log;

            await RegisterCommandsAsync();
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        public Task client_log(LogMessage arg){
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync(){
            client.MessageReceived += HandleCommandsAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        public async Task HandleCommandsAsync(SocketMessage arg){
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(client, message);
            if(message.Author.IsBot) return;

            int argPos = 0;
            if(message.HasStringPrefix("!", ref argPos)){
                var result = await commands.ExecuteAsync(context, argPos, services);
                if(!result.IsSuccess){
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
