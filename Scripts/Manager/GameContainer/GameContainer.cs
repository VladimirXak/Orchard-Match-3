using Orchard.GameSpace.Advertisements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Orchard.GameSpace
{
    public class GameContainer : Singleton<GameContainer>
    {
        protected override void Awake()
        {
            base.Awake();

            GameInfo.Init();
            Localization.Init();
            Notification.Init();
            AdsController.Init();
        }

        [SerializeField] private GameInfo _gameInfo;
        public GameInfo GameInfo
        {
            get => _gameInfo;
            private set => _gameInfo = value;
        }

        [SerializeField] private GameConfig _gameConfig;
        public GameConfig GameConfig
        {
            get => _gameConfig;
            private set => _gameConfig = value;
        }

        [SerializeField]
        private GameTaskController _gameTasks;
        public GameTaskController GameTasks
        {
            get
            {
                if (_gameTasks == null)
                    throw new System.Exception("Отсутствует GameTaskController");

                return _gameTasks;
            }
        }

        [SerializeField] private LevelLoadingData _levelLoadingData;
        public LevelLoadingData LevelLoadingData
        {
            get => _levelLoadingData;
            private set => _levelLoadingData = value;
        }

        [SerializeField]
        private GeneralAudio _generalAudio;
        public GeneralAudio GeneralAudio
        {
            get
            {
                if (_generalAudio == null)
                    throw new System.Exception("Отсутствует GeneralAudio в компоненте GameContainer");

                return _generalAudio;
            }
        }

        [SerializeField] private AdsController _adsController;
        public AdsController AdsController
        {
            get => _adsController;
            private set => _adsController = value;
        }

        [SerializeField] private Localization _localization;
        public Localization Localization
        {
            get => _localization;
            private set => _localization = value;
        }

        [SerializeField] private GameNotification _notification;
        public GameNotification Notification
        {
            get => _notification;
            private set => _notification = value;
        }
    }
}
