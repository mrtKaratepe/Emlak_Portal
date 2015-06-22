using System.Data.Entity.ModelConfiguration;
using Ltd.NA.Emlak.Domain;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            this.ToTable("tbl_Person")
                .Property(x => x.Id);
        }
    }
}