using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace HoloDex_UI.Data
{
    public static class Organization
    {
        public const string Aetheria = "Aetheria";
        public const string AtelierLive = "Atelier Live";
        public const string dotLive = ".LIVE";
        public const string EienProject = "EIEN Project";
        public const string Hololive = "Hololive";
        public const string IdolCorp = "idol Corp";
        public const string KizunaAi = "Kizuna Ai Inc.";
        public const string Nijisanji = "Nijisanji";
        public const string PhaseConnect = "Phase Connect";
        public const string Prism = "PRISM";
        public const string SevenSeventyFour = "774inc";
        public const string Tsunderia = "Tsunderia";
        public const string TwitchIndie = "Twitch Independents";
        public const string Independent = "Independents";
        public const string Vshojo = "VShojo";

        public static string[] GetOrganizations
        {
            get
            {
                return new string[]{
                    Aetheria, AtelierLive, dotLive, EienProject,
                    Hololive, IdolCorp, KizunaAi, Nijisanji,
                    PhaseConnect, Prism, SevenSeventyFour,
                    Tsunderia, TwitchIndie, Independent, Vshojo};
            }
        }
    }

}
