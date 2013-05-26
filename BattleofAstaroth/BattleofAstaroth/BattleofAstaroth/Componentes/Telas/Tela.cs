using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BattleofAstaroth.Componentes.Telas {
      public class Tela : Microsoft.Xna.Framework.DrawableGameComponent {

        protected Song musicaFundo;
        protected SoundEffect efeito;
        
        protected Texture2D fundo;
        protected SpriteBatch spriteBatch;
        protected SpriteFont fonte,fontePequena,fonteMedia,fonteGrande;
        protected Color cor;
        protected Color corChecado;
        protected float framePorSegundo;
        protected float totalSegundos;
        //protected Cue musicaFundo;
        protected string nomeMusicaFundo;
        //protected SoundBank soundBank;
        protected Game jogo;
        protected List<string> listaTextos;
        protected Point posInicialTexto;
        protected bool mouseEstavaPressionado;
        protected bool teclaEstavaPressionada;

        public Tela(Game game)
            : base(game) {
            cor = Color.White;            
        }
        public void Habilitar() {
            Enabled = true;
            Visible = true;
            //musicaFundo = soundBank.GetCue(nomeMusicaFundo);
            mouseEstavaPressionado = true;
            teclaEstavaPressionada = true;
            UpdateOrder = 0;         
        }
        public void Desabilitar() {
            Enabled = false;
            Visible = false;
            UpdateOrder = 10;
 
        }
        public override void Initialize() {
            base.Initialize();
        }

        public override void Update(GameTime gameTime) {

            base.Update(gameTime);
        }
    }
}
