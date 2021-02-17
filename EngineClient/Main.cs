using System;
using CitizenFX.Core;
using CitizenFX.Core.UI;
using CitizenFX.Core.Native;
using static CitizenFX.Core.Native.API;

namespace EngineClient
{
    public class Main : BaseScript
    {
        public Main()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            TriggerEvent("chat:addSuggestion", "/killeng", "Kill's The Vehicle's Engine.");
            API.RegisterCommand("killeng", new Action(KillEngine), false);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            Debug.WriteLine($"The resource {resourceName} has been loaded on the Client");
        }

        private void KillEngine()
        {
            API.SetVehicleEngineHealth(GetVehiclePedIsUsing(PlayerPedId()), -4000);

            Screen.ShowNotification("~r~Engine Dying");
        }
    }
}
