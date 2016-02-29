﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.Characters;
using RPG.Data_Section_Classes;
using RPG.Extensions_And_Helper_Classes;

namespace RPGTests
{
    /// <summary>
    /// Summary description for AppConfigTests
    /// </summary>
    [TestClass]
    public class AppConfigDataSectionTests
    {
        [TestMethod]
        public void StoryDialogsDataSectionTests()
        {
            //Auslesen der app.config
            var dialogsDataSection =
                ConfigurationManager.GetSection("Story") as StoryDialogsDataSection;

            var testScene =
                dialogsDataSection.Scenes.Cast<SceneElement>()
                    .SingleOrDefault(scene => scene.Id == "0");

            var testPart =
                testScene.Parts.Cast<PartElement>()
                    .SingleOrDefault(part => part.Id == "1");

            foreach (TextBoxElement box in testPart.TextBoxes)
            {
                Assert.IsNotNull(box.Id);
            }
        }

        [TestMethod]
        public void ClassSkillDataSectionTests()
        {
            var enemy = new Enemy
                (
                    "Test",
                    Classes.Warrior,
                    false,
                    100,
                    100,
                    100,
                    100,
                    100,
                    100,
                    10,
                    "",
                    "",
                    "",
                    false
                );

            LoadSkillHelperClass.AddAllClassSkills(enemy);

            Assert.IsTrue(enemy.Skills.Count > 0);
            Assert.IsTrue(enemy.AttackSkill != null);
            Assert.IsTrue(enemy.RestSkill != null);
        }
    }
}

