using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using System.Collections.Generic;

namespace Oxide.Plugins
{
    [Info("No Code Locks", "z3eeK", "2.1.0")]
    [Description("Blocks crafting of code locks. Intended for solo only servers.")]
    public class NoCodeLocks : RustPlugin
    {
        private const string CodeLockItemName = "lock.code";

        private void Init() {
            if (!ConVar.Server.hostname.ToLower().Contains("solo only")) {
                Puts("This plugin is only active on servers named 'solo only'.");
                return;
            }
            else {
                Puts("Hostname check passed.");
            }
        }

        private void PrintToChat(BasePlayer player, string message)
        {
            if (player != null && player.IsConnected)
            {
                player.ChatMessage(message);
            }
        }

        private bool CanCraft(ItemCrafter itemCrafter, ItemBlueprint bp, int amount)
        {
            if (bp.targetItem.shortname == CodeLockItemName)
            {
                return false;
            }
            return true;
        }
    }
}