using System.Data.Entity.ModelConfiguration;
using Ltd.NA.Emlak.Domain;

namespace Ltd.NA.Emlak.Data.Mappings
{
    public class AgentMap : EntityTypeConfiguration<Agent>
    {
        public AgentMap()
        {
            this.ToTable("tbl_Agent")
                .Property(x => x.Id);
        }
    }
}