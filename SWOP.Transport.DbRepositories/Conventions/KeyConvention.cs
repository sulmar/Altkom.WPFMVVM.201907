using System.Data.Entity.ModelConfiguration.Conventions;

namespace SWOP.Transport.DbRepositories.Conventions
{
    internal class KeyConvention : Convention
    {
        public KeyConvention()
        {
            this.Properties<int>()
                .Where(p => p.Name.EndsWith("Key"))
                .Configure(p => p.IsKey());
        }
    }
}
