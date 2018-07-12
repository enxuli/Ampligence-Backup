using NUnit.Framework;
using System;
using Zenject;
using UnityEngine;
using System.Collections;
using AmpligenceBackup.Mapping;

namespace AmpligenceBackup.UnitTesting
{
    [TestFixture]
    public class Tester : UnitTestBase 
    {

        protected override void SetInstallers()
        {
            installers.Add(new TesterInstaller());
        }

        [Inject]
        IRectangle2D _rectangle2D;

        [Inject]
        IRectangle3D _rectangle3D;

        [Inject]
        IMappingTransform _mapping;

        [Inject]
        IVector _tmp;

        [Inject(Id ="DestinationForTranslate")]
        IVector _destination;

        [Inject(Id = "DeltaForTranslate")]
        IVector _delta;

        [Inject]
        Quaternion _quaternion;

        [Inject(Id = "ScaleLocalX")]
        float _scaleLocalX;

        [Inject(Id = "ScaleLocalY")]
        float _scaleLocalY;


        [Test]
        public void CheckMap()
        {
            _rectangle3D = _mapping.Map(_rectangle2D);

            Assert.IsTrue(_isrectangle);

        }


    }
}