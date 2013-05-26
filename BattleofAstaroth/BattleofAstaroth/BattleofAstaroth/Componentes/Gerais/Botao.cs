using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BattleofAstaroth.Componentes.Gerais {
    class Botao {
        public Rectangle retangBotao { get; set; }
        public string textoDentroBotao { get; set; }
        public Color cor { get; set; }
        public Color corChecado { get; set; }
        public Color corFonte { get; set; }
        public SpriteFont fonte { get; set; }
        public Texture2D img { get; set; }
        public Vector2 posTexto { get; set; }
        public bool checado { get; set; }
        public bool visivel { get; set; }
        public Botao(Texture2D img, Point posicao, Point tamanho, string texto, Color cor, Color corChecado, SpriteFont fonte, Color corFonte) {
            retangBotao = new Rectangle((int)posicao.X, (int)posicao.Y, tamanho.X, tamanho.Y);
            textoDentroBotao = texto;
            this.cor = cor;
            this.corChecado = corChecado;
            this.corFonte = corFonte;
            this.fonte = fonte;
            this.img = img;
            posTexto = new Vector2((posicao.X + (tamanho.X / 8)), (posicao.Y + (tamanho.Y / 5))); //medida para ajustar o texto em modelos genéricos q serão usados em todo o projeto
            checado = false;
            visivel = true;
        }

        public void Desenhar(SpriteBatch sBatch) {
            if (visivel) {
                sBatch.Draw(img, retangBotao, (checado) ? corChecado : cor); //se quiser mudar a cor do botão é só mudar o status de checado para n checado
                sBatch.DrawString(fonte, textoDentroBotao, posTexto, corFonte);
            }
        }

        public bool VerificaColisaoMouse(Point posMouse) {
            Rectangle retanguloMouse = new Rectangle(posMouse.X, posMouse.Y, 10, 15);
            return retangBotao.Intersects(retanguloMouse);
        }

        public bool VerificaColisaoRetangulo(Rectangle retanguloAlvo) {
            return retangBotao.Intersects(retanguloAlvo);
        }
    }
}
