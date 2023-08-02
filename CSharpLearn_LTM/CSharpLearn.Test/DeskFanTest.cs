using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace CSharpLearn.Test
{
    // 第一种
    /*
    [TestClass]
    public class DeskFanTest
    {
        [TestMethod]
        public void PowerLowerThanZero_OK()
        {
            var fan = new DeskFan(new PowerSupplyLowerThanZero());
            var expected = "Won't work.";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PowerHigherThan200_Warning()
        {
            var fan = new DeskFan(new PowerSupplyHigherThan200());
            // 注：此处为了演示，实际程序那边先故意改成了 Exploded!
            var expected = "Warning";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
        }
    }
    class PowerSupplyLowerThanZero : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }

    class PowerSupplyHigherThan200 : IPowerSupply
    {
        public int GetPower()
        {
            return 220;
        }
    }
    */

    // 第二种
    /*
    [TestClass]
    public class DeskFanTest
    {
        [TestMethod]
        public void PowerLowerThanZero_OK()
        {
            var mock = new Mock<IPowerSupply>();
            // 设置该 mock 对应的 GetPower 方法返回 0
            mock.Setup(ps => ps.GetPower()).Returns(() => 0);
            var fan = new DeskFan(mock.Object);
            var expected = "Won't work.";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PowerHigherThan200_Warning()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 220);
            var fan = new DeskFan(mock.Object);
            var expected = "Warning";
            var actual = fan.Work();
            Assert.AreEqual(expected, actual);
        }
    }
    */
}
