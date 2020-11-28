using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod
{
  public class TynGlobalNPC : GlobalNPC
  {
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;
  }
}