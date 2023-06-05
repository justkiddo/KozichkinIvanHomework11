using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace root
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private EndGamePanel endGamePanel;
        [SerializeField] private List<CoinsLogic> coins;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private List<EnemyInfo> enemyInfos;
        public override void InstallBindings()
        {
            Container.Bind<GameplayInfo>().AsSingle();
            Container.BindInterfacesTo<GamePanel>().FromInstance(gamePanel);
            Container.BindInterfacesTo<EndGamePanel>().FromInstance(endGamePanel);
            Container.Bind<IUnityLocalization>().To<UnityLocalization>().AsSingle().NonLazy();
            Container.BindInterfacesTo<GameplayController>().AsSingle().NonLazy();
           // Container.BindFactory<Enemy, EnemyFactory>();
            Container.Bind<IPlayer>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
            foreach (var enemyInfo in enemyInfos)
            {
                Container.Bind<EnemyInfo>().FromInstance(enemyInfo);
            }
            foreach (var coin in coins)
            {
                Container.Bind<CoinsLogic>().FromInstance(coin);
            }
            
        }
        
    }
}
