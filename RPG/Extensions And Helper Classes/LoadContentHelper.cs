using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Extensions_And_Helper_Classes
{
    public static class LoadContentHelper
    {
        //Animations

        //Female
        public static Animation AnnaStandardAnimation = new Animation();
        public static Animation AnnaAttackAnimation = new Animation();
        public static Animation AnnaDeathAnimation = new Animation();
         
        public static Animation ElenaStandardAnimation = new Animation();
        public static Animation ElenaAttackAnimation = new Animation();
        public static Animation ElenaDeathAnimation = new Animation();

        public static Animation EllsStandardAnimation = new Animation();
        public static Animation EllsAttackAnimation = new Animation();
        public static Animation EllsDeathAnimation = new Animation();

        public static Animation GenefeStandardAnimation = new Animation();
        public static Animation GenefeAttackAnimation = new Animation();
        public static Animation GenefeDeathAnimation = new Animation();

        public static Animation MarleinStandardAnimation = new Animation();
        public static Animation MarleinAttackAnimation = new Animation();
        public static Animation MarleinDeathAnimation = new Animation();


        //Male
        public static Animation CasparStandardAnimation = new Animation();
        public static Animation CasparAttackAnimation = new Animation();
        public static Animation CasparDeathAnimation = new Animation();

        public static Animation JosStandardAnimation = new Animation();
        public static Animation JosAttackAnimation = new Animation();
        public static Animation JosDeathAnimation = new Animation();

        public static Animation KaiserStandardAnimation = new Animation();
        public static Animation KaiserAttackAnimation = new Animation();
        public static Animation KaiserDeathAnimation = new Animation();

        public static Animation NickStandardAnimation = new Animation();
        public static Animation NickAttackAnimation = new Animation();
        public static Animation NickDeathAnimation = new Animation();

        public static Animation SeitzStandardAnimation = new Animation();
        public static Animation SeitzAttackAnimation = new Animation();
        public static Animation SeitzDeathAnimation = new Animation();

        public static Animation SeyfridStandardAnimation = new Animation();
        public static Animation SeyfridAttackAnimation = new Animation();
        public static Animation SeyfridDeathAnimation = new Animation();


        //Animated Enemies

        //Female
        public static Animation EnemyAnnaStandardAnimation = new Animation();
        public static Animation EnemyAnnaAttackAnimation = new Animation();
        public static Animation EnemyAnnaDeathAnimation = new Animation();

        public static Animation EnemyElenaStandardAnimation = new Animation();
        public static Animation EnemyElenaAttackAnimation = new Animation();
        public static Animation EnemyElenaDeathAnimation = new Animation();

        public static Animation EnemyEllsStandardAnimation = new Animation();
        public static Animation EnemyEllsAttackAnimation = new Animation();
        public static Animation EnemyEllsDeathAnimation = new Animation();

        public static Animation EnemyIreneStandardAnimation = new Animation();
        public static Animation EnemyIreneAttackAnimation = new Animation();
        public static Animation EnemyIreneDeathAnimation = new Animation();

        public static Animation EnemyMarleinStandardAnimation = new Animation();
        public static Animation EnemyMarleinAttackAnimation = new Animation();
        public static Animation EnemyMarleinDeathAnimation = new Animation();


        //Male
        public static Animation EnemyKaiserStandardAnimation = new Animation();
        public static Animation EnemyKaiserAttackAnimation = new Animation();
        public static Animation EnemyKaiserDeathAnimation = new Animation();

        public static Animation EnemyMichaelStandardAnimation = new Animation();
        public static Animation EnemyMichaelAttackAnimation = new Animation();
        public static Animation EnemyMichaelDeathAnimation = new Animation();

        public static Animation EnemyReinhardtStandardAnimation = new Animation();
        public static Animation EnemyReinhardtAttackAnimation = new Animation();
        public static Animation EnemyReinhardtDeathAnimation = new Animation();

        public static SpriteFont AwesomeFont;

        //Faces
        public static GUIElement AnnaStandardFace = new GUIElement("Faces\\Anna\\Anna_Standard_Face");
        public static GUIElement AnnaNotAmusedFace = new GUIElement("Faces\\Anna\\Anna_NotAmused_Face");
        public static GUIElement AnnaProvokeFace = new GUIElement("Faces\\Anna\\Anna_Provoke_Face");
        public static GUIElement AnnaShockedFace = new GUIElement("Faces\\Anna\\Anna_Shocked_Face");
        public static GUIElement AnnaThoughtfulFace = new GUIElement("Faces\\Anna\\Anna_Thoughtful_Face");
        public static GUIElement AnnaHappyFace = new GUIElement("Faces\\Anna\\Anna_Happy_Face");
        public static GUIElement AnnaCryFace = new GUIElement("Faces\\Anna\\Anna_Cry_Face");

        public static GUIElement GenefeStandardFace = new GUIElement("Faces\\Genefe\\Genefe_Standard_Face");
        public static GUIElement GenefeNotAmusedFace = new GUIElement("Faces\\Genefe\\Genefe_NotAmused_Face");
        public static GUIElement GenefeProvokeFace = new GUIElement("Faces\\Genefe\\Genefe_Provoke_Face");
        public static GUIElement GenefeShockedFace = new GUIElement("Faces\\Genefe\\Genefe_Shocked_Face");
        public static GUIElement GenefeThoughtfulFace = new GUIElement("Faces\\Genefe\\Genefe_Thoughtful_Face");
        public static GUIElement GenefeHappyFace = new GUIElement("Faces\\Genefe\\Genefe_Happy_Face");
        public static GUIElement GenefeCryFace = new GUIElement("Faces\\Genefe\\Genefe_Cry_Face");

        public static GUIElement MarleinStandardFace = new GUIElement("Faces\\Marlein\\Marlein_Standard_Face");
        public static GUIElement MarleinNotAmusedFace = new GUIElement("Faces\\Marlein\\Marlein_NotAmused_Face");
        public static GUIElement MarleinProvokeFace = new GUIElement("Faces\\Marlein\\Marlein_Provoke_Face");
        public static GUIElement MarleinShockedFace = new GUIElement("Faces\\Marlein\\Marlein_Shocked_Face");
        public static GUIElement MarleinThoughtfulFace = new GUIElement("Faces\\Marlein\\Marlein_Thoughtful_Face");
        public static GUIElement MarleinHappyFace = new GUIElement("Faces\\Marlein\\Marlein_Happy_Face");
        public static GUIElement MarleinCryFace = new GUIElement("Faces\\Marlein\\Marlein_Cry_Face");

        public static GUIElement EllsStandardFace = new GUIElement("Faces\\Ells\\Ells_Standard_Face");
        public static GUIElement EllsNotAmusedFace = new GUIElement("Faces\\Ells\\Ells_NotAmused_Face");
        public static GUIElement EllsProvokeFace = new GUIElement("Faces\\Ells\\Ells_Provoke_Face");
        public static GUIElement EllsShockedFace = new GUIElement("Faces\\Ells\\Ells_Shocked_Face");
        public static GUIElement EllsThoughtfulFace = new GUIElement("Faces\\Ells\\Ells_Thoughtful_Face");
        public static GUIElement EllsHappyFace = new GUIElement("Faces\\Ells\\Ells_Happy_Face");
        public static GUIElement EllsCryFace = new GUIElement("Faces\\Ells\\Ells_Cry_Face");

        public static GUIElement ElenaStandardFace = new GUIElement("Faces\\Elena\\Elena_Standard_Face");
        public static GUIElement ElenaNotAmusedFace = new GUIElement("Faces\\Elena\\Elena_NotAmused_Face");
        public static GUIElement ElenaProvokeFace = new GUIElement("Faces\\Elena\\Elena_Provoke_Face");
        public static GUIElement ElenaShockedFace = new GUIElement("Faces\\Elena\\Elena_Shocked_Face");
        public static GUIElement ElenaThoughtfulFace = new GUIElement("Faces\\Elena\\Elena_Thoughtful_Face");
        public static GUIElement ElenaHappyFace = new GUIElement("Faces\\Elena\\Elena_Happy_Face");

        public static GUIElement CasparStandardFace = new GUIElement("Faces\\Caspar\\Caspar_Standard_Face");
        public static GUIElement CasparNotAmusedFace = new GUIElement("Faces\\Caspar\\Caspar_NotAmused_Face");
        public static GUIElement CasparProvokeFace = new GUIElement("Faces\\Caspar\\Caspar_Provoke_Face");
        public static GUIElement CasparShockedFace = new GUIElement("Faces\\Caspar\\Caspar_Shocked_Face");
        public static GUIElement CasparThoughtfulFace = new GUIElement("Faces\\Caspar\\Caspar_Thoughtful_Face");
        public static GUIElement CasparHappyFace = new GUIElement("Faces\\Caspar\\Caspar_Happy_Face");

        public static GUIElement JosStandardFace = new GUIElement("Faces\\Jos\\Jos_Standard_Face");
        public static GUIElement JosNotAmusedFace = new GUIElement("Faces\\Jos\\Jos_NotAmused_Face");
        public static GUIElement JosProvokeFace = new GUIElement("Faces\\Jos\\Jos_Provoke_Face");
        public static GUIElement JosShockedFace = new GUIElement("Faces\\Jos\\Jos_Shocked_Face");
        public static GUIElement JosThoughtfulFace = new GUIElement("Faces\\Jos\\Jos_Thoughtful_Face");
        public static GUIElement JosHappyFace = new GUIElement("Faces\\Jos\\Jos_Happy_Face");

        public static GUIElement KaiserStandardFace = new GUIElement("Faces\\Kaiser\\Kaiser_Standard_Face");
        public static GUIElement KaiserNotAmusedFace = new GUIElement("Faces\\Kaiser\\Kaiser_NotAmused_Face");
        public static GUIElement KaiserProvokeFace = new GUIElement("Faces\\Kaiser\\Kaiser_Provoke_Face");
        public static GUIElement KaiserShockedFace = new GUIElement("Faces\\Kaiser\\Kaiser_Shocked_Face");
        public static GUIElement KaiserThoughtfulFace = new GUIElement("Faces\\Kaiser\\Kaiser_Thoughtful_Face");
        public static GUIElement KaiserHappyFace = new GUIElement("Faces\\Kaiser\\Kaiser_Happy_Face");

        public static GUIElement NickStandardFace = new GUIElement("Faces\\Nick\\Nick_Standard_Face");
        public static GUIElement NickNotAmusedFace = new GUIElement("Faces\\Nick\\Nick_NotAmused_Face");
        public static GUIElement NickProvokeFace = new GUIElement("Faces\\Nick\\Nick_Provoke_Face");
        public static GUIElement NickShockedFace = new GUIElement("Faces\\Nick\\Nick_Shocked_Face");
        public static GUIElement NickThoughtfulFace = new GUIElement("Faces\\Nick\\Nick_Thoughtful_Face");
        public static GUIElement NickHappyFace = new GUIElement("Faces\\Nick\\Nick_Happy_Face");

        public static GUIElement SeitzStandardFace = new GUIElement("Faces\\Seitz\\Seitz_Standard_Face");
        public static GUIElement SeitzNotAmusedFace = new GUIElement("Faces\\Seitz\\Seitz_NotAmused_Face");
        public static GUIElement SeitzProvokeFace = new GUIElement("Faces\\Seitz\\Seitz_Provoke_Face");
        public static GUIElement SeitzShockedFace = new GUIElement("Faces\\Seitz\\Seitz_Shocked_Face");
        public static GUIElement SeitzThoughtfulFace = new GUIElement("Faces\\Seitz\\Seitz_Thoughtful_Face");
        public static GUIElement SeitzHappyFace = new GUIElement("Faces\\Seitz\\Seitz_Happy_Face");

        public static GUIElement SeyfridStandardFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_Standard_Face");
        public static GUIElement SeyfridNotAmusedFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_NotAmused_Face");
        public static GUIElement SeyfridProvokeFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_Provoke_Face");
        public static GUIElement SeyfridShockedFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_Shocked_Face");
        public static GUIElement SeyfridThoughtfulFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_Thoughtful_Face");
        public static GUIElement SeyfridHappyFace = new GUIElement("Faces\\Seyfrid\\Seyfrid_Happy_Face");

        public static GUIElement IreneStandardFace = new GUIElement("Faces\\Irene\\Irene_Standard_Face");
        public static GUIElement MichaelStandardFace = new GUIElement("Faces\\Michael\\Michael_Standard_Face");
        public static GUIElement ReinhardtStandardFace = new GUIElement("Faces\\Reinhardt\\Reinhardt_Standard_Face");

        private static int characterSize = 64;
        private static int animationSpeed = 300;

        public static List<GUIElement> StandardFaces = new List<GUIElement>();
        public static void LoadContent(ContentManager content)
        {
            AwesomeFont = content.Load<SpriteFont>("Fonts\\AwesomeFont");

            //Friendly
            //Female Animations
            AnnaStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Anna\\Anna_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            AnnaAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Anna\\Anna_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            AnnaDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Anna\\Anna_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            ElenaStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Elena\\Elena_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            ElenaAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Elena\\Elena_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            ElenaDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Elena\\Elena_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EllsStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Ells\\Ells_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            EllsAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Ells\\Ells_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            EllsDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Ells\\Ells_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            GenefeStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Genefe\\Genefe_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            GenefeAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Genefe\\Genefe_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            GenefeDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Genefe\\Genefe_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            MarleinStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Marlein\\Marlein_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            MarleinAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Marlein\\Marlein_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            MarleinDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Female\\Marlein\\Marlein_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);


            //Male Animations
            CasparStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Caspar\\Caspar_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            CasparAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Caspar\\Caspar_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            CasparDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Caspar\\Caspar_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            JosStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Jos\\Jos_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            JosAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Jos\\Jos_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            JosDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Jos\\jos_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            KaiserStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Kaiser\\Kaiser_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            KaiserAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Kaiser\\Kaiser_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            KaiserDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Kaiser\\Kaiser_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            NickStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Nick\\Nick_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            NickAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Nick\\Nick_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            NickDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Nick\\Nick_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            SeitzStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seitz\\Seitz_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            SeitzAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seitz\\Seitz_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            SeitzDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seitz\\Seitz_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            SeyfridStandardAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seyfrid\\Seyfrid_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 1, 3, false, false);
            SeyfridAttackAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seyfrid\\Seyfrid_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 1, 6, false, false);
            SeyfridDeathAnimation.LoadContent(content.Load<Texture2D>("Animations\\Battlers\\Male\\Seyfrid\\Seyfrid_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);


            //Animated Enemies

            //Female
            EnemyAnnaStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Anna\\Anna_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyAnnaAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Anna\\Anna_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyAnnaDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Anna\\Anna_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyElenaStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Elena\\Elena_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyElenaAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Elena\\Elena_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyElenaDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Elena\\Elena_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyEllsStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Ells\\Ells_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyEllsAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Ells\\Ells_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyEllsDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Ells\\Ells_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyIreneStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Irene\\Irene_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyIreneAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Irene\\Irene_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyIreneDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Irene\\Irene_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyMarleinStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Marlein\\Marlein_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyMarleinAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Marlein\\Marlein_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyMarleinDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Marlein\\Marlein_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            //Male
            EnemyKaiserStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Kaiser\\Kaiser_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyKaiserAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Kaiser\\Kaiser_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyKaiserDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Kaiser\\Kaiser_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyMichaelStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Michael\\Michael_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyMichaelAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Michael\\Michael_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyMichaelDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Michael\\Michael_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            EnemyReinhardtStandardAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Reinhardt\\Reinhardt_Standard_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 0, 2, true, false);
            EnemyReinhardtAttackAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Reinhardt\\Reinhardt_Attack_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, false, 0, 5, true, false);
            EnemyReinhardtDeathAnimation.LoadContent(content.Load<Texture2D>("Enemies\\Bosse\\Human\\Reinhardt\\Reinhardt_Death_Animation"), Vector2.Zero, characterSize, characterSize, animationSpeed, Color.White, 1f, true, 6, 1, false, true);

            //Faces
            AnnaStandardFace.LoadContent(content);
            AnnaNotAmusedFace.LoadContent(content);
            AnnaProvokeFace.LoadContent(content);
            AnnaShockedFace.LoadContent(content);
            AnnaThoughtfulFace.LoadContent(content);
            AnnaHappyFace.LoadContent(content);
            AnnaCryFace.LoadContent(content);

            GenefeStandardFace.LoadContent(content);
            GenefeNotAmusedFace.LoadContent(content);
            GenefeProvokeFace.LoadContent(content);
            GenefeShockedFace.LoadContent(content);
            GenefeThoughtfulFace.LoadContent(content);
            GenefeHappyFace.LoadContent(content);
            GenefeCryFace.LoadContent(content);

            MarleinStandardFace.LoadContent(content);
            MarleinNotAmusedFace.LoadContent(content);
            MarleinProvokeFace.LoadContent(content);
            MarleinShockedFace.LoadContent(content);
            MarleinThoughtfulFace.LoadContent(content);
            MarleinHappyFace.LoadContent(content);
            MarleinCryFace.LoadContent(content);

            EllsStandardFace.LoadContent(content);
            EllsNotAmusedFace.LoadContent(content);
            EllsProvokeFace.LoadContent(content);
            EllsShockedFace.LoadContent(content);
            EllsThoughtfulFace.LoadContent(content);
            EllsHappyFace.LoadContent(content);
            EllsCryFace.LoadContent(content);

            ElenaStandardFace.LoadContent(content);
            ElenaNotAmusedFace.LoadContent(content);
            ElenaProvokeFace.LoadContent(content);
            ElenaShockedFace.LoadContent(content);
            ElenaThoughtfulFace.LoadContent(content);
            ElenaHappyFace.LoadContent(content);

            CasparStandardFace.LoadContent(content);
            CasparNotAmusedFace.LoadContent(content);
            CasparProvokeFace.LoadContent(content);
            CasparShockedFace.LoadContent(content);
            CasparThoughtfulFace.LoadContent(content);
            CasparHappyFace.LoadContent(content);

            JosStandardFace.LoadContent(content);
            JosNotAmusedFace.LoadContent(content);
            JosProvokeFace.LoadContent(content);
            JosShockedFace.LoadContent(content);
            JosThoughtfulFace.LoadContent(content);
            JosHappyFace.LoadContent(content);

            KaiserStandardFace.LoadContent(content);
            KaiserNotAmusedFace.LoadContent(content);
            KaiserProvokeFace.LoadContent(content);
            KaiserShockedFace.LoadContent(content);
            KaiserThoughtfulFace.LoadContent(content);
            KaiserHappyFace.LoadContent(content);

            NickStandardFace.LoadContent(content);
            NickNotAmusedFace.LoadContent(content);
            NickProvokeFace.LoadContent(content);
            NickShockedFace.LoadContent(content);
            NickThoughtfulFace.LoadContent(content);
            NickHappyFace.LoadContent(content);

            SeitzStandardFace.LoadContent(content);
            SeitzNotAmusedFace.LoadContent(content);
            SeitzProvokeFace.LoadContent(content);
            SeitzShockedFace.LoadContent(content);
            SeitzThoughtfulFace.LoadContent(content);
            SeitzHappyFace.LoadContent(content);

            SeyfridStandardFace.LoadContent(content);
            SeyfridNotAmusedFace.LoadContent(content);
            SeyfridProvokeFace.LoadContent(content);
            SeyfridShockedFace.LoadContent(content);
            SeyfridThoughtfulFace.LoadContent(content);
            SeyfridHappyFace.LoadContent(content);

            IreneStandardFace.LoadContent(content);
            MichaelStandardFace.LoadContent(content);
            ReinhardtStandardFace.LoadContent(content);

            StandardFaces.Add(AnnaStandardFace);
            StandardFaces.Add(ElenaStandardFace);
            StandardFaces.Add(EllsStandardFace);
            StandardFaces.Add(GenefeStandardFace);
            StandardFaces.Add(MarleinStandardFace);
            StandardFaces.Add(CasparStandardFace);
            StandardFaces.Add(JosStandardFace);
            StandardFaces.Add(KaiserStandardFace);
            StandardFaces.Add(NickStandardFace);
            StandardFaces.Add(SeitzStandardFace);
            StandardFaces.Add(SeyfridStandardFace);
        }
    }
}
