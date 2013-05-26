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


namespace BattleofAstaroth.Personagens {

    public class Personagem {
        public Texture2D SpritePersonagem { get; set; }
        public Vector2 Posicao { get; set; }
        private Vector2 direcao;
        public Vector2 Direcao {
            get { return direcao; }
            set {
                direcao = value;
            }
        }
        public Point Tamanho { get; set; }
        private float rotacao;
        public float Rotacao {
            get { return this.rotacao; }
        }
        private float angulo;

        public float Angulo {
            get { return this.angulo; }

            set {
                this.angulo = value;

                if (angulo < 0) {
                    this.angulo = 360;
                } else if (angulo > 360) {
                    this.angulo = 0;
                }
              
                this.rotacao = MathHelper.ToRadians(angulo);
               
                /*
                 * os metodos Math.Cos e Math.Sin recebem como parametro
                 * o angulo estando em radianos
                 * */
                direcao.X = (float)Math.Cos(rotacao);
                direcao.Y = (float)Math.Sin(rotacao);             

            }
        }

        public Rectangle RetanguloNaTela {
            get {
                return new Rectangle((int)Posicao.X, (int)Posicao.Y, Tamanho.X, Tamanho.Y);
            }
        }
    }
}
