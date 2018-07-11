using NUnit.Framework;
using System;
using Zenject;
using HW2.DI;

namespace HW2.UnitTesting
{

    public class TesterDIInstaller : BindingInstaller 
    {
        public override void Bind()
        {

            ContainerBindInterfaceTo<IKeyDI, KeyDI>(true);
            ContainerBindInterfaceTo<IHousePwdDI, HousePwdDI>(true);
            ContainerBindInterfaceTo<IHouseKeyDI, HouseKeyDI>(true);
            ContainerBindInterfaceTo<IDoorKeyDI, DoorKeyDI>(true);
            ContainerBindInterfaceTo<IDoorPwdDI, DoorPwdDI>(true);
            ContainerBindInterfaceTo<IKeyholdDI, KeyholdDI>(true);
            ContainerBindInterfaceTo<IOpener, Opener>(true);

            Container.Bind<IHouseDI>().WithId("HouseWithKey").To<HouseKeyDI>().AsSingle();
            Container.Bind<IHouseDI>().WithId("HouseWithPwd").To<HousePwdDI>().AsSingle();

            Container.Bind<IDoorDI>().To<DoorKeyDI>().AsSingle().WhenInjectedInto<HouseKeyDI>();
            Container.Bind<IDoorDI>().To<DoorPwdDI>().AsSingle().WhenInjectedInto<HousePwdDI>();

            Container.Bind<IKnobDI>().To<KnobKeyDI>().AsSingle().WhenInjectedInto<DoorKeyDI>();
            Container.Bind<IKnobDI>().To<KnobPwdDI>().AsSingle().WhenInjectedInto<DoorPwdDI>();

            Container.Bind<int>().FromInstance(1).WhenInjectedInto<KeyDI>();
            Container.Bind<int>().FromInstance(1).WhenInjectedInto<KeyholdDI>();
            Container.Bind<string>().FromInstance("12345").WhenInjectedInto<KnobPwdDI>();
            Container.Bind<string>().FromInstance("12345").WhenInjectedInto<Opener>();
        }
    }
}
