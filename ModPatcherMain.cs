/**
* Copyright 2019 Some Indvidual
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using HarmonyLib;


namespace PMC.ModPatcher
{
    public class ModPatcherMain : IMod
    {
        private static List<ModManager.ModEntry> ModEntries = new List<ModManager.ModEntry>();

        public void onEnabled()
        {
            var harmony = new Harmony("PMC.ModPatcher");
            harmony.PatchAll();

        }


        public void onDisabled()
        {
        }

        public string Name => "PMC.ModPatcher";

        public string Description => "PMC.ModPatcher";

        string IMod.Identifier => "PMC.ModPatcher";

        [HarmonyPatch(typeof(ModManager))]
        class ModManagerPatch01
        {
            [HarmonyPostfix]
            [HarmonyPatch(nameof(ModManager.getModEntries))]
            public static void getModEntriesPatch(ref  ReadOnlyCollection<ModManager.ModEntry> __result)
            {
                __result = ModEntries.AsReadOnly();
            }

            [HarmonyPrefix]
            [HarmonyPatch(nameof(ModManager.triggerEnable))]
            public static bool TriggerEnableMods()
            {
                return true;
            }

            [HarmonyPrefix]
            [HarmonyPatch(nameof(ModManager.triggerDisable))]
            public static bool triggerDisableMods()
            {
                return true;
            }

        }



    }

}
