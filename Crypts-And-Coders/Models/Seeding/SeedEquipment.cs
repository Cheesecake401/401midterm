using Crypts_And_Coders.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace Crypts_And_Coders.Models.EquipmentSeeding
{
    public class SeedEquipment
    {
        public static void SeedEquipmentToDB(IServiceProvider serviceProvider)
        {
            using (var context = new CryptsDbContext(serviceProvider.GetRequiredService<DbContextOptions<CryptsDbContext>>()))
            {
                context.Database.EnsureCreated();
                if (context.Item.ToList().Count > 20 && context.Weapon.ToList().Count > 20) return;
                GetAndDeserializeEquipment(context);
            }
        }

        public static void GetAndDeserializeEquipment(CryptsDbContext context)
        {
            using (WebClient wc = new WebClient())
            {
                var client = new WebClient();
                var response = client.DownloadString("https://www.dnd5eapi.co/api/equipment");

                var deserialized = JsonConvert.DeserializeObject<DeserializeInital.Root>(response);

                foreach (var item in deserialized.results)
                {
                    var innerResponse = client.DownloadString($"https://www.dnd5eapi.co/api/equipment/{item.index}");

                    var innerDeserialize = JsonConvert.DeserializeObject<Root>(innerResponse);

                    if (innerDeserialize.weapon_category == "" || innerDeserialize.weapon_category == null)
                    {
                        Item newItem = new Item()
                        {
                            Name = item.name,
                            Value = $"{innerDeserialize.cost.quantity} {innerDeserialize.cost.unit}",
                        };
                        context.Entry(newItem).State = EntityState.Added;
                        context.SaveChanges();
                    }
                    else
                    {
                        Weapon newWeapon = new Weapon()
                        {
                            BaseDamage = innerDeserialize.damage != null ? innerDeserialize.damage.damage_dice : "1d6",
                            Name = innerDeserialize.name,
                            Type = innerDeserialize.weapon_category
                        };
                        context.Entry(newWeapon).State = EntityState.Added;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}