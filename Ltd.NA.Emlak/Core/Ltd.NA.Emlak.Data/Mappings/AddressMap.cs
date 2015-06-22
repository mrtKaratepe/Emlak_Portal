using System.Data.Entity.ModelConfiguration;
using Ltd.NA.Emlak.Domain;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable("tbl_Address")
                .Property(x => x.Id);
        }
    }
}