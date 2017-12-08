using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BattleCity
{
    enum _Orientation
    {
        Up,
        Down,
        Left,
        Right
    }

    public partial class GameSession : Form
    {
        Hero_Tank hero;
        Entity[,] map = new Entity[26, 26];
        Point enemyPoint1, enemyPoint2;
        int counter, sec, min;
        
        public GameSession()
        {
            
            CreateLevel(1);
            InitializeComponent();
            counter = 0;
            this.KeyPreview = true;
            hero = new Hero_Tank(new Point(199,460));
            enemyPoint1 = new Point(100, 35);
            enemyPoint2 = new Point(400, 35);
            Program.entities.Add(hero);
        }
        
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Program.grph = e.Graphics;
          
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (map[i, j] != null)
                    {
                        map[i, j].Draw();
                    }
                }

            }
            
                for(int i = 0; i < Program.entities.Count; i++)
                {
                    var item = Program.entities[i];
                    item.Draw();
                    if (item.isDead)
                    {
                    lock (Program.entities)
                    {
                        Program.entities.Remove(item);
                    }
                }

                    if (item is _Tanks)
                    {
                        if (item is Enemy_Tank)
                        {
                            ((Enemy_Tank)item).isMoving = true;
                        }
                        ((_Tanks)item).move(map);
                    }
                    else if (item is _Bullet)
                    {
                        ((_Bullet)item).isFire = true;
                        ((_Bullet)item).move(map);
                    }
                }

        }
        
        private void GameSession_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W ||
                e.KeyCode == Keys.A ||
                e.KeyCode == Keys.S ||
                e.KeyCode == Keys.D)
            {
                hero.isMoving = false;
            }
        }

        private void GameSession_KeyDown(object sender, KeyEventArgs e)
        {
            hero.move(map, e);
            
        }

        public void CreateLevel(int level)
        {
            int x, y;
            x = y = 0;
            string levelFilePath = "1.txt";
            string[] fileStr = File.ReadAllLines(levelFilePath);
            Console.WriteLine(fileStr.Length);
            char[,] c = new char[26, 26];
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    c[i, j] = fileStr[i][j];
                }
            }

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (c[i,j] == '#')
                        map[i, j] = new _Blocks(new Point(x, y));
                    if (c[i, j] == '*')
                        map[i, j] = new Adamantium(new Point(x, y));
                    if (c[i, j] == 'B')
                        map[i, j] = new baseBlock(new Point(x, y));

                    x += 20;
                }
                y += 20;
                x = 0;
              
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            label6.Text = (((sec * 10 + 15)/2).ToString());
            sec += 1;
            if(sec == 60)
            {
                label4.Text = "00";
                sec = 0;
                min += 1;
            }
            label4.Text = sec.ToString();
            label2.Text = min.ToString();
            counter += 1;
            if (counter == 3)
            {  if(rnd.Next(2) == 1)
                {
                    Program.entities.Add(new Enemy_Tank(enemyPoint1));
                    counter = 0;
                }
            else
                    Program.entities.Add(new Enemy_Tank(enemyPoint2));
                counter = 0;
            }
        }
    }
}

    
    


