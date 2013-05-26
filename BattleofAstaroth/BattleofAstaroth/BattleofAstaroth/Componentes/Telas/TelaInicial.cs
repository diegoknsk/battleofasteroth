using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using BattleofAstaroth.Componentes.Gerais;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using BattleofAstaroth.Componentes.Gerenciamento;
using Microsoft.Xna.Framework.Input;

namespace BattleofAstaroth.Componentes.Telas {
    public class TelaInicial : Tela{
        private Texture2D imgBotao;
        private Botao btnIniciarEnredo;
        bool btnChecado;

        public TelaInicial(Game jogo, SpriteFont fonte)
            : base(jogo) {
            this.fonte = fonte;
            //soundBank = (SoundBank)Game.Services.GetService(typeof(SoundBank));
            //nomeMusicaFundo = "telaInicial";
            LoadContent();
            Habilitar();
            btnChecado = false;
            this.jogo = jogo;
        }
        public override void Initialize() {
            base.Initialize();

        }
        public override void Update(GameTime gameTime) {
            Nucleo nucleo = (Nucleo)Game.Services.GetService(typeof(Nucleo));
            MouseState mouse = Mouse.GetState();
            
            if (mouse.LeftButton == ButtonState.Released) {
                mouseEstavaPressionado = false;
            }
            if (btnIniciarEnredo.VerificaColisaoMouse(new Point(mouse.X, mouse.Y))) { //dependendo de onde o usuario clicar, iremos ativar uma nova tela
                btnIniciarEnredo.checado = true;
                if (mouse.LeftButton == ButtonState.Pressed && mouseEstavaPressionado == false)
                    nucleo.telaNova = TelasJogoEnum.TelaEnredo;
            } else {
                btnIniciarEnredo.checado = false;
            }
            base.Update(gameTime);
        }

        protected override void LoadContent() {

            ContentManager content = this.Game.Content;
            //musicaFundo = content.Load<Song>("Sons/Fundo/MusicaTelaCreditos");           
            fundo = content.Load<Texture2D>("Imagens/Fundo/FundoTelaInicial");
            imgBotao = content.Load<Texture2D>("Imagens/Botoes/btnC");
            fonte = content.Load<SpriteFont>("Fontes/FonteMedia");
            //btnCredito = new Botao(imgBotao, new Point(100, 380), new Point(200, 100), "Créditos", Color.White, Color.Gray, fonte, Color.Black);
            btnIniciarEnredo = new Botao(imgBotao, new Point(500, 380), new Point(200, 100), "Iniciar", Color.White, Color.Gray, fonte, Color.Black);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime) {

            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
        
            sBatch.Draw(fundo, new Rectangle(0, 0, jogo.Window.ClientBounds.Width , jogo.Window.ClientBounds.Height), Color.White);
            sBatch.DrawString(fonte, "Tela inicial", new Vector2(0, 0), Color.White); 
            btnIniciarEnredo.Desenhar(sBatch);
            
            base.Draw(gameTime);
        }
    }
}
