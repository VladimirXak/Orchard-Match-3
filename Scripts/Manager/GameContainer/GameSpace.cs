﻿using Orchard.GameSpace.Advertisements;

namespace Orchard.GameSpace
{
    public static class GameManager
    {
        public static GameInfo GameInfo => GameContainer.Instance.GameInfo;
        public static GameConfig Config => GameContainer.Instance.GameConfig;
        public static LevelLoadingData LevelLoadingData => GameContainer.Instance.LevelLoadingData;
        public static GeneralAudio Audio => GameContainer.Instance.GeneralAudio;
        public static AdsController Ads => GameContainer.Instance.AdsController;
        public static Localization Localization => GameContainer.Instance.Localization;
        public static GameNotification Notification => GameContainer.Instance.Notification;
    }
}
