using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace HoloDex_UI.Data
{
    public static class Organization
    {
        public const string AtelierLive = "Atelier Live";
        public const string dotLive = ".LIVE";
        public const string EienProject = "EIEN Project";
        public const string Hololive = "Hololive";
        public const string IdolCorp = "idol Corp";
        public const string KizunaAi = "Kizuna Ai Inc.";
        public const string MyHoloTV = "MyHolo TV";
        public const string Nijisanji = "Nijisanji";
        public const string PhaseConnect = "Phase Connect";
        public const string Prism = "PRISM";
        public const string Kawaii = "Production Kawaii";
        public const string SevenSeventyFour = "774inc";
        public const string Tsunderia = "Tsunderia";
        public const string TwitchIndie = "Twitch Independents";
        public const string Independent = "Independents";
        public const string VU = "V&U";
        public const string Vshojo = "VShojo";
        public const string VReverie = "VReverie";
        public const string Globie = "globie";
        public const string V4Mirai = "V4Mirai";
        public const string MilPro = "MillionProduction";
        public const string PixelLink = "PixelLink";
        public const string Specialite = "Specialite";
        public const string Mixst = "Mixstgirls";



        public static string[] GetOrganizations
        {
            get
            {
                return new string[]{
                    AtelierLive, dotLive, EienProject,
                    Hololive, IdolCorp, KizunaAi,
                    MyHoloTV, Nijisanji, PhaseConnect,
                    Prism, Kawaii, SevenSeventyFour,
                    Tsunderia, TwitchIndie, Independent,
                    VU, Vshojo, VReverie, Globie, V4Mirai,
                    MilPro, PixelLink, Specialite, Mixst};
            }
        }
    }
}
