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
        public int velocidade = 10;
        public int numerozinho;
        public PersonagemJogador(Vector2 direcao, Vector2 posicao, Point tamanho, Texture2D sprite, Texture2D texturaTiro)
        {

            Posicao = posicao;
            Tamanho = tamanho;
            SpritePersonagem = sprite;
            SpriteTiro = texturaTiro;
            this.Direcao = direcao;
            listaTirosNoJogo = new List<Tiro>();
            Angulo = 270; //posicao inicial do angulo
        }

        public void Atualiza()
        {
            numerozinho += 1;
            KeyboardState tecla = Keyboard.GetState();
            if (tecla.IsKeyDown(Keys.Up))
            {
                Angulo += 1;
            }
            else if (tecla.IsKeyDown(Keys.Down))
            {
                Angulo -= 1;
            }
            if (tecla.IsKeyDown(Keys.Space))
            {
                numerozinho += 1;
                
                Atacar();
                
            }
            foreach (Tiro tiro in listaTirosNoJogo)
            {
                tiro.Atualiza();
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
                if (tiro.StatusTiro == true)
                    listaTirosNoJogo.Add(tiro);

            }

            
        }
    }
