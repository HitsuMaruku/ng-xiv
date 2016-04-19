namespace HMAngular.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HMAngular.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HMAngular.Models.ApplicationDbContext context)
        {
            GenerateDataCenters(context);
            GenerateWorlds(context);
            GenerateClasses(context);
            GenerateJobs(context);
            GenerateCharacters(context);
            GenerateCharacterClasses(context);
        }

        private void GenerateCharacterClasses(ApplicationDbContext context)
        {
            var entity = new List<CharacterClass>
            {
                new CharacterClass { Level = 30,
                    CharacterID = context.Characters.Single(ch => ch.FirstName == "Hitsu" && ch.LastName == "Maruku").CharacterID,
                    ClassID = context.Classes.Single(cl => cl.Name == "Gladiator").ClassID },
            };

            entity.ForEach(en => context.CharacterClasses.AddOrUpdate(e => e.CharacterClassID, en));

            context.SaveChanges();
        }

        private void GenerateCharacters(ApplicationDbContext context)
        {
            var entity = new List<Character>
            {
                new Character { FirstName = "Hitsu", LastName = "Maruku", IsLegacy = true,
                    WorldID = context.Worlds.Single(wo => wo.Name == "Aegis").WorldID },
            };

            entity.ForEach(en => context.Characters.AddOrUpdate(e => e.CharacterID, en));

            context.SaveChanges();
        }

        private void GenerateJobs(ApplicationDbContext context)
        {
            var entity = new List<Job>
            {
                new Job { Name = "Paladin",
                    ClassID = context.Classes.Single(cl => cl.Name == "Gladiator").ClassID },
            };

            entity.ForEach(en => context.Jobs.AddOrUpdate(e => e.JobID, en));

            context.SaveChanges();
        }

        private void GenerateClasses(ApplicationDbContext context)
        {
            var entity = new List<Class>
            {
                new Class { Name = "Gladiator" },
            };

            entity.ForEach(en => context.Classes.AddOrUpdate(e => e.ClassID, en));

            context.SaveChanges();
        }

        private void GenerateWorlds(ApplicationDbContext context)
        {
            var entity = new List<World>
            {
                new World { Name = "Aegis", IPAddress = "124.150.157.24", IsLegacy = true,
                    DataCenterID = context.DataCenters.Single(dc => dc.Name == "Elemental").DataCenterID },
            };

            entity.ForEach(en => context.Worlds.AddOrUpdate(e => e.WorldID, en));

            context.SaveChanges();
        }

        private void GenerateDataCenters(ApplicationDbContext context)
        {
            var entity = new List<DataCenter>
            {
                new DataCenter { Name = "Lobby", Region = "" },
                new DataCenter { Name = "Elemental", Region = "JP" },
                new DataCenter { Name = "Gaia", Region = "JP" },
                new DataCenter { Name = "Mana", Region = "JP" },
                new DataCenter { Name = "Aether", Region = "NA" },
                new DataCenter { Name = "Primal", Region = "NA" },
                new DataCenter { Name = "Chaos", Region = "EU" },
            };

            entity.ForEach(en => context.DataCenters.AddOrUpdate(e => e.DataCenterID, en));

            context.SaveChanges();
        }
    }
}
