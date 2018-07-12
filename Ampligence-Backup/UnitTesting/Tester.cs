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
        const float EPSILON = 0.000001f;

        protected override void SetInstallers()
        {
            installers.Add(new TesterInstaller());
        }

        [Inject]
        IRectangle2D _rectangle2D; //width=2 height =2 

        [Inject]
        IRectangle3D _rectangle3D;

        [Inject]
        IMappingTransform _mapping;

        [Inject(Id = "ModifiableVector")]
        IVector _tmp;

        [Inject(Id ="DestinationForTranslate")]
        IVector _destination;

        [Inject(Id = "DeltaForTranslate")] //moving back to origin
        IVector _delta;

        [Inject]
        Quaternion _quaternion;
        // Extra explain for design:
        // vector (center,B)=(1,1,0) , B is a corner, rotate about x (1,0,0) wiseclock 90 degrees
        // Quaternion p =(1,1,0,0) for vector (center,B), Quaternion q = (x*sin45, cos45) for rotation, 
        // p' = q .* p .* q^(-1) after calculate p' = (1,0,1,0)
        // => (center,B') should be (1,0,1) , B' is new corner B.


        [Inject(Id = "ScaleLocalX")]
        float _scaleLocalX; //1

        [Inject(Id = "ScaleLocalY")]
        float _scaleLocalY;  //2


        [Test]
        public void CheckMap()
        {
            _mapping.InitMap(_rectangle2D);
            _rectangle3D = _mapping.Rectangle3D;

            Assert.IsTrue(AreEqualf(_rectangle3D.center[2], 0f));
            Assert.IsTrue(AreEqualf(_rectangle3D.leftUp[2], 0f));
            Assert.IsTrue(AreEqualf(_rectangle3D.rightUp[2], 0f));
            Assert.IsTrue(AreEqualf(_rectangle3D.leftDown[2], 0f));
            Assert.IsTrue(AreEqualf(_rectangle3D.rightDown[2], 0f));

        }
        [Test]
        public void CheckTranslate()
        {
            _mapping.Translate(_destination);

            Assert.IsTrue(_rectangle3D.center.Equals(_destination));

            _mapping.TranslateByDelta(_delta);

            _tmp[0] = _tmp[1] = _tmp[2] = 0f;

            Assert.IsTrue(_rectangle3D.center.Equals(_tmp));

        }
        [Test]
        public void CheckRotate()
        {
            _mapping.Rotate(_quaternion);

            _tmp[0] = 1f; _tmp[1] = 0f; _tmp[2] = 1f;

            Assert.IsTrue(_rectangle3D.rightUp.Equals(_tmp));

        }
        [Test]
        public void CheckScale()
        {
            _mapping.Scale(_scaleLocalX,_scaleLocalY);

            Assert.IsTrue(AreEqualf(_rectangle3D.area, 4f * 2f));
            Assert.IsTrue(AreEqualf(_rectangle3D.width, 2f * 2f));
            Assert.IsTrue(AreEqualf(_rectangle3D.height, 2f * 1f));
        }


        private bool AreEqualf(float input,float target)
        {
            if ((input >= target - EPSILON) && (input <= target + EPSILON)) return true;
            else return false;
        }

    }
}