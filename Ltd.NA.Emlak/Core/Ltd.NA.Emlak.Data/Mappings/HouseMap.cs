using Ltd.NA.Emlak.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class HouseMap : EntityTypeConfiguration<House>
    {
        public HouseMap()
        {
            this.ToTable("tbl_Houses")
                .Property(x => x.Id);
            this.HasOptional(x => x.Category)
                .WithMany()
                .Map(x => x.MapKey("FK_CategoryId"));
            this.HasOptional(x => x.Address)
                .WithMany()
                .Map(x => x.MapKey("FK_AddressId"));
            this.Ignore(x => x.IsValid);
        }
    }

    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("tbl_Categories")
                .Property(x => x.Id);
        }
    }

    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable("tbl_Address")
                .Property(x => x.Id);
        }
    }
}
