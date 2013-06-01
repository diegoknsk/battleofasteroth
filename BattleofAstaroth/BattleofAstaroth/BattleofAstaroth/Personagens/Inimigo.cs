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
    class Inimigo
    {
        List<Inimigo> inimigosGerados { get; set; }
        public Texture2D SpritePersonagem { get; set; }
        public Vector2 Posicao { get; set; }
        public Vector2 Direcao { get; set; }
        public Point Tamanho { get; set; }
        public float Velocidade ;
        public bool Vivo;
    
        public Inimigo(Vector2 posicao, Point tamanho, Texture2D spritePersonagem)
        {
            Posicao = posicao;
            Tamanho = tamanho;
            SpritePersonagem = spritePersonagem;
            Direcao = new Vector2(0.0f, 0.0f);
            Velocidade = 1.0f;
            Vivo = true;
        } 
        
         public void Atualiza()  
        {
            Posicao += Direcao * Velocidade;
        }
         public void Desenhar(SpriteBatch sBatch)
         {
             sBatch.Draw(SpritePersonagem, Posicao, Color.White);

         }
         public Rectangle areaColidir()
         {
             return new Rectangle((int)Posicao.X, (int)Posicao.Y, (int)SpritePersonagem.Width, (int)SpritePersonagem.Height);

         }


        
    }
}
