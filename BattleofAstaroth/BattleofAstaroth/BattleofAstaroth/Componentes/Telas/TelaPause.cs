using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BattleofAstaroth.Componentes.Gerenciamento;

namespace BattleofAstaroth.Componentes.Telas {
    public class TelaPause : Tela {

        public TelaPause(Game jogo, SpriteFont fontePequena, SpriteFont fonteMedia)
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
                nucleo.telaNova = TelasJogoEnum.TelaJogo;
            }
            base.Update(gameTime);
        }
        protected override void LoadContent() {

            ContentManager content = this.Game.Content;
            fundo = content.Load<Texture2D>("Imagens/Fundo/FundoTelaInicial");

            fonte = content.Load<SpriteFont>("Fontes/FontePequena");
            fonteMedia = content.Load<SpriteFont>("Fontes/FonteMedia");

            base.LoadContent();

        }

        public override void Draw(GameTime gameTime) {
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(fundo, new Rectangle(0, 0, jogo.Window.ClientBounds.Width, jogo.Window.ClientBounds.Height), Color.Gray);
            sBatch.DrawString(fonte, "Tela pause", new Vector2(0, 0), Color.White);

            base.Draw(gameTime);
        }
    }
}
