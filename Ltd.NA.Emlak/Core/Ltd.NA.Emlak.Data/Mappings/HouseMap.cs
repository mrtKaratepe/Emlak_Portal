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
            this.HasRequired(x => x.Owner)
                .WithMany(x => x.Houses)
                .Map(x => x.MapKey("FK_OwnerId"));
            this.HasOptional(x => x.Agent)
                .WithMany(x => x.HousesInCharge)
                .Map(x => x.MapKey("FK_AgentId"));
            this.Ignore(x => x.IsValid);
        }
    }
}
