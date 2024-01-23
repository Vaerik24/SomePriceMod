using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using Mono.Cecil.Cil;
using System;
using System.Xml;

namespace SomePriceMod
{

    [BepInPlugin(ID, NOM, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance { get; private set; }

        public const string ID = "com.vaerik.github.SomePricingMod";
        public const string NOM = "SomePricingMod";
        public const string VERSION = "1.0.0";

        internal static ManualLogSource log;

        internal static ConfigEntry<int> 
            config_WalkieTalkie,
            config_Flashlight,
            config_Shovel,
            config_Lockpicker,
            config_Proflashlight,
            config_StunGrenade,
            config_Boombox,
            config_TZPInhalant,
            config_ZapGun,
            config_Jetpack,
            config_ExtensionLadder,
            config_Radarbooster,
            config_SprayPaint;

        private readonly Harmony harmony = new Harmony(VERSION);


        private void Awake()
        {
            instance = this;
            log = Logger;
            harmony.PatchAll();

            config_WalkieTalkie = Config.Bind("Settings", "Walkie-Talkie", 12, "Change the price for the Walkie-Talkie (default : 12)");
            config_Flashlight = Config.Bind("Settings", "Flashlight", 15, "Change the price for the Flashlight (default : 15)");
            config_Shovel = Config.Bind("Settings", "Shovel", 30, "Change the price for the Shovel (default : 30)");
            config_Lockpicker = Config.Bind("Settings", "Lockpicker", 20, "Change the price for the Lockpicker (default : 20)");
            config_Proflashlight = Config.Bind("Settings", "Pro-flashlight", 25, "Change the price for the Walkie-Talkie (default : 25)");
            config_StunGrenade = Config.Bind("Settings", "StunGrenade", 30, "Change the price for the StunGrenade (default : 30)");
            config_Boombox = Config.Bind("Settings", "Boombox", 60, "Change the price for the Boombox (default : 60)");
            config_TZPInhalant = Config.Bind("Settings", "TZP-Inhalant", 120, "Change the price for the TZP-Inhalant (default : 120)");
            config_ZapGun = Config.Bind("Settings", "ZapGun", 400, "Change the price for the ZapGun (default : 400)");
            config_Jetpack = Config.Bind("Settings", "Jetpack", 400, "Change the price for the Jetpack (default : 400)");
            config_ExtensionLadder = Config.Bind("Settings", "ExtensionLadder", 60, "Change the price for the ExtensionLadder (default : 60)");
            config_Radarbooster = Config.Bind("Settings", "Radar-booster", 60, "Change the price for the Radar-booster (default : 60)");
            config_SprayPaint = Config.Bind("Settings", "Spray-Paint", 50, "Change the price for the Spray-Paint (default : 50)");

            Logger.LogInfo($"Plugin " + NOM + "is loaded!");
        }


    }
}

namespace SomePriceMod.Patches
{


    [HarmonyPatch(typeof(Terminal))]
	internal class PricePatches
	{



        [HarmonyPatch("SetItemSales")]
		[HarmonyPostfix]

		private static void StorePrices(ref Item[] ___buyableItemsList)
		{
            
            ___buyableItemsList[0].creditsWorth = Plugin.config_WalkieTalkie.Value; //Walkie-Talkie
            ___buyableItemsList[1].creditsWorth = Plugin.config_Flashlight.Value; //Flashlight
            ___buyableItemsList[2].creditsWorth = Plugin.config_Shovel.Value; //Shovel
            ___buyableItemsList[3].creditsWorth = Plugin.config_Lockpicker.Value; //Lockpicker
            ___buyableItemsList[4].creditsWorth = Plugin.config_Proflashlight.Value; //Pro-flashlight
            ___buyableItemsList[5].creditsWorth = Plugin.config_StunGrenade.Value; //Stun Grenade
            ___buyableItemsList[6].creditsWorth = Plugin.config_Boombox.Value; //Boombox
            ___buyableItemsList[7].creditsWorth = Plugin.config_TZPInhalant.Value; //TZP-Inhalant
            ___buyableItemsList[8].creditsWorth = Plugin.config_ZapGun.Value; //Zap Gun
            ___buyableItemsList[9].creditsWorth = Plugin.config_Jetpack.Value; //Jetpack
            ___buyableItemsList[10].creditsWorth =Plugin.config_ExtensionLadder.Value; //Extension Ladder
            ___buyableItemsList[11].creditsWorth =Plugin.config_Radarbooster.Value; //Radar-booster
            ___buyableItemsList[12].creditsWorth = Plugin.config_SprayPaint.Value; // Spray-Paint
        }
    }
}
