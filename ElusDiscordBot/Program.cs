using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using ElusDiscordBot.Modules;
//heavily followed this guy to start, will hopefully end up with cool stuff by the end lol.
//https://www.youtube.com/watch?v=e2iaRVf4sho
namespace ElusDiscordBot
{
    class Program
    {
        static void Main(string[] args){ 
            try{
                StreamReader sr = new StreamReader("Points");
                
                string line = sr.ReadLine();
                while (line != null){
                    //format: Username, points
                    string[] split = line.Split(", ");
                    string userName = split[0].Trim();
                    int point = int.Parse(split[1].Trim());
                    points.Add(userName, point);
                    
                    line = sr.ReadLine();
                }
                sr.Close();
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }

            new Program().RunBotAsync().GetAwaiter().GetResult();

            try{
                StreamWriter sr = new StreamWriter("Points");
                foreach (KeyValuePair<string, int> pair in points){
                    sr.WriteLine(pair.Key + ", " + pair.Value);
                }
                sr.Close();
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        DiscordSocketClient client;
        CommandService commands;
        IServiceProvider services;
        static Dictionary<string, int> points = new Dictionary<string, int>();

        public async Task RunBotAsync(){
            client = new DiscordSocketClient();
            commands = new CommandService();
            services = new ServiceCollection()
            .AddSingleton(client)
            .AddSingleton(commands)
            .BuildServiceProvider();

            Commands.commandServerices = commands;

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
            }else{
                string user = arg.Author.Username;
                if(points.ContainsKey(user)){
                    points[user] += 10;
                }else{
                    points.Add(user, 10);
                }
            }
        }

        /*public void Init(){
            String line;

            
            var users = ; 
            Dictionary<SocketGuildUser, int> allAddedUsers = new Dictionary<SocketGuildUser, int>();
            
            try{
                StreamReader sr = new StreamReader("PlayerPoints");
                
                line = sr.ReadLine();
                while (line != null){
                    //format: Username, points
                    string[] split = line.Split(", ");
                    string userName = split[0].Trim();
                    int i = -1;

                    foreach (var item in users){
                        i++;
                        Console.WriteLine(users.ToString());
                        if(userName == users.ToString()){
                            break;
                        }    
                    }
                    allAddedUsers.Add(users[i], int.Parse(split[1].Trim()));
                    line = sr.ReadLine();
                }
                sr.Close();
            } catch(Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
        }*/

    }
}
