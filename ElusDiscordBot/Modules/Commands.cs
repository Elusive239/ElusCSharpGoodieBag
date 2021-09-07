using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ElusDiscordBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>{

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
    }   
}