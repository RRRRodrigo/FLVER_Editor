﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI;
using System.Web.Script.Serialization;


using SoulsFormats;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Numerics;
using Microsoft.Xna.Framework.Graphics;

namespace MySFformat
{
    static class Program
    {
        public static FLVER targetFlver;
        public static string flverName;
        public static List<TextBox> tList;
        public static List<TextBox> parentList;
        public static List<TextBox> childList;
        public static Mono3D mono;

        public static Vector3 checkingPoint;
        public static Boolean useCheckingPoint = false;

        public static string[] argments = { };
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1());*/
            argments = args;

            Console.WriteLine("Hello!");
            ModelAdjModule();
        }

        public static void updateVertices()
        {
            List<VertexPositionColor> ans = new List<VertexPositionColor>();

            for (int i = 0; i < targetFlver.Meshes.Count; i++)
            {
               // int currentV = 0;
                //Microsoft.Xna.Framework.Vector3[] vl = new Microsoft.Xna.Framework.Vector3[3];

                foreach (FLVER.Vertex v in targetFlver.Meshes[i].Vertices)
                {
                    /* if(v.Positions.Count >= 3)
                     {
                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[0].X, v.Positions[0].Y, v.Positions[0].Z), Microsoft.Xna.Framework.Color.Black));
                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[1].X, v.Positions[1].Y, v.Positions[1].Z), Microsoft.Xna.Framework.Color.Black));

                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[0].X, v.Positions[0].Y, v.Positions[0].Z), Microsoft.Xna.Framework.Color.Black));
                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[2].X, v.Positions[2].Y, v.Positions[2].Z), Microsoft.Xna.Framework.Color.Black));

                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[1].X, v.Positions[1].Y, v.Positions[1].Z), Microsoft.Xna.Framework.Color.Black));
                         ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[2].X, v.Positions[2].Y, v.Positions[2].Z), Microsoft.Xna.Framework.Color.Black));
                     }*/
                    for (int j = 0; j < v.Positions.Count; j++)
                    {
                        ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(v.Positions[j].X, v.Positions[j].Z, v.Positions[j].Y), Microsoft.Xna.Framework.Color.Black));

                       /* vl[currentV] = new Microsoft.Xna.Framework.Vector3(v.Positions[j].X, v.Positions[j].Z, v.Positions[j].Y);
                        currentV++;
                        if (currentV == 3)
                        {
                            ans.Add(new VertexPositionColor(vl[0], Microsoft.Xna.Framework.Color.Black));
                            ans.Add(new VertexPositionColor(vl[1], Microsoft.Xna.Framework.Color.Black));
                            ans.Add(new VertexPositionColor(vl[0], Microsoft.Xna.Framework.Color.Black));
                            ans.Add(new VertexPositionColor(vl[2], Microsoft.Xna.Framework.Color.Black));
                            ans.Add(new VertexPositionColor(vl[1], Microsoft.Xna.Framework.Color.Black));
                            ans.Add(new VertexPositionColor(vl[2], Microsoft.Xna.Framework.Color.Black));
                            currentV = 0;
                        }*/
                    }
                }
            }
            if (ans.Count % 2 != 0)
            {
                ans.Add(ans[ans.Count -1]);
            }

            /*for (int i = 0; i < targetFlver.Bones.Count; i++)
            {
                //targetFlver.Bones[i].Translation
                Vector3 actPos = findBoneTrans(targetFlver.Bones,i,new Vector3());
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X - 0.025f, actPos.Z, actPos.Y), Microsoft.Xna.Framework.Color.Purple));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X + 0.025f, actPos.Z, actPos.Y), Microsoft.Xna.Framework.Color.Purple));

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X , actPos.Z - 0.025f, actPos.Y), Microsoft.Xna.Framework.Color.Purple));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X , actPos.Z + 0.025f, actPos.Y), Microsoft.Xna.Framework.Color.Purple));

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X , actPos.Z, actPos.Y - 0.025f), Microsoft.Xna.Framework.Color.Purple));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(actPos.X , actPos.Z, actPos.Y + 0.025f), Microsoft.Xna.Framework.Color.Purple));
            }*/
            for (int i = 0; i < targetFlver.Dummies.Count; i++)
            {
                FLVER.Dummy d = targetFlver.Dummies[i];

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X -0.025f, d.Position.Z, d.Position.Y), Microsoft.Xna.Framework.Color.Purple));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X + 0.025f, d.Position.Z, d.Position.Y), Microsoft.Xna.Framework.Color.Purple));

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X , d.Position.Z - 0.025f, d.Position.Y), Microsoft.Xna.Framework.Color.Purple));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X , d.Position.Z + 0.025f, d.Position.Y), Microsoft.Xna.Framework.Color.Purple));

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X, d.Position.Z, d.Position.Y), Microsoft.Xna.Framework.Color.Green));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(d.Position.X + d.Forward.X, d.Position.Z + d.Forward.Z, d.Position.Y + d.Forward.Y), Microsoft.Xna.Framework.Color.Green));

            }

            if (useCheckingPoint)
            {
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(checkingPoint.X - 0.05f, checkingPoint.Z - 0.05f, checkingPoint.Y), Microsoft.Xna.Framework.Color.AntiqueWhite));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(checkingPoint.X + 0.05f, checkingPoint.Z + 0.05f, checkingPoint.Y), Microsoft.Xna.Framework.Color.AntiqueWhite));

                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(checkingPoint.X - 0.05f, checkingPoint.Z + 0.05f, checkingPoint.Y), Microsoft.Xna.Framework.Color.AntiqueWhite));
                ans.Add(new VertexPositionColor(new Microsoft.Xna.Framework.Vector3(checkingPoint.X + 0.05f, checkingPoint.Z - 0.05f, checkingPoint.Y), Microsoft.Xna.Framework.Color.AntiqueWhite));

                useCheckingPoint = false;
            }
            mono.vertices = ans.ToArray();
        }

       

        public static Vector3 findBoneTrans(List<FLVER.Bone> b,int index,Vector3 v)
        {
            if (b[index].ParentIndex == -1)
            {
                v += b[index].Translation;
                return v;
            }
            return findBoneTrans(b, b[index].ParentIndex,v);
        }

        static void ModelAdjModule()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog1.Title = "Choose template seikiro model file. by Forsaknsilver";
            //openFileDialog1.ShowDialog();

            
            if (argments.Length > 0)
            {
                openFileDialog1.FileName = argments[0];

            }
            else 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
                //openFileDialog1.
            }
            else
            {
               /* Mono3D mono = new Mono3D();
                mono.Run();*/
                return;
            }

          

            FLVER b = FLVER.Read(openFileDialog1.FileName);



            targetFlver = b;
           
            new System.Threading.Thread(() =>
            {
                System.Threading.Thread.CurrentThread.IsBackground = true;
                mono = new Mono3D();
                updateVertices();
                mono.Run();
                
            }).Start();
           


            flverName = openFileDialog1.FileName;

            Form f = new Form();
            f.Text = "FLVER Bones - " + openFileDialog1.FileName;
            Panel p = new Panel();
            int sizeY = 50;
            int currentY = 10;
            tList = new List<TextBox>();
            parentList = new List<TextBox>();
            childList = new List<TextBox>();
            //p.AutoSize = true;
            p.AutoScroll = true;
            f.Controls.Add(p);


            {
                Label l = new Label();
                l.Text = "index";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "name";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(70, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "parent";
                l.Size = new System.Drawing.Size(90, 15);
                l.Location = new System.Drawing.Point(270, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "child";
                l.Size = new System.Drawing.Size(90, 15);
                l.Location = new System.Drawing.Point(370, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "position";
                l.Size = new System.Drawing.Size(90, 15);
                l.Location = new System.Drawing.Point(410, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "scale";
                l.Size = new System.Drawing.Size(70, 15);
                l.Location = new System.Drawing.Point(500, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "rotation";
                l.Size = new System.Drawing.Size(70, 15);
                l.Location = new System.Drawing.Point(590, currentY + 5);
                p.Controls.Add(l);
            }
            currentY += 20;

            for (int i = 0; i < b.Bones.Count; i++)
               
            {
                // foreach (FLVER.Bone bn in b.Bones)
                FLVER.Bone bn = b.Bones[i];
                Console.WriteLine(bn.Name);

                TextBox t = new TextBox();
                t.Size = new System.Drawing.Size(200,15);
                t.Location = new System.Drawing.Point(70,currentY);
                t.Text = bn.Name;
                p.Controls.Add(t);

                Label l = new Label();
                l.Text = "["+i + "]";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY+5);
                p.Controls.Add(l);

                TextBox t2 = new TextBox();
                t2.Size = new System.Drawing.Size(70, 15);
                t2.Location = new System.Drawing.Point(270, currentY);
                t2.Text = bn.ParentIndex + "";
                p.Controls.Add(t2);

                TextBox t3 = new TextBox();
                t3.Size = new System.Drawing.Size(70, 15);
                t3.Location = new System.Drawing.Point(340, currentY);
                t3.Text = bn.ChildIndex + "";
                p.Controls.Add(t3);

                //bn.Translation
                TextBox t4 = new TextBox();
                t4.Size = new System.Drawing.Size(90, 15);
                t4.Location = new System.Drawing.Point(410, currentY);
                t4.Text = bn.Translation.X + "," + bn.Translation.Y +"," + bn.Translation.Z ;
                p.Controls.Add(t4);

                TextBox t5 = new TextBox();
                t5.Size = new System.Drawing.Size(90, 15);
                t5.Location = new System.Drawing.Point(500, currentY);
                t5.Text = bn.Scale.X + "," + bn.Scale.Y + "," + bn.Scale.Z;
                p.Controls.Add(t5);

                TextBox t6 = new TextBox();
                t6.Size = new System.Drawing.Size(90, 15);
                t6.Location = new System.Drawing.Point(590, currentY);
                t6.Text = bn.Rotation.X + "," + bn.Rotation.Y + "," + bn.Rotation.Z;
                p.Controls.Add(t6);
                
                currentY += 20;
                sizeY += 20;
                tList.Add(t);
                parentList.Add(t2);
                childList.Add(t3);
            }
            
            f.Size = new System.Drawing.Size(550,600);
            p.Size = new System.Drawing.Size(400, 530);
            //f.Show();

            Button button = new Button();
            button.Text = "Modify";
            button.Location = new System.Drawing.Point(450, 50);
            button.Click += (s, e) => {
                for (int i =0;i < b.Bones.Count;i++)
                {
                    b.Bones[i].Name = tList[i].Text;
                    b.Bones[i].ParentIndex = short.Parse(parentList[i].Text);
                    b.Bones[i].ChildIndex = short.Parse(childList[i].Text);
                }
                targetFlver.Write(flverName);
            };

            var serializer = new JavaScriptSerializer();
            string serializedResult = serializer.Serialize(b.Bones);


            TextBox tbones = new TextBox();
            tbones.Multiline = true;
            tbones.Size = new System.Drawing.Size(670, 600);
            tbones.Location = new System.Drawing.Point(10, currentY+20);
            tbones.Text = serializedResult;

            p.Controls.Add(tbones);

            currentY += 620;

            TextBox tbones2 = new TextBox();
            tbones2.Multiline = true;
            tbones2.Size = new System.Drawing.Size(670, 300);
            tbones2.Location = new System.Drawing.Point(10, currentY + 20);
            serializedResult = serializer.Serialize(b.Header);
            tbones2.Text = serializedResult;

            p.Controls.Add(tbones2);


            Button button2 = new Button();
            button2.Text = "Material";
            button2.Location = new System.Drawing.Point(450, 100);
            button2.Click += (s, e) => {
                ModelMaterial();
            };

            Button button3 = new Button();
            button3.Text = "Mesh";
            button3.Location = new System.Drawing.Point(450, 150);
            button3.Click += (s, e) => {
                ModelMesh();
            };
            Button button4 = new Button();
            button4.Text = "Swap";
            button4.Location = new System.Drawing.Point(450, 200);
            button4.Click += (s, e) => {
                ModelSwapModule();
            };

            Button button_dummy = new Button();
            button_dummy.Text = "Dummy";
            button_dummy.Location = new System.Drawing.Point(450, 250);
            button_dummy.Click += (s, e) => {
                dummies();
            };


            Button button5 = new Button();
           
            button5.Text = "SaveJson";
            button5.Location = new System.Drawing.Point(450, 300);
            button5.Click += (s, e) => {
               b.Bones = serializer.Deserialize<List<FLVER.Bone>>(tbones.Text);
                b.Header = serializer.Deserialize<FLVER.FLVERHeader>(tbones2.Text);
                targetFlver.Write(flverName);
                MessageBox.Show("Json bone change completed! Please exit the program!", "Info");
            };


            Button button6 = new Button();

            button6.Text = "LoadJson";
            button6.Location = new System.Drawing.Point(450, 350);
            button6.Click += (s, e) => {

                var openFileDialog2 = new OpenFileDialog();
                string res = "";
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sr = new StreamReader(openFileDialog2.FileName);
                        res = sr.ReadToEnd();
                        sr.Close();
                        targetFlver.Bones = serializer.Deserialize<List<FLVER.Bone>>(res);
                        targetFlver.Write(flverName);
                        MessageBox.Show("Bone change completed! Please exit the program!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }

                
            };




            f.Resize += (s, e) =>
            {
                p.Size = new System.Drawing.Size(f.Size.Width - 150, f.Size.Height - 70);
                button.Location = new System.Drawing.Point(f.Size.Width - 100, 50);
                button2.Location = new System.Drawing.Point(f.Size.Width - 100, 100);
                button3.Location = new System.Drawing.Point(f.Size.Width - 100, 150);
                button4.Location = new System.Drawing.Point(f.Size.Width - 100, 200);
                button_dummy.Location = new System.Drawing.Point(f.Size.Width - 100, 250);
                button5.Location = new System.Drawing.Point(f.Size.Width - 100, 300);
                button6.Location = new System.Drawing.Point(f.Size.Width - 100, 350);
            };

           

            f.Controls.Add(button);
            f.Controls.Add(button2);
            f.Controls.Add(button3);
            f.Controls.Add(button4);
            f.Controls.Add(button_dummy);
            f.Controls.Add(button5);
            f.Controls.Add(button6);
            Application.Run(f);
            
           
            //ModelMaterial();
            //Application.Exit();
        }

        static void dummies()
        {
            Form f = new Form();
            f.Text = "Dummies";
            Panel p = new Panel();
            int currentY2 = 10;
            p.AutoScroll = true;
          

            f.Controls.Add(p);
            {
                Label l = new Label();
                l.Text = "Choose # to translate:";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(10, currentY2 + 5);
                p.Controls.Add(l);
            }
            currentY2 += 20;

            TextBox t = new TextBox();
            t.Size = new System.Drawing.Size(60, 15);
            t.Location = new System.Drawing.Point(10, currentY2 +5);
            t.Text = "-1";
            p.Controls.Add(t);


            Button buttonCheck = new Button();
            buttonCheck.Text = "Check";
            buttonCheck.Location = new System.Drawing.Point(70, currentY2 + 5);
            buttonCheck.Click += (s, e) => {
                int i = int.Parse(t.Text);
                if (i >= 0 && i < targetFlver.Dummies.Count)
                {

                    useCheckingPoint = true;
                    checkingPoint = new Vector3(targetFlver.Dummies[i].Position.X, targetFlver.Dummies[i].Position.Y, targetFlver.Dummies[i].Position.Z);
                    updateVertices();
                }
                else
                {

                    MessageBox.Show("Invalid modification value!");
                }

            };
            p.Controls.Add(buttonCheck);


            currentY2 += 20;

            TextBox tX = new TextBox();
            tX.Size = new System.Drawing.Size(60, 15);
            tX.Location = new System.Drawing.Point(10, currentY2+5);
            tX.Text = "0";
            p.Controls.Add(tX);


            TextBox tY = new TextBox();
            tY.Size = new System.Drawing.Size(60, 15);
            tY.Location = new System.Drawing.Point(70, currentY2+5);
            tY.Text = "0";
            p.Controls.Add(tY);

            TextBox tZ = new TextBox();
            tZ.Size = new System.Drawing.Size(60, 15);
            tZ.Location = new System.Drawing.Point(130, currentY2+5);
            tZ.Text = "0";
            p.Controls.Add(tZ);


            currentY2 += 20;


            var serializer = new JavaScriptSerializer();
            string serializedResult = serializer.Serialize(targetFlver.Dummies);


            TextBox tbones = new TextBox();
            tbones.Multiline = true;
            tbones.Size = new System.Drawing.Size(670, 600);
            tbones.Location = new System.Drawing.Point(10, currentY2 + 20);
            tbones.Text = serializedResult;

            p.Controls.Add(tbones);

            Button button = new Button();
            button.Text = "Modify";
            button.Location = new System.Drawing.Point(650, 50);
            button.Click += (s, e) => {
                int i = int.Parse(t.Text);
                if (i >= 0 && i < targetFlver.Dummies.Count)
                {

                    targetFlver.Dummies[i].Position.X += float.Parse(tX.Text);
                    targetFlver.Dummies[i].Position.Y += float.Parse(tY.Text);
                    targetFlver.Dummies[i].Position.Z += float.Parse(tZ.Text);
                    targetFlver.Write(flverName);
                    updateVertices();
                }
                else {

                    MessageBox.Show("Invalid modification value!");
                }
                
            };


            Button button2 = new Button();

            button2.Text = "JsonMod";
            button2.Location = new System.Drawing.Point(650, 100);
            button2.Click += (s, e) => {
                targetFlver.Dummies = serializer.Deserialize<List<FLVER.Dummy>>(tbones.Text);
                targetFlver.Write(flverName);
                updateVertices();
                MessageBox.Show("Dummy change completed! Please exit the program!", "Info");
            };

            Button button3 = new Button();

            button3.Text = "LoadJson";
            button3.Location = new System.Drawing.Point(650, 150);
            button3.Click += (s, e) => {

                var openFileDialog1 = new OpenFileDialog();
                string res = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sr = new StreamReader(openFileDialog1.FileName);
                        res = sr.ReadToEnd();
                        sr.Close();
                        targetFlver.Dummies = serializer.Deserialize<List<FLVER.Dummy>>(res);
                        targetFlver.Write(flverName);
                        updateVertices();
                        MessageBox.Show("Dummy change completed! Please exit the program!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }


            };

            f.Size = new System.Drawing.Size(750, 600);
            p.Size = new System.Drawing.Size(600, 530);
            f.Resize += (s, e) =>
            {
                p.Size = new System.Drawing.Size(f.Size.Width - 150, f.Size.Height - 70);
                button.Location = new System.Drawing.Point(f.Size.Width - 100, 50);
                button2.Location = new System.Drawing.Point(f.Size.Width - 100, 100);
                button3.Location = new System.Drawing.Point(f.Size.Width - 100, 150);
            };

            f.Controls.Add(button);
            f.Controls.Add(button2);
            f.Controls.Add(button3);
            f.ShowDialog();
        }

        static void ModelMaterial() {

            Form f = new Form();
            f.Text = "Material";
            Panel p = new Panel();
            int sizeY = 50;
            int currentY = 10;
            tList = new List<TextBox>();
            parentList = new List<TextBox>();
            childList = new List<TextBox>();
            //p.AutoSize = true;
            p.AutoScroll = true;
            f.Controls.Add(p);


            {
                Label l = new Label();
                l.Text = "index";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "name";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(70, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "type";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(270, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "texture path";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(340, currentY + 5);
                p.Controls.Add(l);
            }
            currentY += 20;

            
            for (int i = 0; i < targetFlver.Materials.Count; i++)

            {
                // foreach (FLVER.Bone bn in b.Bones)
                FLVER.Material bn = targetFlver.Materials[i];
                Console.WriteLine(bn.Name);

                TextBox t = new TextBox();
                t.Size = new System.Drawing.Size(200, 15);
                t.Location = new System.Drawing.Point(70, currentY);
                t.Text = bn.Name;
                p.Controls.Add(t);

                Label l = new Label();
                l.Text = "[" + i + "]";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY + 5);
                p.Controls.Add(l);

                TextBox t2 = new TextBox();
                t2.Size = new System.Drawing.Size(70, 15);
                t2.Location = new System.Drawing.Point(270, currentY);
                t2.Text =bn.Flags + ",GX" + bn.GXBytes + ",Unk" + bn.Unk18;
                p.Controls.Add(t2);

                TextBox t3 = new TextBox();
                t3.Size = new System.Drawing.Size(770, 15);
                t3.Location = new System.Drawing.Point(340, currentY);
                string allMat = "";
                foreach (FLVER.Texture tex in bn.Textures)
                {
                   /* if (tex.Type == "g_DiffuseTexture")
                    {
                        tex.Type = "Character_AMSN_snp_Texture2D_2_AlbedoMap_0";
                    }
                    if (tex.Type == "g_BumpmapTexture")
                    {
                        tex.Type = "Character_AMSN_snp_Texture2D_7_NormalMap_4";
                    }
                    if (tex.Type == "g_SpecularTexture")
                    {
                        tex.Type = "Character_AMSN_snp_Texture2D_0_ReflectanceMap_0";
                    }
                    if (tex.Type == "g_ShininessTexture")
                    {
                        tex.Type = "Character_AMSN_snp_Texture2D_0_ReflectanceMap_0";
                    }*/

                    allMat += "{" + tex.Type + "->" + tex.Path + "," + tex.Unk10 + "," +tex.Unk11 + "," + tex.Unk14 + "," + tex.Unk18 + "," + tex.Unk1C + "}";
                }
                t3.Text = allMat;
                p.Controls.Add(t3);

                currentY += 20;
                sizeY += 20;
                /*tList.Add(t);
                parentList.Add(t2);
                childList.Add(t3);*/
            }
         
          /*  var xmlserializer = new XmlSerializer(typeof( List<FLVER.Material>));
            var stringWriter = new StringWriter();
            string res;
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, targetFlver.Materials);
              res = stringWriter.ToString();
            }*/


           var serializer = new JavaScriptSerializer();
            string serializedResult = serializer.Serialize(targetFlver.Materials);


            TextBox tbones = new TextBox();
            tbones.Multiline = true;
            tbones.Size = new System.Drawing.Size(670, 600);
            tbones.Location = new System.Drawing.Point(10, currentY + 20);
            tbones.Text = serializedResult;

            p.Controls.Add(tbones);

            Button button = new Button();
            button.Text = "Modify";
            button.Location = new System.Drawing.Point(650, 50);
            button.Click += (s, e) => {
              /*  for (int i = 0; i < b.Bones.Count; i++)
                {
                    b.Bones[i].Name = tList[i].Text;
                    b.Bones[i].ParentIndex = short.Parse(parentList[i].Text);
                    b.Bones[i].ChildIndex = short.Parse(childList[i].Text);
                }*/
                targetFlver.Write(flverName);
            };


            Button button2 = new Button();

            button2.Text = "SaveJson";
            button2.Location = new System.Drawing.Point(650, 100);
            button2.Click += (s, e) => {
                targetFlver.Materials = serializer.Deserialize<List<FLVER.Material>>(tbones.Text);
                targetFlver.Write(flverName);
                MessageBox.Show("Material change completed! Please exit the program!", "Info");
            };

            Button button3 = new Button();

            button3.Text = "LoadJson";
            button3.Location = new System.Drawing.Point(650, 150);
            button3.Click += (s, e) => {

                var openFileDialog1 = new OpenFileDialog();
                string res = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sr = new StreamReader(openFileDialog1.FileName);
                        res =sr.ReadToEnd();
                        sr.Close();
                        targetFlver.Materials = serializer.Deserialize<List<FLVER.Material>>(res);
                        targetFlver.Write(flverName);
                        MessageBox.Show("Material change completed! Please exit the program!", "Info");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                        $"Details:\n\n{ex.StackTrace}");
                    }
                }

               
            };

            f.Size = new System.Drawing.Size(750, 600);
            p.Size = new System.Drawing.Size(600, 530);
            f.Resize += (s, e) =>
                {
                    p.Size = new System.Drawing.Size(f.Size.Width - 150, f.Size.Height - 70);
                    button.Location = new System.Drawing.Point(f.Size.Width - 100, 50);
                    button2.Location = new System.Drawing.Point(f.Size.Width - 100, 100);
                    button3.Location = new System.Drawing.Point(f.Size.Width - 100, 150);
                };

            f.Controls.Add(button);
            f.Controls.Add(button2);
            f.Controls.Add(button3);
            f.ShowDialog();
            //Application.Run(f);

            

        }


        static void ModelMesh()
        {

            Form f = new Form();
            f.Text = "Mesh";
            Panel p = new Panel();
            int sizeY = 50;
            int currentY = 10;
            tList = new List<TextBox>();
            parentList = new List<TextBox>();
            childList = new List<TextBox>();
            //p.AutoSize = true;
            p.AutoScroll = true;
            f.Controls.Add(p);



            {
                Label l = new Label();
                l.Text = "index";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "name";
                l.Size = new System.Drawing.Size(150, 15);
                l.Location = new System.Drawing.Point(70, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "kill it?";
                l.Size = new System.Drawing.Size(70, 15);
                l.Location = new System.Drawing.Point(270, currentY + 5);
                p.Controls.Add(l);
            }
            {
                Label l = new Label();
                l.Text = "Force bone weight to";
                l.Size = new System.Drawing.Size(200, 15);
                l.Location = new System.Drawing.Point(340, currentY + 5);
                p.Controls.Add(l);
            }
            currentY += 20;

            List<CheckBox> cbList = new List<CheckBox>();
            List<TextBox> tbList = new List<TextBox>();

            for (int i = 0; i < targetFlver.Meshes.Count; i++)

            {
                // foreach (FLVER.Bone bn in b.Bones)
                FLVER.Mesh bn = targetFlver.Meshes[i];
                Console.WriteLine(bn.MaterialIndex);

                TextBox t = new TextBox();
                t.Size = new System.Drawing.Size(200, 15);
                t.Location = new System.Drawing.Point(70, currentY);
                
                t.Text = "[M:"+targetFlver.Materials[bn.MaterialIndex].Name + "]";
                p.Controls.Add(t);

                Label l = new Label();
                l.Text = "[" + i + "]";
                l.Size = new System.Drawing.Size(50, 15);
                l.Location = new System.Drawing.Point(10, currentY + 5);
                p.Controls.Add(l);

                CheckBox cb = new CheckBox();
                cb.Checked = false;
                cb.Size = new System.Drawing.Size(70, 15);
                cb.Location = new System.Drawing.Point(270, currentY);
                p.Controls.Add(cb);
                cbList.Add(cb);

                TextBox t2 = new TextBox();
                t2.Size = new System.Drawing.Size(70, 15);
                t2.Location = new System.Drawing.Point(340, currentY);
                t2.Text ="-1";
                p.Controls.Add(t2);
                tbList.Add(t2);
                /* TextBox t2 = new TextBox();
                 t2.Size = new System.Drawing.Size(70, 15);
                 t2.Location = new System.Drawing.Point(270, currentY);
                 t2.Text = bn.Flags + ",GX" + bn.GXBytes + ",Unk" + bn.Unk18;
                 p.Controls.Add(t2);

                 TextBox t3 = new TextBox();
                 t3.Size = new System.Drawing.Size(770, 15);
                 t3.Location = new System.Drawing.Point(340, currentY);
                 string allMat = "";
                 foreach (FLVER.Texture tex in bn.Textures)
                 {

                     allMat += "{" + tex.Type + "->" + tex.Path + "," + tex.Unk10 + "," + tex.Unk11 + "," + tex.Unk14 + "," + tex.Unk18 + "," + tex.Unk1C + "}";
                 }
                 t3.Text = allMat;
                 p.Controls.Add(t3);*/

                currentY += 20;
                sizeY += 20;
                /*tList.Add(t);
                parentList.Add(t2);
                childList.Add(t3);*/
            }

            CheckBox rotCb = new CheckBox();
            rotCb.Size = new System.Drawing.Size(60, 15);
            rotCb.Text = "rotation";
            rotCb.Location = new System.Drawing.Point(10, currentY);
            rotCb.Checked = false;
            p.Controls.Add(rotCb);

            TextBox rotX = new TextBox();
            rotX.Size = new System.Drawing.Size(60, 15);
            rotX.Location = new System.Drawing.Point(70, currentY);
            rotX.Text = "0";
            p.Controls.Add(rotX);

            TextBox rotY = new TextBox();
            rotY.Size = new System.Drawing.Size(60, 15);
            rotY.Location = new System.Drawing.Point(130, currentY);
            rotY.Text = "0";
            p.Controls.Add(rotY);

            TextBox rotZ = new TextBox();
            rotZ.Size = new System.Drawing.Size(70, 15);
            rotZ.Location = new System.Drawing.Point(190, currentY);
            rotZ.Text = "0";
            p.Controls.Add(rotZ);

            currentY += 20;

            CheckBox transCb = new CheckBox();
            transCb.Size = new System.Drawing.Size(60, 15);
            transCb.Text = "translation";
            transCb.Location = new System.Drawing.Point(10, currentY);
            transCb.Checked = false;
            p.Controls.Add(transCb);

            TextBox transX = new TextBox();
            transX.Size = new System.Drawing.Size(60, 15);
            transX.Location = new System.Drawing.Point(70, currentY);
            transX.Text = "0";
            p.Controls.Add(transX);

            TextBox transY = new TextBox();
            transY.Size = new System.Drawing.Size(60, 15);
            transY.Location = new System.Drawing.Point(130, currentY);
            transY.Text = "0";
            p.Controls.Add(transY);

            TextBox transZ = new TextBox();
            transZ.Size = new System.Drawing.Size(70, 15);
            transZ.Location = new System.Drawing.Point(190, currentY);
            transZ.Text = "0";
            p.Controls.Add(transZ);

            Button button = new Button();
            button.Text = "Modify";
            button.Location = new System.Drawing.Point(650, 50);
            button.Click += (s, e) => {

                for (int i = 0; i < cbList.Count;i++)
                {
                    if (cbList[i].Checked == true)
                    {
                       
                         foreach (FLVER.Vertex v in targetFlver.Meshes[i].Vertices)
                        {
                        for (int j = 0; j < v.Positions.Count; j++)
                        {
                            v.Positions[j] = new System.Numerics.Vector3(0,0,0);
                            for (int k =0;k < v.BoneWeights.Length;k++)
                            {
                                v.BoneWeights[k] = 0;
                            }
                        }
                        }
                        //targetFlver.Meshes[i].Vertices = new List<FLVER.Vertex>();

                    }
                    int i2 = int.Parse(tbList[i].Text);
                    if (i2 >= 0)
                    {
                        foreach (FLVER.Vertex v in targetFlver.Meshes[i].Vertices)
                        {
                            for (int j = 0; j < v.Positions.Count; j++)
                            {
                                //v.Positions[j] = new System.Numerics.Vector3(0, 0, 0);
                                for (int k = 0; k < v.BoneWeights.Length; k++)
                                {
                                    v.BoneWeights[k] = 0;
                                }
                                v.BoneIndices[0] = i2;
                                v.BoneWeights[0] = 1;
                            }
                        }
                    }

                    if (transCb.Checked)
                    {
                        float x = float.Parse(transX.Text);
                        float y = float.Parse(transY.Text);
                        float z = float.Parse(transZ.Text);
                        foreach (FLVER.Vertex v in targetFlver.Meshes[i].Vertices)
                        {
                            for (int j = 0; j < v.Positions.Count; j++)
                            {
                                v.Positions[j] = new Vector3(v.Positions[j].X + x, v.Positions[j].Y + y, v.Positions[j].Z + z);
                            }

                            
                        }

                    }


                    if (rotCb.Checked)
                    {
                        float roll = float.Parse(rotX.Text);
                        float pitch = float.Parse(rotY.Text);

                        float yaw = float.Parse(rotZ.Text);
                        foreach (FLVER.Vertex v in targetFlver.Meshes[i].Vertices)
                        {
                            for (int j = 0; j < v.Positions.Count; j++)
                            {
                                v.Positions[j] = RotatePoint(v.Positions[j],pitch,roll,yaw);
                            }

                            for (int j2 = 0;j2 < v.Normals.Count;j2++)
                            {
                                v.Normals[j2] = RotatePoint(v.Normals[j2], pitch, roll, yaw);

                            }
                            for (int j2 = 0; j2 < v.Tangents.Count; j2++)
                            {
                               
                                v.Tangents[j2] = RotatePoint(v.Tangents[j2], pitch, roll, yaw);

                            }
                        }

                    }
                }

                targetFlver.Write(flverName);
                updateVertices();
                MessageBox.Show("Modificiation successful!");
            };



            f.Size = new System.Drawing.Size(750, 600);
            p.Size = new System.Drawing.Size(600, 530);
            f.Resize += (s, e) =>
            {
                p.Size = new System.Drawing.Size(f.Size.Width - 150, f.Size.Height - 70);
                button.Location = new System.Drawing.Point(f.Size.Width - 100, 50);
            };


            f.Controls.Add(button);
            f.ShowDialog();
            //Application.Run(f);



        }

        public static Vector3 RotatePoint(Vector3 p, float pitch,float roll,float yaw)
        {

            Vector3 ans = new Vector3(0,0,0);


            var cosa = Math.Cos(yaw);
            var sina = Math.Sin(yaw);

            var cosb = Math.Cos(pitch);
            var sinb = Math.Sin(pitch);

            var cosc = Math.Cos(roll);
            var sinc = Math.Sin(roll);

            var Axx = cosa * cosb;
            var Axy = cosa * sinb * sinc - sina * cosc;
            var Axz = cosa * sinb * cosc + sina * sinc;

            var Ayx = sina * cosb;
            var Ayy = sina * sinb * sinc + cosa * cosc;
            var Ayz = sina * sinb * cosc - cosa * sinc;

            var Azx = -sinb;
            var Azy = cosb * sinc;
            var Azz = cosb * cosc;

            var px = p.X;
            var py = p.Y;
            var pz = p.Z;

            ans.X =  (float)( Axx * px + Axy * py + Axz * pz);
            ans.Y = (float)(Ayx * px + Ayy * py + Ayz * pz);
            ans.Z = (float)(Azx * px + Azy * py + Azz * pz);


            return ans;
        }
        public static Vector4 RotatePoint(Vector4 p, float pitch, float roll, float yaw)
        {

            Vector4 ans = new Vector4(0, 0, 0,p.W);


            var cosa = Math.Cos(yaw);
            var sina = Math.Sin(yaw);

            var cosb = Math.Cos(pitch);
            var sinb = Math.Sin(pitch);

            var cosc = Math.Cos(roll);
            var sinc = Math.Sin(roll);

            var Axx = cosa * cosb;
            var Axy = cosa * sinb * sinc - sina * cosc;
            var Axz = cosa * sinb * cosc + sina * sinc;

            var Ayx = sina * cosb;
            var Ayy = sina * sinb * sinc + cosa * cosc;
            var Ayz = sina * sinb * cosc - cosa * sinc;

            var Azx = -sinb;
            var Azy = cosb * sinc;
            var Azz = cosb * cosc;

            var px = p.X;
            var py = p.Y;
            var pz = p.Z;

            ans.X = (float)(Axx * px + Axy * py + Axz * pz);
            ans.Y = (float)(Ayx * px + Ayy * py + Ayz * pz);
            ans.Z = (float)(Azx * px + Azy * py + Azz * pz);


            return ans;
        }

        public static Vector3 RotateLine(Vector3 p, Vector3 org,Vector3 direction, double theta)
        {
            double x = p.X;
            double y = p.Y;
            double z = p.Z;

            double a = org.X;
            double b = org.Y;
            double c = org.Z;



            double nu = direction.X / direction.Length();
            double nv = direction.Y / direction.Length();
            double nw = direction.Z / direction.Length();

            double[] rP = new double[3];

            rP[0] = (a * (nv * nv + nw * nw) - nu * (b * nv + c * nw - nu * x - nv * y - nw * z)) * (1 - Math.Cos(theta)) + x * Math.Cos(theta) + (-c * nv + b * nw - nw * y + nv * z) * Math.Sin(theta);
            rP[1] = (b * (nu * nu + nw * nw) - nv * (a * nu + c * nw - nu * x - nv * y - nw * z)) * (1 - Math.Cos(theta)) + y * Math.Cos(theta) + (c * nu - a * nw + nw * x - nu * z) * Math.Sin(theta);
            rP[2] = (c * (nu * nu + nv * nv) - nw * (a * nu + b * nv - nu * x - nv * y - nw * z)) * (1 - Math.Cos(theta)) + z * Math.Cos(theta) + (-b * nu + a * nv - nv * x + nu * y) * Math.Sin(theta);


            Vector3 ans = new Vector3((float)rP[0], (float)rP[1], (float)rP[2]);
            return ans;


        }

        static void ModelSwapModule() {

            System.Windows.Forms.OpenFileDialog openFileDialog1;
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog1.Title = "Choose template seikiro model file.";
            //openFileDialog1.ShowDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog1.FileName);
                //openFileDialog1.
            }
            else
            {
                return;
            }

            FLVER b = FLVER.Read(openFileDialog1.FileName);



            System.Windows.Forms.OpenFileDialog openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog2.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            openFileDialog2.Title = "Choose source DS/BB model file.";
            //openFileDialog1.ShowDialog();

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(openFileDialog2.FileName);
                //openFileDialog1.
            }
            else
            {
                return;
            }
            FLVER src = FLVER.Read(openFileDialog2.FileName);



            Console.WriteLine(b.Header);

            Console.WriteLine("Seikiro unk is:" + b.SekiroUnk);



            Console.WriteLine("Material:");
            foreach (FLVER.Material m in b.Materials)
            {
                Console.WriteLine(m.Name);

            }

            foreach (FLVER.Mesh m in b.Meshes)
            {
                Console.WriteLine("Mesh#" + m.MaterialIndex);

            }

            //* new
            //b.Header.BigEndian = src.Header.BigEndian;
            

            //


            //X: is not the sword axis!!!
            //Y: ++ means closer to the hand!
            //Unit: in meter(?)


            //For Moonlight sword -> threaded cane, Y+0.5f

            Form f = new Form();

            Label l = new Label();
            l.Text = "x,y,z offset? Y= weapon length axis,Y+=Closer to hand";
            l.Size = new System.Drawing.Size(150, 15);
            l.Location = new System.Drawing.Point(10, 20);
            f.Controls.Add(l);


            TextBox t = new TextBox();
            t.Size = new System.Drawing.Size(70, 15);
            t.Location = new System.Drawing.Point(10, 60);
            t.Text = "0";
            f.Controls.Add(t);



            TextBox t2 = new TextBox();
            t2.Size = new System.Drawing.Size(70, 15);
            t2.Location = new System.Drawing.Point(10, 100);
            t2.Text =  "0";
            f.Controls.Add(t2);

            TextBox t3 = new TextBox();
            t3.Size = new System.Drawing.Size(70, 15);
            t3.Location = new System.Drawing.Point(10, 140);
            t3.Text = "0";
            f.Controls.Add(t3);

            CheckBox cb1 = new CheckBox();
            cb1.Size = new System.Drawing.Size(70, 15);
            cb1.Location = new System.Drawing.Point(10, 160);
            cb1.Text = "Copy Material";
            f.Controls.Add(cb1);

            CheckBox cb2 = new CheckBox();
            cb2.Size = new System.Drawing.Size(150, 15);
            cb2.Location = new System.Drawing.Point(10, 180);
            cb2.Text = "Copy Bones";
            f.Controls.Add(cb2);

            CheckBox cb3 = new CheckBox();
            cb3.Size = new System.Drawing.Size(150, 15);
            cb3.Location = new System.Drawing.Point(10, 200);
            cb3.Text = "Copy Dummy";
            f.Controls.Add(cb3);


            CheckBox cb4 = new CheckBox();
            cb4.Size = new System.Drawing.Size(350, 15);
            cb4.Location = new System.Drawing.Point(10, 220);
            cb4.Text = "All vertex weight to first bone";
            f.Controls.Add(cb4);

            f.ShowDialog();

            float x = float.Parse(t.Text);
            float y = float.Parse(t2.Text);
            float z = float.Parse(t3.Text);


            b.Meshes = src.Meshes;
            

            if (cb1.Checked)
                b.Materials = src.Materials;

            if (cb2.Checked)
                b.Bones = src.Bones;

            if (cb3.Checked)
                b.Dummies = src.Dummies;

            if (cb4.Checked)
            {
                for (int i = 0; i < b.Meshes.Count; i++)
                {

                    b.Meshes[i].BoneIndices = new List<int>();
                    b.Meshes[i].BoneIndices.Add(0);
                    b.Meshes[i].BoneIndices.Add(1);
                    b.Meshes[i].DefaultBoneIndex = 1;
                        foreach (FLVER.Vertex v in b.Meshes[i].Vertices)
                        {
                            for (int j = 0; j < v.Positions.Count; j++)
                            {
                            if (v.BoneWeights == null) { continue; }
                                v.Positions[j] = new System.Numerics.Vector3(0, 0, 0);
                                for (int k = 0; k < v.BoneWeights.Length; k++)
                                {
                                    v.BoneWeights[k] = 0;
                                v.BoneIndices[k] = 0;
                                
                                }
                            v.BoneIndices[0] = 1;
                            v.BoneWeights[0] = 1;
                        }
                        }
                        //targetFlver.Meshes[i].Vertices = new List<FLVER.Vertex>();

                }
            }

            foreach (FLVER.Mesh m in b.Meshes)
            {
                foreach (FLVER.Vertex v in m.Vertices)
                {
                    for (int i = 0; i < v.Positions.Count; i++)
                    {
                        v.Positions[i] = new System.Numerics.Vector3(v.Positions[i].X + x, v.Positions[i].Y + y, v.Positions[i].Z + z);
                    }
                }

            }



            b.Write(openFileDialog1.FileName + "n");
            MessageBox.Show("Swap completed!", "Info");
            //Console.WriteLine("End reading");
            //Application.Exit();

        }
    }
}