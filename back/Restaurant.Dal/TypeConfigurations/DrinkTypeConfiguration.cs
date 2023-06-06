using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Dal.TypeConfigurations
{
    public class DrinkTypeConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasData(
                new Drink { 
                PositionId = new Guid("cdc8e3c4-42c5-47e9-932d-5d196c04351e"),
                    Name = "Espresso",
                    Price = 100,
                    TypeOfDrink = "Coffe",
                    Volume = 30,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/cdc8e3c4-42c5-47e9-932d-5d196c04351e_updatedAt_1684867378345?updatedAt=1686002415749"
                },

                new Drink
                {
                    PositionId = new Guid("eb80cd9d-6586-4d76-ae91-a8e6bf5c8b5e"),
                    Name = "Cappuccino",
                    Price = 130,
                    TypeOfDrink = "Coffe",
                    Volume = 50,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/eb80cd9d-6586-4d76-ae91-a8e6bf5c8b5e?updatedAt=1686002487487"
                },

                new Drink
                {
                    PositionId = new Guid("cc26f172-64bd-4b14-aeca-2ffe1f7d4d63"),
                    Name = "Latte",
                    Price = 140,
                    TypeOfDrink = "Coffe",
                    Volume = 50,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/cc26f172-64bd-4b14-aeca-2ffe1f7d4d63?updatedAt=1686002522820"
                },

                new Drink
                {
                    PositionId = new Guid("47d6710b-32e5-429d-8723-e7971f6bef17"),
                    Name = "Orange juice",
                    Price = 130,
                    TypeOfDrink = "Juice",
                    Volume = 200,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/47d6710b-32e5-429d-8723-e7971f6bef17?updatedAt=1686002553057"
                },

                new Drink
                {
                    PositionId = new Guid("ab10d367-35f4-4da6-ab7f-01413eddd8d4"),
                    Name = "Apple juice",
                    Price = 130,
                    TypeOfDrink = "Juice",
                    Volume = 200,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/ab10d367-35f4-4da6-ab7f-01413eddd8d4?updatedAt=1686002586188"
                },

                new Drink
                {
                    PositionId = new Guid("2708e10a-b0cd-41b9-8ed2-0a8de5d864dd"),
                    Name = "Pineapple juice",
                    Price = 130,
                    TypeOfDrink = "Juice",
                    Volume = 200,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/2708e10a-b0cd-41b9-8ed2-0a8de5d864dd?updatedAt=1686002614056"
                },

                new Drink
                {
                    PositionId = new Guid("b46d3334-e53f-4dfa-bea9-3a1aef72d5d1"),
                    Name = "Black tea",
                    Price = 100,
                    TypeOfDrink = "Tea",
                    Volume = 150,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/b46d3334-e53f-4dfa-bea9-3a1aef72d5d1?updatedAt=1686002644091"
                },

                new Drink
                {
                    PositionId = new Guid("ce5db9df-0c47-4bfc-9d5f-1412cf7dc856"),
                    Name = "Green tea",
                    Price = 150,
                    TypeOfDrink = "Tea",
                    Volume = 150,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/ce5db9df-0c47-4bfc-9d5f-1412cf7dc856?updatedAt=1686002666709"
                },
                new Drink
                {
                    PositionId = new Guid("17a3c19e-1575-4a69-ae89-46059cce8dc7"),
                    Name = "Herbal tea",
                    Price = 100,
                    TypeOfDrink = "Tea",
                    Volume = 150,
                    PhotoLink = "https://ik.imagekit.io/7owxt4tem/17a3c19e-1575-4a69-ae89-46059cce8dc7?updatedAt=1686002693678"
                }
                );
        }
    }
}
