using Microsoft.EntityFrameworkCore;

namespace Task1.Entities
{
    public class BuyerManager
    {
        public async Task SaveTargetWarmBuyerAsync( List<TargetWarmBuyers> warmBuyers)
        {
            using (AppDbContext context=new AppDbContext())
            {
                foreach (var item in warmBuyers)
                {
                    context.TargetWarmBuyerss.Add(item);
                    context.Entry( item ).State = EntityState.Added; 

                }
                await context.SaveChangesAsync();
            }
        }
    }
}
