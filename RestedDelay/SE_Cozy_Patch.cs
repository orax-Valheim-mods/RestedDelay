using HarmonyLib;

namespace RestedDelay
{
    internal class SE_Cozy_Patch
    {
        [HarmonyPatch(typeof(SE_Cozy),nameof(SE_Cozy.UpdateStatusEffect), typeof(float))]
        public static class UpdateStatusEffect_Patch
        {
            public static void Prefix(SE_Cozy __instance)
            {
                __instance.m_delay = RestedDelay.restedDelay.Value;
            }
        }
    }
}
