using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace BattleofAstaroth.Personagens
{
    public class PersonagemJogador : Personagem
    {
        public List<Tiro> listaTirosNoJogo { get; set; }
        public Texture2D SpriteTiro { get; set; }
        public int numerozinho;
        public bool PodeAtirar;
        public bool FoiAtirado;

        public PersonagemJogador(Vector2 direcao, Vector2 posicao, Point tamanho, Texture2D sprite, Texture2D texturaTiro, bool podeAtirar, bool foiAtirado )
        {
            
            Posicao = posicao;
            Tamanho = tamanho;
            SpritePersonagem = sprite;
            SpriteTiro = texturaTiro;
            this.Direcao = direcao;
            listaTirosNoJogo = new List<Tiro>();
            Angulo = 270;
            PodeAtirar = podeAtirar;
            FoiAtirado = foiAtirado;
            
            
           
        }

        public void Atualiza()
        {
            numerozinho += 1;
            KeyboardState tecla = Keyboard.GetState();
            if (tecla.IsKeyDown(Keys.Right))
            {
                Angulo += 1;
                if (Angulo > 330)
                {
                    Angulo = 330;
                }
            }
            else if (tecla.IsKeyDown(Keys.Left))
            {
               Angulo -= 1;
                if (Angulo < 190)
                {
                    Angulo = 190;
                }
            }
            if (tecla.IsKeyDown(Keys.Space))
            {
                if (PodeAtirar == true)
                {
                  
                    Atacar();
                    
                  

                }
            }
            foreach (Tiro tiro in listaTirosNoJogo)
            {
               
                    tiro.Atualiza();
                    if (tiro.Posicao.Y < 500)
                    {
                        PodeAtirar = true;
                    }
                    else
                    {
                        PodeAtirar = false;

                    }
                
            }
            listaTirosNoJogo.RemoveAll(p => !p.StatusTiro);//remove tiros com status falso
        }
        
        public void Desenha(SpriteBatch sBatch)
        {
            
            foreach (Tiro tiro in listaTirosNoJogo)
            {
               
                tiro.Desenha(sBatch);
                

            }
            sBatch.Draw(SpritePersonagem, Posicao, new Rectangle(0, 0, Tamanho.X, Tamanho.Y), Color.White, this.Rotacao, new Vector2(Tamanho.X / 2, Tamanho.Y / 2), Vector2.One, SpriteEffects.None, 0);

        }
        public void Atacar()
        {

         
                Tiro tiro = new Tiro(SpriteTiro, new Vector2(Posicao.X, Posicao.Y), Direcao, Rotacao, 2, new Point(50, 10));
                //Tiro tiro = new Tiro(SpriteTiro, new Vector2(Posicao.X + ((Tamanho.X / 2) * ajusteAngulo), (Posicao.Y + ((Tamanho.Y / 2)) * ajusteAngulo)), Direcao, Rotacao, 2, new Point(50, 10));
             
                    listaTirosNoJogo.Add(tiro);

            }

            
        }
    }
