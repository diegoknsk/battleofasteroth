using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BattleofAstaroth.Utilidades;
using BattleofAstaroth.Componentes.Gerais;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using BattleofAstaroth.Componentes.Gerenciamento;

namespace BattleofAstaroth.Componentes.Telas {
    public class TelaEnredo : Tela {
        private Texture2D imgBotaoAvancar, imgBotaoVoltar;
        private Botao btnVoltar, btnAvancar;
       
        public TelaEnredo(Game jogo, SpriteFont fontePequena, SpriteFont fonteMedia)
            : base(jogo) {

            listaTextos = TextoJogo.RetornaListaHistoria(TextoJogoEnum.TextoEnredo);
            posInicialTexto = new Point(150, 150);
            //Habilitar();
            LoadContent();
            Desabilitar();        
            this.jogo = jogo;
        }
        public override void Update(GameTime gameTime) {

            KeyboardState tecla = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            Nucleo nucleo = (Nucleo)Game.Services.GetService(typeof(Nucleo));
            
            //é flag mouseEstava pressionado é necessária paracaso  o usuario tenha clicado em um botão de uma outra tela e avançou para a tela atual, então setamos ela como false, e só qdo o usuário larga o clique
            // deixamos a como false, e somente qdo tiver como false vai ser possível clicar nos botões novos
            if (mouse.LeftButton == ButtonState.Released) {
                mouseEstavaPressionado = false;
            }
            if (btnVoltar.VerificaColisaoMouse(new Point(mouse.X, mouse.Y)) && !mouseEstavaPressionado) {
                btnVoltar.checado = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                    nucleo.telaNova = TelasJogoEnum.TelaInicial;
            } else {
                btnVoltar.checado = false;
            }

            if (btnAvancar.VerificaColisaoMouse(new Point(mouse.X, mouse.Y)) && !mouseEstavaPressionado) {
                btnAvancar.checado = true;
                if (mouse.LeftButton == ButtonState.Pressed)
                    nucleo.telaNova = TelasJogoEnum.TelaJogo;
            } else {
                btnAvancar.checado = false;
            }

            base.Update(gameTime);

        }

        protected override void LoadContent() {

            ContentManager content = this.Game.Content;
            fundo = content.Load<Texture2D>("Imagens/Fundo/FundoTelaInicial");
            imgBotaoVoltar = content.Load<Texture2D>("Imagens/Botoes/btnC");
            imgBotaoAvancar = content.Load<Texture2D>("Imagens/Botoes/btnC");
            fonte = content.Load<SpriteFont>("Fontes/FontePequena");
            fonteMedia = content.Load<SpriteFont>("Fontes/FonteMedia");

            btnVoltar = new Botao(imgBotaoVoltar, new Point(100, 380), new Point(200, 100), "Voltar", Color.White, Color.Gray, fonteMedia, Color.Black);
            btnAvancar = new Botao(imgBotaoAvancar, new Point(500, 380), new Point(200, 100), "Avancar", Color.White, Color.Gray, fonteMedia, Color.Black);
            base.LoadContent();

        }

        public override void Draw(GameTime gameTime) {
            SpriteBatch sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sBatch.Draw(fundo, new Rectangle(0, 0, jogo.Window.ClientBounds.Width, jogo.Window.ClientBounds.Height), Color.White);
            sBatch.DrawString(fonte, "Tela enredo", new Vector2(0, 0),Color.White);
            Vector2 novaPos = new Vector2(posInicialTexto.X, posInicialTexto.Y);
            //escrever texto
            foreach (string linhaTexto in listaTextos) {
                sBatch.DrawString(fonte, linhaTexto, novaPos, cor);
                novaPos = new Vector2(novaPos.X, novaPos.Y + 30);
            }
            btnAvancar.Desenhar(sBatch);
            btnVoltar.Desenhar(sBatch);
            base.Draw(gameTime);
        }
    }
}
