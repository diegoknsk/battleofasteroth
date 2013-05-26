using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using BattleofAstaroth.Utilidades;

namespace BattleofAstaroth.Personagens {
    public class Tiro {
        public Texture2D SpriteTiro { get; set; }
        public Vector2 Posicao { get; set; }
        public Vector2 Direcao { get; set; }
        public float Rotacao { get; set; }
        public int VelocidadeTiro { get; set; }
        public Point TamanhoTiro { get; set; }
        public bool StatusTiro  { get; set; } // se true se movimenta, se false, 

        public Tiro(Texture2D textura, Vector2 posicao, Vector2 direcao, float rotacao, int velocidadeTiro, Point tamanhoTiro) {
            this.SpriteTiro = textura;
            Posicao = posicao;
            Direcao = direcao;
            Rotacao = rotacao;
            VelocidadeTiro = velocidadeTiro;
            TamanhoTiro = tamanhoTiro;
            StatusTiro = true;
        }

        public void Atualiza() {
            Vector2 vetorMovimento = new Vector2(2,2);
            //if (Rotacao < 0.5 || Rotacao > 1.5) {
            //    vetorMovimento = new Vector2(2, -2);
            //} else {
            //    vetorMovimento = new Vector2(-2, 2);
            //}
            Posicao += Vector2.Multiply(Direcao, vetorMovimento);
            if (Posicao.X > Util.TamanhoTela.X || Posicao.X < 0 || Posicao.Y > Util.TamanhoTela.Y || Posicao.Y < 0) { //se o tiro está fora da tela, terá o status setado como false
                StatusTiro = false;
            }
        }

        public void Desenha(SpriteBatch sBatch) {
            sBatch.Draw(SpriteTiro, Posicao, null, Color.White, Rotacao, new Vector2(TamanhoTiro.X / 2, TamanhoTiro.Y / 2), Vector2.One, SpriteEffects.None, 0);
        }
        public Rectangle RetanguloNaTela {
            get {
                return new Rectangle((int)Posicao.X, (int)Posicao.Y, TamanhoTiro.X, TamanhoTiro.Y);
            }
        }
    }
}
