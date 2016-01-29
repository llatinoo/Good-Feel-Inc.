using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG;
using RPG.Characters;
using RPG.Extensions_And_Helper_Classes;
using RPG.Skills;
using RPG.Skills.Effects;

namespace RPGTests
{
    /// <summary>
    /// Summary description for AppConfigTests
    /// </summary>
    [TestClass]
    public class AppConfigDataSectionTests
    {
        private Configuration GetConfiguration()
        {
            var fileMap = new ConfigurationFileMap(@"C:\Users\dengler\Documents\GitHubVisualStudio\RPG-Game\RPG\App.config");
            return ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
        }

        [TestMethod]
        public void StoryDialogsDataSectionTests()
        {
            var configuration = this.GetConfiguration();
            
            //Auslesen der app.config
            var dialogsDataSection =
                configuration.GetSection("Story") as StoryDialogsDataSection;

            var testScene =
                dialogsDataSection.Scenes.Cast<SceneElement>()
                    .SingleOrDefault(scene => scene.Id == "0");

            foreach (TextBoxElement textBox in testScene.TextBoxes)
            {
                Assert.IsNotNull(textBox.Id);
                Assert.IsNotNull(textBox.Speaker);
                Assert.IsNotNull(textBox.SpeakerPicture);
                Assert.IsNotNull(textBox.Listener);
                Assert.IsNotNull(textBox.ListenerPicture);
                Assert.IsNotNull(textBox.Row1);
                Assert.IsNotNull(textBox.Row2);
                Assert.IsNotNull(textBox.Row3);
                Assert.IsNotNull(textBox.Row4);
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
                    "Dämon",
                    100,
                    100,
                    100,
                    100,
                    100,
                    100,
                    10
                );

            var configuration = this.GetConfiguration();

            var skillCadreDataSection =
                configuration.GetSection("SkillCadre") as SkillCadreDataSection;
            var classSkillDataSection =
                configuration.GetSection("ClassSkillCadre") as ClassSkillCadreDataSection;
            
            var Class =
                classSkillDataSection.Classes.Cast<ClassElement>()
                    .SingleOrDefault(
                        concreteClass => concreteClass.Name.ToLower() == String.Format(enemy.Class.ToString().ToLower()));

            Assert.IsTrue(Class.Name.ToLower() == enemy.Class.ToString().ToLower());

            foreach (ClassSkillElement skill in Class.ClassSkills)
            {
                var skillToAdd =
                    skillCadreDataSection.Skills.Cast<SkillElement>()
                        .SingleOrDefault(
                            concreteSkill => concreteSkill.Name == skill.Name);

                List<IEffect> skillToAddEffects = new List<IEffect>();
                foreach (EffectElement effect in skillToAdd.Effects)
                {
                    
                    skillToAddEffects.Add(GetEffectFactory.GetEffect(effect.Name));
                }

                enemy.AddSkill(new Skill(skillToAdd.Name, Convert.ToInt32(skillToAdd.ManaCosts), skillToAddEffects));
            }
        }
    }
}
