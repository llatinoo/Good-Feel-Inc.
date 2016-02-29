using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using RPG.Characters;
using RPG.Screen_Manager;

namespace RPG.Events
{
    class ChooseCadreEvent
    {
        //Listen des FightCadres und der Gruppe
        List<PartyMember> fightCadre = new List<PartyMember>();
        public List<PartyMember> Fightcadre
        {
            get { return this.fightCadre; }
        }
        List<PartyMember> Group = new List<PartyMember>();

        //Liste der Faces
        List<GUIElement> Faces = new List<GUIElement>();

        //Position der Face Bilder
        Vector2 FacePosition_1 = new Vector2();
        Vector2 FacePosition_2 = new Vector2();
        Vector2 FacePosition_3 = new Vector2();
        Vector2 FacePosition_4 = new Vector2();
        Vector2 FacePosition_5 = new Vector2();
        Vector2 FacePosition_6 = new Vector2();
        Vector2 FacePosition_7 = new Vector2();
        Vector2 FacePosition_8 = new Vector2();
        Vector2 FacePosition_9 = new Vector2();
        Vector2 FacePosition_10 = new Vector2();
        Vector2 FacePosition_11 = new Vector2();
        Vector2 FacePosition_12 = new Vector2();
        Vector2 FacePosition_13 = new Vector2();
        Vector2 FacePosition_14 = new Vector2();

        //GUIElemente die die Face Bilder darstellen
        GUIElement Face_1;
        GUIElement Face_2;
        GUIElement Face_3;
        GUIElement Face_4;
        GUIElement Face_5;
        GUIElement Face_6;
        GUIElement Face_7;
        GUIElement Face_8;
        GUIElement Face_9;
        GUIElement Face_10;
        GUIElement Face_11;
        GUIElement Face_12;
        GUIElement Face_13;
        GUIElement Face_14;
        public ChooseCadreEvent(List<PartyMember> Group, List<PartyMember> FightCadre)
        {
            this.Group = Group;
            this.fightCadre = FightCadre;

            FightCadre.Clear();
        }

        public void LoadContent(ContentManager content)
        {
            int CountMember = 0;
            foreach(PartyMember groupMember in this.Group)
            {
                if (CountMember == 0)
                {
                    this.Face_1 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_1.X, (int) this.FacePosition_1.Y);
                    this.Faces.Add(this.Face_1);
                }
                if (CountMember == 1)
                {
                    this.Face_2 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_2.X, (int) this.FacePosition_2.Y);
                    this.Faces.Add(this.Face_2);
                }
                if (CountMember == 2)
                {
                    this.Face_3 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_3.X, (int) this.FacePosition_3.Y);
                    this.Faces.Add(this.Face_3);
                }
                if (CountMember == 3)
                {
                    this.Face_4 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_4.X, (int) this.FacePosition_4.Y);
                    this.Faces.Add(this.Face_4);
                }
                if (CountMember == 4)
                {
                    this.Face_5 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_5.X, (int) this.FacePosition_5.Y);
                    this.Faces.Add(this.Face_5);
                }
                if (CountMember == 5)
                {
                    this.Face_6 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_6.X, (int) this.FacePosition_6.Y);
                    this.Faces.Add(this.Face_6);
                }
                if (CountMember == 6)
                {
                    this.Face_7 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_7.X, (int) this.FacePosition_7.Y);
                    this.Faces.Add(this.Face_7);
                }
                if (CountMember == 7)
                {
                    this.Face_8 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_8.X, (int) this.FacePosition_8.Y);
                    this.Faces.Add(this.Face_8);
                }
                if (CountMember == 8)
                {
                    this.Face_9 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_9.X, (int) this.FacePosition_9.Y);
                    this.Faces.Add(this.Face_9);
                }
                if (CountMember == 9)
                {
                    this.Face_10 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_10.X, (int) this.FacePosition_10.Y);
                    this.Faces.Add(this.Face_10);
                }
                if (CountMember == 10)
                {
                    this.Face_11 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_11.X, (int) this.FacePosition_11.Y);
                    this.Faces.Add(this.Face_11);
                }
                if (CountMember == 11)
                {
                    this.Face_12 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_12.X, (int) this.FacePosition_12.Y);
                    this.Faces.Add(this.Face_12);
                }
                if (CountMember == 12)
                {
                    this.Face_13 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_13.X, (int) this.FacePosition_13.Y);
                    this.Faces.Add(this.Face_13);
                }
                if (CountMember == 13)
                {
                    this.Face_14 = new GUIElement("Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face", (int) this.FacePosition_14.X, (int) this.FacePosition_14.Y);
                    this.Faces.Add(this.Face_14);
                }
                CountMember++;
            }
            foreach(GUIElement face in this.Faces)
            {
                face.LoadContent(content);
                face.clickEvent += this.OnClick;
            }
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GUIElement face in this.Faces)
            {
                face.Draw(spriteBatch);
            }
            foreach(PartyMember member in this.fightCadre)
            {
                foreach (GUIElement face in this.Faces)
                {
                    if(face.AssetName.Contains(member.Name))
                    {
                        face.changeColor(Color.DarkBlue);
                    }
                }
            }
        }
        public void OnClick(String element)
        {
            foreach (PartyMember groupMember in this.Group)
            {
                if (element == "Faces\\" + groupMember.Name + "\\" + groupMember.Name + "_Standard_Face")
                {
                    if(this.fightCadre.Contains<PartyMember>(groupMember))
                    {
                        this.fightCadre.RemoveAt(this.fightCadre.IndexOf(groupMember));
                        foreach(GUIElement face in this.Faces)
                        {
                            if(face.AssetName.Contains(groupMember.Name))
                            {
                                face.changeColor(Color.White);
                            }
                        }
                    }
                    else if (this.fightCadre.Count < 3)
                    {
                        this.fightCadre.Add(groupMember);
                    }
                }
            }
        }
    }
}
