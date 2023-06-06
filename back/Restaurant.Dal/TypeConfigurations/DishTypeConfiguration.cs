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
    public class DishTypeConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasData(
                    new Dish { PositionId = new Guid("06e0d7c2-9fbb-4c5e-b1cf-3951bba9316e"), Name = "Hamburger menu 1", TypeOfDish = "Burger", Price = 400, Weight = 350, PhotoLink = "https://ik.imagekit.io/7owxt4tem/06e0d7c2-9fbb-4c5e-b1cf-3951bba9316e_updatedAt_1684869326662?updatedAt=1686002735152" },
                    new Dish { PositionId = new Guid("94ba0fbc-76ec-4eac-9b48-5ff5859da457"), Name = "Hamburger menu 2", TypeOfDish = "Burger", Price = 450, Weight = 400, PhotoLink = "https://ik.imagekit.io/7owxt4tem/94ba0fbc-76ec-4eac-9b48-5ff5859da457_updatedAt_1684869350144?updatedAt=1686002762114" },
                    new Dish { PositionId = new Guid("860617fd-d341-41d2-a494-d982e8ae1f84"), Name = "Hamburger menu 3", TypeOfDish = "Burger", Price = 550, Weight = 450, PhotoLink = "https://ik.imagekit.io/7owxt4tem/860617fd-d341-41d2-a494-d982e8ae1f84_updatedAt_1684869385003?updatedAt=1686002789666" },
                    new Dish { PositionId = new Guid("a680749e-8e43-4877-9fe4-cb7b3caf130d"), Name = "Hamburger menu 4", TypeOfDish = "Burger", Price = 500, Weight = 400, PhotoLink = "https://ik.imagekit.io/7owxt4tem/a680749e-8e43-4877-9fe4-cb7b3caf130d_updatedAt_1684828898277?updatedAt=1686002815166" },
                    new Dish { PositionId = new Guid("78506416-6bc4-469e-9b03-1e2cf5b708a3"), Name = "Steak", TypeOfDish = "Meat", Price = 600, Weight = 500, PhotoLink = "https://ik.imagekit.io/7owxt4tem/78506416-6bc4-469e-9b03-1e2cf5b708a3_updatedAt_1684828867102?updatedAt=1686002839959" },
                    new Dish { PositionId = new Guid("349ac30a-ffa1-4c2f-a871-a172100d5dd7"), Name = "Kebab", TypeOfDish = "Meat", Price = 400, Weight = 350, PhotoLink = "https://ik.imagekit.io/7owxt4tem/349ac30a-ffa1-4c2f-a871-a172100d5dd7_updatedAt_1684828595451?updatedAt=1686002882783" },
                    new Dish { PositionId = new Guid("d0d023f5-aea2-4b19-9b18-f949b02ea87d"), Name = "Nugets", TypeOfDish = "Meat", Price = 300, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/d0d023f5-aea2-4b19-9b18-f949b02ea87d_updatedAt_1684828605346?updatedAt=1686002912137" },
                    new Dish { PositionId = new Guid("c5d0bd03-f244-4429-b59c-181268153359"), Name = "Salmon", TypeOfDish = "Fish", Price = 600, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/c5d0bd03-f244-4429-b59c-181268153359_updatedAt_1684828638160?updatedAt=1686002938650" },
                    new Dish { PositionId = new Guid("7bdc8f1d-6677-4065-8425-218e4c8bac36"), Name = "Fried with tomato souce", TypeOfDish = "Fish", Price = 700, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/7bdc8f1d-6677-4065-8425-218e4c8bac36_updatedAt_1684828713325?updatedAt=1686002966679" },
                    new Dish { PositionId = new Guid("2a287245-da79-4f6f-9bca-29c4fd1c8b05"), Name = "Grilled fish", TypeOfDish = "Fish", Price = 500, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/2a287245-da79-4f6f-9bca-29c4fd1c8b05_updatedAt_1684828669643?updatedAt=1686002999534" },
                    new Dish { PositionId = new Guid("fa744911-5fc6-486a-9cd4-3a09c539a31e"), Name = "Easter fish", TypeOfDish = "Fish", Price = 650, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/fa744911-5fc6-486a-9cd4-3a09c539a31e_updatedAt_1684828749243?updatedAt=1686003027414" },
                    new Dish { PositionId = new Guid("177b95a1-8ead-4fb1-8510-9bec5c89c16a"), Name = "Dorado", TypeOfDish = "Fish", Price = 400, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/177b95a1-8ead-4fb1-8510-9bec5c89c16a_updatedAt_1684828620582?updatedAt=1686003053586" },
                    new Dish { PositionId = new Guid("a23bcec4-d07c-4e6a-a131-43a064066304"), Name = "Chef summer fish", TypeOfDish = "Fish", Price = 500, Weight = 250, PhotoLink = "https://ik.imagekit.io/7owxt4tem/a23bcec4-d07c-4e6a-a131-43a064066304_updatedAt_1684828784696?updatedAt=1686003079826" }
                );
        }
    }
}
