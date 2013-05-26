using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using BattleofAstaroth.Componentes.Gerenciamento;
using BattleofAstaroth.Personagens;

namespace BattleofAstaroth.Componentes.Telas {
    //NESTA CLASSE ONDE DESENVOLVEREMOS TODA A LOGICA DO JOGO, SEM SE PREOCUPAR COM AS DEMAIS TELAS
    public class TelaJogo : Tela {
        private PersonagemJogador personagemJogador;

        public TelaJogo(Game jogo, SpriteFont fontePequena, SpriteFont fonteMedia)
            : base(jogo) {

            //Habilitar();
            LoadContent();
            Desabilitar();
            this.jogo = jogo;
        }
        public override void Initialize() {
            base.Initialize();

        }

        public override void Update(GameTime gameTime) {
            KeyboardState tecla = Keyboard.GetState();
            if (tecla.IsKeyUp(Keys.Escape)) {
                teclaEstavaPressionada = false;
            } else if (tecla.IsKeyDown(Keys.Escape) && !teclaEstavaPressionada) {
                Nucleo nucleo = (Nucleo)Game.Services.GetService(typeof(Nucleo));
                nucleo.telaNova = TelasJogoEnum.TelaPause;
            }
            personagemJogador.Atualiza();

         
            
            base.Update(gameTime);
        }

        protected override void LoadContent() {

            ContentManager content = this.Game.Content;
            fundo = content.Load<Texture2D>("Imagens/Fundo/FundoTelaInicial");

            fonte = content.Load<SpriteFont>("Fontes/FontePequena");
            fonteMedia = content.Load<SpriteFont>("Fontes/FonteMedia");
            personagemJogador = new PersonagemJogador(new Vector2(0, -1), new Vector2(350, 500), new Point(55, 117), content.Load<Texture2D>("Personagens/Nave1"), content.Load<Texture2D>("Efeitos/tiro01"));
            base.LoadContent();

        }

        public override void Draw(GameTime gameTime) {
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(fundo, new Rectangle(0, 0, jogo.Window.ClientBounds.Width, jogo.Window.ClientBounds.Height), Color.White);           
            sBatch.DrawString(fonte, "Tela jogo", new Vector2(0, 0), Color.White);
            personagemJogador.Desenha(sBatch);
            base.Draw(gameTime);
        }
    }
}
