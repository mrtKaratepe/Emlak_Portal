using System.Data.Entity.ModelConfiguration;
using Ltd.NA.Emlak.Domain;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("tbl_Categories")
                .Property(x => x.Id);
        }
    }
}