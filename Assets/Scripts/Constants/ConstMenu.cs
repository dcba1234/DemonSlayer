using UnityEngine;

namespace Assets.Scripts.Constants
{
    public class ConstMenu
    {
        public static string Start
        {
            get
            {
                switch (GameSystem.gameLanguage)
                {
                    case SystemLanguage.Vietnamese:
                        return "Bắt đầu";
                    case SystemLanguage.English:
                        return "Start";
                    default:
                        return "Start";
                }
            }
        }
        public static string Exit
        {
            get
            {
                switch (GameSystem.gameLanguage)
                {
                    case SystemLanguage.Vietnamese:
                        return "Thoát";
                    case SystemLanguage.English:
                        return "Exit";
                    default:
                        return "Exit";
                }
            }
        }
        public static string Options
        {
            get
            {
                switch (GameSystem.gameLanguage)
                {
                    case SystemLanguage.Vietnamese:
                        return "Cài đặt";
                    case SystemLanguage.English:
                        return "Options";
                    default:
                        return "Options";
                }
            }
        }

    }
}
