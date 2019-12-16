using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Model
{
    [System.Serializable]
    public class Level
    {
        public int CurrentLevel;
        public int CurrentExp;
        public int MaxExp;
        public Level()
        {
            CurrentLevel = 1;
            CurrentExp = 0;
            MaxExp = 100;
        }

        public Level(int currentLevel, int currentExp, int maxExp)
        {
            CurrentLevel = currentLevel;
            CurrentExp = currentExp;
            MaxExp = maxExp;
        }

        /// <summary>
        /// Hàm tăng  level
        ///  max exp tăng 40% mỗi khi lên lv
        /// </summary>
        public Boolean gainExp(int exp)
        {
            CurrentExp += exp;
            if(CurrentExp > MaxExp)
            {
                CurrentLevel++;
                MaxExp += 40 * MaxExp / 100; //
                CurrentExp = CurrentExp - MaxExp;
                return true;   // 
            }
            return false;
        }

       
    }
}
