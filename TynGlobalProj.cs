using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod
{
  public class TynGlobalProj : GlobalProjectile
  {
    public bool bloodAmpBoosted;
    public bool deflected;
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;
  }
}