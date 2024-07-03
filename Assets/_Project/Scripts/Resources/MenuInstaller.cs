using UnityEngine;
using valsesv._Project.Scripts.Core.Dices;
using Zenject;

namespace valsesv._Project.Scripts.Resources
{
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private DiceManager diceManager;

        public override void InstallBindings()
        {
            Container.Bind<DiceManager>().FromInstance(diceManager).AsSingle();
        }
    }
}