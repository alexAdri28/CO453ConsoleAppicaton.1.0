using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Author Alex Gordillo Adriano
/// Data 25/05/2021
/// </summary>

namespace Shooting_game
    // this a the varibles that im going to be using for this game 
{


    public bool goUp, godown, goleft, goright,gameOver = false;
    public string facing = "up"; 
    public double playerHealth = 100; 
    public int speed = 10, ammo = 10,zombieSpeed = 3,score = 0;
    public  Random rand = new Random();
    private List<PictureBox> zombiesList = new List<PictureBox>();
    public partial class ShootingGame : Form
    {
        private readonly int playerHealth;
        private string ammo;
        private bool goleft;
        private bool gameOver;
        private string score;
        private int speed;
        private bool goright;
        private bool goUp;
        private bool godown;
        private bool goLeft;
        private bool goRight;
        private PictureBox x;
        private int zombieSpeed;

        public int Gametimer { get; private set; }

        public ShootingGame()
        {
            InitializeComponent();
            RestartGame();


        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (playerHealth > 1) // if player health is greater than 1
            {
                HealthBar.Value = playerHealth;
                // assign the progress bar to the player health integer
            }
            else
            {

                player.Image = Properties.Resources.dead;
                Gametimer.Stop();
                gameOver = true;
            }

            txtAmmo.Text = "   Ammo:  " +ammo; // show the ammo amount on label 1
            txtScore.Text = "Kills: " + score; // show the total kills on the score

            // if the player health is less than 20
            if (playerHealth < 20)
            {
                HealthBar.ForeColor = System.Drawing.Color.Red; // change the progress bar colour to red. 
            }

            if (goleft == true && player.Left > 0)
            {
                player.Left -= speed;
                // if moving left is true AND pacman is 1 pixel more from the left 
                // then move the player to the LEFT
            }
            if (goright == true && player.Left < this.ClientSize.Width)
            {
                player.Left += speed;
                // if moving RIGHT is true AND player left + player width is less than 930 pixels
                // then move the player to the RIGHT
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
                // if moving TOP is true AND player is 60 pixel more from the top 
                // then move the player to the UP
            }

            if (godown == true && player.Top + player.Height < this.ClientSize.Width)
            {
                player.Top += speed;
                // if moving DOWN is true AND player top + player height is less than 700 pixels
                // then move the player to the DOWN
            }

            // this is to collect the ammo 
            foreach (Control x in this.Controls)
            {
                // if the X is a picture box and X has a tag AMMO

                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);

                        ((PictureBox)x).Dispose(); // 
                        ammo += 5;
                    }
                }

                // if the bullets hits the 4 borders of the game
                // if x is a picture box and x has the tag of bullet

                if (x is PictureBox && x.Tag == "bullet")
                {
                    // if the bullet is less the 1 pixel to the left
                    // if the bullet is more then 930 pixels to the right
                    // if the bullet is 10 pixels from the top
                    // if the bullet is 700 pixels to the buttom

                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x)); // remove the bullet from the display
                        ((PictureBox)x).Dispose(); // dispose the bullet from the program
                    }
                }
            }

            // below is the if statement which will be checking if the player hits a zombie

            if (x is PictureBox && x.Tag == "zombie")
            {

                // below is the if statament thats checking the bounds of the player and the zombie

                if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                {
                    playerHealth -= 1; // if the zombie hits the player then we decrease the health by 1
                }

                //move zombie towards the player picture box

                if (((PictureBox)x).Left > player.Left)
                {
                    ((PictureBox)x).Left -= zombieSpeed; // move zombie towards the left of the player
                    ((PictureBox)x).Image = Properties.Resources.zleft; // change the zombie image to the left
                }

                if (((PictureBox)x).Top > player.Top)
                {
                    ((PictureBox)x).Top -= zombieSpeed; // move zombie upwards towards the players top
                    ((PictureBox)x).Image = Properties.Resources.zup; // change the zombie picture to the top pointing image
                }
                if (((PictureBox)x).Left < player.Left)
                {
                    ((PictureBox)x).Left += zombieSpeed; // move zombie towards the right of the player
                    ((PictureBox)x).Image = Properties.Resources.zright; // change the image to the right image
                }
                if (((PictureBox)x).Top < player.Top)
                {
                    ((PictureBox)x).Top += zombieSpeed; // move the zombie towards the bottom of the player
                    ((PictureBox)x).Image = Properties.Resources.zdown; // change the image to the down zombie
                }
            }

            // below is the second for loop, this is nexted inside the first one
            // the bullet and zombie needs to be different than each other
            // then we can use that to determine if the hit each other

            foreach (Control j in this.Controls)
            {
                // below is the selection thats identifying the bullet and zombie

                const string V = "bullet";
                if (j is PictureBox && j.Tag == V && x is PictureBox && x.Tag == "zombie")
                {
                    // below is the if statement thats checking if bullet hits the zombie
                    if (x.Bounds.IntersectsWith(j.Bounds))
                    {
                        score++; // increase the kill score by 1 
                        this.Controls.Remove(j); // this will remove the bullet from the screen
                        j.Dispose(); // this will dispose the bullet all together from the program
                        this.Controls.Remove(x); // this will remove the zombie from the screen
                        x.Dispose(); // this will dispose the zombie from the program
                        makeZombies(); // this function will invoke the make zombies function to add another zombie to the game
                    }
                }
            }

        }

        private void makeZombies()
        {
            throw new NotImplementedException();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)

        {
            if (gameOver) return; // if game over is true then do nothing in this event

            // if the left key is pressed then do the following
            if (e.KeyCode == Keys.Left)
            {
                goleft = true; // change go left to true
                facing = "left"; //change facing to left
                player.Image = Properties.Resources.left; // change the player image to LEFT image
            }

            // end of left key selection

            // if the right key is pressed then do the following
            if (e.KeyCode == Keys.Right)
            {
                goright = true; // change go right to true
                facing = "right"; // change facing to right
                player.Image = Properties.Resources.right; // change the player image to right
            }
            // end of right key selection

            // if the up key is pressed then do the following
            if (e.KeyCode == Keys.Up)
            {
                facing = "up"; // change facing to up
                goup = true; // change go up to true
                player.Image = Properties.Resources.up; // change the player image to up
            }

            // end of up key selection

            // if the down key is pressed then do the following
            if (e.KeyCode == Keys.Down)
            {
                facing = "down"; // change facing to down
                godown = true; // change go down to true
                player.Image = Properties.Resources.down; //change the player image to down
            }



        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (gameOver) return; // if game is over then do nothing in this event

            // below is the key up selection for the left key
            if (e.KeyCode == Keys.Left)
            {
                goleft = false; // change the go left boolean to false
            }

            // below is the key up selection for the right key
            if (e.KeyCode == Keys.Right)
            {
                goright = false; // change the go right boolean to false
            }
            // below is the key up selection for the up key
            if (e.KeyCode == Keys.Up)
            {
                goup = false; // change the go up boolean to false
            }
            // below is the key up selection for the down key
            if (e.KeyCode == Keys.Down)
            {
                godown = false; // change the go down boolean to false
            }

            //below is the key up selection for the space key

            if (e.KeyCode == Keys.Space && ammo > 0)
            // in this if statement we are checking if the space bar is up and ammo is more than 0

            {
                DropAmmo--;
                ShootBullet(facing);
                // invoke the shoot function with the facing string inside it
                //facing will transfer up, down, left or right to the function and that will shoot the bullet that way. 

                if (ammo < 1)
                // if ammo is less than 1
                {
                    DropAmmo();
                    // invoke the drop ammo function
                }

            }
        }
        private void ShootBullet(string direction)

        {
            // this is the function thats makes the new bullets in this game

            Bullet shootBullet = new Bullet(); // create a new instance of the bullet class
            shootBullet.direction = direction; // assignment the direction to the bullet
            shootBullet.bulletLeft = player.Left + (player.Width / 2); // place the bullet to left half of the player
            shootBullet.bulletTop = player.Top + (player.Height / 2); // place the bullet on top half of the player
            shootBullet.MakeBullet(this); // run the function mkBullet from the bullet class. 

        }
        private void DropAmmo()
        {
            // this function will make a ammo image for this game

            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = randNum.Next(10,this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Width - ammo.Width);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);

            ammo.BringToFront();
            player.BringToFront();
        }
        private void MakeZombies()
        {
            // when this function is called it will make zombies in the game

            PictureBox zombie = new PictureBox(); // create a new picture box called zombie
            zombie.Tag = "zombie"; // add a tag to it called zombie
            zombie.Image = Properties.Resources.zdown; // the default picture for the zombie is zdown
            zombie.Left = randNum.Next(0, 900); // generate a number between 0 and 900 and assignment that to the new zombies left 
            zombie.Top = randNum.Next(0, 800); // generate a number between 0 and 800 and assignment that to the new zombies top
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // set auto size for the new picture box
            this.Controls.Add(zombie); // add the picture box to the screen
            player.BringToFront(); // bring the player to the front 

        }
        private void RestartGame()
        {
            player.Image = Properties.Resources.up;
           foreach(PictureBox i in zombielist)
            {
                this.Controls.Remove(i);
            }
            zombiesList.Clear();
            for(int i = 0;i< 3; i++)
            {
                MakeZombies();
            }
            goUp = false;
            godown = false;
            goLeft = false;
            goRight = false;

            playerHealth = 100;
            score = 0;
           ammo = 10;

            GameTimer.Start(); 
        }

    }
}