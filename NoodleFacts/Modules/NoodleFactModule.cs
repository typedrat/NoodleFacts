using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using NoodleFacts.Facts;

namespace NoodleFacts.Modules
{
    public class NoodleFactModule : ModuleBase<SocketCommandContext>
    {
        [Command("Hi Riley")]
        public async Task Great1([Remainder] string ignore = null)
        {
            await GetRandomNoodleFactAsync();
        }

        [Command("Hi Riley!")]
        public async Task Great2([Remainder] string ignore = null)
        {
            await GetRandomNoodleFactAsync();
        }

        [Command("Hi Riley.")]
        public async Task Great3([Remainder] string ignore = null)
        {
            await GetRandomNoodleFactAsync();
        }

        [Command("mlem")]
        public async Task Mlem1([Remainder] string ignore = null)
        {
            string reply = "Mlem!";
            Random random = new Random();
            if (random.Next(100)+1 == 100) 
            {
                reply = "*Yawn*";
            }
            await ReplyAsync(reply);
        }


        [Command("mlem!")]
        public async Task Mlem2([Remainder] string ignore = null)
        {
            string reply = "Mlem!";
            Random random = new Random();
            if (random.Next(100)+1 == 100) 
            {
                reply = "*Yawn*";
            }
            await ReplyAsync(reply);
        }

        [Command("mlem.")]
        public async Task Mlem3([Remainder] string ignore = null)
        {
            string reply = "Mlem!";
            Random random = new Random();
            if (random.Next(100)+1 == 100) 
            {
                reply = "*Yawn*";
            }
            await ReplyAsync(reply);
        }

        [Command("mlem?")]
        public async Task Mlem4([Remainder] string ignore = null)
        {
            string reply = "Mlem!";
            Random random = new Random();
            if (random.Next(100)+1 == 100) 
            {
                reply = "*Yawn*";
            }
            await ReplyAsync(reply);
        }

        [Command("🐀")]
        public async Task Nom1([Remainder] string ignore = null)
        {
            string reply = "*Nom*";
            await ReplyAsync(reply);
        }

        [Command("🐁")]
        public async Task Nom2([Remainder] string ignore = null)
        {
            string reply = "*Nom*";
            await ReplyAsync(reply);
        }

        [Command("🐭")]
        public async Task Nom3([Remainder] string ignore = null)
        {
            string reply = "*Nom*";
            await ReplyAsync(reply);
        }

        [Command("!inabox")]
        public async Task InABox([Remainder] string ignore = null)
        {
            await ReplyAsync("I'm living in a box now. 🐳📦");
        }

        public async Task GetRandomNoodleFactAsync([Remainder] string ignore = null)
        {
            string fact = NoodleFactList.GetRandomFact();
            fact = fact == "" ? "Snakes are cute" : fact;
            await ReplyAsync("Mlem! Hi " + Context.User.Mention + "! Did you know that: " + fact);
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("!noodlefact")]
        public async Task GetNoodleFactAsync(int factId)
        {
            try
            {
                factId--;
                string fact = NoodleFactList.GetFact(factId);
                fact = fact == "" ? "Snakes are cute" : fact;
                await ReplyAsync("Mlem! Hi " + Context.User.Mention + "! Did you know that: " + fact);
            }
            catch (Exception)
            {
                await ReplyAsync("Mlem! That's not a valid fact number!");
            }
        }
        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("!noodlefactcount")]
        public async Task GetNoodleFactCountAsync([Remainder] string ignore = null)
        {
            int factCount = NoodleFactList.FactList.Count;
            await ReplyAsync("Mlem! I know " + factCount + " noodle facts!");
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("+noodlefact")]
        public async Task AddNoodleFactAsync([Remainder] string newFact)
        {
            NoodleFactList.AddFact(newFact);
            NoodleFactList.SaveFacts();

            await ReplyAsync("Mlem! I learned something new!");
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("-noodlefact")]
        public async Task RemoveNoodleFactAsync(int factId)
        {
            NoodleFactList.RemoveFact(factId);
            NoodleFactList.SaveFacts();

            await ReplyAsync("Mlem! I have forgotten that fact");
        }

        [RequireUserPermission(GuildPermission.Administrator)]
        [Command("!lastfact")]
        public async Task GetLastFactAsync([Remainder] string ignore = null)
        {
            int lastfact = NoodleFactList.LastFact;
            var reply = "Mlem! The last fact was: " + NoodleFactList.FactList[lastfact].Fact;
            reply += "\nMlem! The last fact was number: " + lastfact;
            await ReplyAsync(reply);
        }
    }
}