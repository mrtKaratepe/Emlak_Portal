using System.Data.Entity.ModelConfiguration;
using Ltd.NA.Emlak.Domain;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("tbl_Customer")
                .Property(x => x.Id);
        }
    }
}