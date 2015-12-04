using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Characters;
using RPG.Skills;

namespace TestTests
{   
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestMethodTest()
        {
            Skill skill = new Skill("Test", 10, null);

            Assert.IsNotNull(skill);
            Assert.AreEqual("Tes", skill.Name);
        }
    }
}
