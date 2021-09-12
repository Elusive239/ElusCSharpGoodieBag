using System;
using System.IO;
using System.Linq;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ElusDiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>{

        static Random randomness = new Random();
        public static Program instance;
        public static CommandService commandServerices;

        [Command("ping"), Summary("Quick check to see if bot is running")]
        public async Task Ping() => await ReplyAsync("pong");

        [Command("bish"),Summary("Call someone a bish")]
        public async Task CallSomeOneABitch(SocketGuildUser user){
            if(user == null){
                await ReplyAsync("specify a person to call a bish please.");
                return;
            }else{
                //await ReplyAsync("<@"+ user + "> you a bish.");
                await Context.Channel.SendMessageAsync(user.Mention + " u a bish.");
            }
        }

        [Command("duel"), Summary("Duel whoever you @")]
        public async Task TimeToFight( SocketGuildUser user2){
            SocketGuildUser user1 = Context.User as SocketGuildUser;
            if(user1 == null || user2 == null){
                await ReplyAsync("Requires two users as inputs.");
                return;
            }

            DateTime dt = new DateTime();

            long startTime = dt.Millisecond;
            long currentTime = startTime;
            long endTime = startTime + 30000000;

            var duel = await ReplyAsync("Get ready to duel!");
            bool rand = (randomness.Next(20) + 1) / 10 == 1;

            while (currentTime < endTime){
                currentTime++;
                if(currentTime - startTime == 15000000){
                    await duel.DeleteAsync();
                    duel = await ReplyAsync("Three...");
                }else if(currentTime - startTime == 20000000){
                    await duel.DeleteAsync();
                    duel = await ReplyAsync("Two...");
                }else if(currentTime - startTime == 25000000){
                    await duel.DeleteAsync();
                    duel = await ReplyAsync("One...");
                }
            }   
            await ReplyAsync("DRAW!");

            if(rand){
                await ReplyAsync(user1.Mention + " drew first! GG!");
            }else {
                await ReplyAsync(user2.Mention + " drew first! GG!");
            }
        }

        //https://stackoverflow.com/questions/7617771/converting-from-ienumerable-to-list/7617783
        [Command("help")]
        public async Task Help(){
            List<CommandInfo> commands = commandServerices.Commands.ToList();
            EmbedBuilder embedBuilder = new EmbedBuilder();

            if(commands == null){
                await ReplyAsync("CommandInfo list is null. no commands?");
            }

            foreach (CommandInfo command in commands)
            {
                if(command.Name == "help"){
                    continue;
                }

                // Get the command Summary attribute information
                string embedFieldText = command.Summary ?? "No description available\n";

                embedBuilder.AddField(command.Name, embedFieldText);
            }

            await ReplyAsync("Here's a list of commands and their description: ", false, embedBuilder.Build());
        }

        [RequireOwner]
        [Command("restart"), Summary("Restarts me! Thanks, I needed it!")]
        public async Task Restart(){
            await ReplyAsync("Restarting! See you soon!");
            await instance.SavePoints();
            Program.Main(new string[0]);
        }

        [RequireOwner]
        [Command("stop"), Summary("Turns me off! Please don't!")][Alias("exit")]
        public async Task Exit(){
            await ReplyAsync("Ow! See you next time!");
            await instance.SavePoints();
            try{
                instance.logout = true;
                await Task.Run(new Action (() => instance.client.LogoutAsync()));
                await Task.Delay(1000);
            }catch{
                Console.WriteLine("Couldn't logout without error.");
            }
            Environment.Exit(0);
        }

        [Command("points")]
        public async Task GetPoints(){
            SocketGuildUser user = Context.User as SocketGuildUser;
            string userName = Context.Message.Author.Username;
            await ReplyAsync(Context.User.Mention +" you have "+instance.GetPoints(userName) + " points!");
        }
    }   
}