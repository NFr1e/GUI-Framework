using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace App.User
{
    [CreateAssetMenu(menuName = "App/Users/UserPrefs")]
    public class UserPrefsCollection : ScriptableObject
    {
        [BoxGroup("General")]
        public bool HasSaved = false;
        [BoxGroup("Toggles")]
        public bool
            UseFullScreen = true,
            UseSplashScreen = false,
            UseVsync = false;
        [BoxGroup("Integers")]
        public int
            TargetFrameRate = 60,
            TargetRefreshRate = 60,
            PreferredStartPageIndex = 0;

        /// <summary>
        /// 将Scriptable中的值保存到PlayerPrefs中
        /// </summary>
        public void SavePrefs()
        {
            PlayerPrefs.SetInt("userprefs.toggles.usesplashscreen", UseSplashScreen ? 1 : 0);
            PlayerPrefs.SetInt("userprefs.toggles.usefullscreen", UseFullScreen ? 1 : 0);
            PlayerPrefs.SetInt("userprefs.toggles.usevsync", UseVsync ? 1 : 0);
            PlayerPrefs.SetInt("userprefs.integers.targetframerate", TargetFrameRate);
            PlayerPrefs.SetInt("userprefs.integers.preferredstartpageindex", PreferredStartPageIndex);

            PlayerPrefs.SetInt("userprefs.hassaved", 1);

            PlayerPrefs.Save();
        }
        /// <summary>
        /// 加载PlayerPrefs存储的值到ScriptableObject中
        /// </summary>
        public void LoadPrefs()
        {
            GetValue("userprefs.hassaved", ref HasSaved);
            GetValue("userprefs.toggles.usesplashscreen", ref UseSplashScreen);
            GetValue("userprefs.toggles.usefullscreen", ref UseFullScreen);
            GetValue("userprefs.toggles.usevsync", ref UseVsync);
            GetValue("userprefs.integers.targetframerate", ref TargetFrameRate);
            GetValue("userprefs.integers.preferredstartpageindex", ref PreferredStartPageIndex);
        }
        #region GetValue Overloads
        /// <summary>
        /// 从PlayerPrefs中获得对应bool值的key值并写入target中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="target"></param>
        private void GetValue(string key, ref bool target)
        {
            if (PlayerPrefs.HasKey(key))
            {
                int result = PlayerPrefs.GetInt(key);
                target = result == 1 ? true : false;
            }
            else Debug.Log("没有相应的Key值");
        }
        /// <summary>
        /// 从PlayerPrefs中获得对应int值的key值并写入target中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="target"></param>
        private void GetValue(string key, ref int target)
        {
            if (PlayerPrefs.HasKey(key))
            {
                target = PlayerPrefs.GetInt(key);
            }
            else Debug.Log("没有相应的Key值");
        }
        /// <summary>
        /// 从PlayerPrefs中获得对应float值的key值并写入target中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="target"></param>
        private void GetValue(string key,ref float target)
        {
            if (PlayerPrefs.HasKey(key))
            {
                target = PlayerPrefs.GetFloat(key);
            }
            else Debug.Log("没有相应的Key值");
        }
        /// <summary>
        /// 从PlayerPrefs中获得对应string值的key值并写入target中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="target"></param>
        private void GetValue(string key, ref string target)
        {
            if (PlayerPrefs.HasKey(key))
            {
                target = PlayerPrefs.GetString(key);
            }
            else Debug.Log("没有相应的Key值");
        }
        #endregion
        public void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
