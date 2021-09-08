using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTeretana.Data;
using System;
using System.Linq;

namespace MvcTeretana.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTeretanaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTeretanaContext>>()))
            {
                // Look for any clans.
                if (context.Clan.Any())
                {
                    return;   // DB has been seeded
                }

                context.Clan.AddRange(
                    new Clan
                    {
                        Ime = "Matej",
                        Prezime = "Srdjak",
                        GodinaRodenja = DateTime.Parse("1993-8-19"),
                        Spol = "musko",
                        RazinaClanarine = 5,
                        ClanarinaVrijediDo = DateTime.Parse("2021-10-15"),
                        VrstaTreninga = "Cardio",
                    },

                    new Clan
                    {
                        Ime = "Klara",
                        Prezime = "Klapac",
                        GodinaRodenja = DateTime.Parse("1996-1-11"),
                        Spol = "zensko",
                        RazinaClanarine = 2,
                        ClanarinaVrijediDo = DateTime.Parse("2021-9-01"),
                    },

                    new Clan
                    {
                        Ime = "Borna",
                        Prezime = "Rajnovic",
                        GodinaRodenja = DateTime.Parse("1993-8-18"),
                        Spol = "musko",
                        RazinaClanarine = 3,
                        ClanarinaVrijediDo = DateTime.Parse("2021-12-15"),
                    },

                    new Clan
                    {
                        Ime = "Zana",
                        Prezime = "Rajnovic",
                        GodinaRodenja = DateTime.Parse("1986-6-22"),
                        Spol = "zensko",
                        RazinaClanarine = 2,
                        ClanarinaVrijediDo = DateTime.Parse("2021-12-15"),
                    }
                );
                context.SaveChanges();
            }
        }
    }
}