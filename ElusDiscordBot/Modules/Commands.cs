using System;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ElusDiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>{

        static Random randomness = new Random();

        [Command("ping")]
        public async Task Ping() => await ReplyAsync("pong");

        [Command("bish")]
        public async Task CallSomeOneABitch(SocketGuildUser user){
            if(user == null){
                await ReplyAsync("specify a person to call a bish please.");
                return;
            }else{
                //await ReplyAsync("<@"+ user + "> you a bish.");
                await Context.Channel.SendMessageAsync(user.Mention + " u a bish.");
            }
        }

        [Command("duel")]
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
    }   
}