using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleofAstaroth.Componentes.Telas;
using Microsoft.Xna.Framework;

namespace BattleofAstaroth.Componentes.Gerenciamento {
    public enum TelasJogoEnum {
        TelaInicial,
        TelaCreditos,
        TelaEnredo,
        TelaJogo,
        TelaPause
    }

    /// <summary>
    /// Essa classe tem como função controlar as telas, que são games components
    /// </summary>
    public class Nucleo : Microsoft.Xna.Framework.GameComponent {

        public TelasJogoEnum telaAntiga { get; set; }
        public TelasJogoEnum telaNova { get; set; }

        #region Componentes que serão controlados pelo Nucleo
        private TelaInicial telaInicial;
        private TelaJogo telaJogo;
        private TelaEnredo telaEnredo;
        private TelaPause telaPause;
        #endregion

        public Nucleo(Game game)
            : base(game) {
            telaAntiga = TelasJogoEnum.TelaInicial;
            telaNova = TelasJogoEnum.TelaInicial;
            Game.Services.AddService(typeof(Nucleo), this); //adicionando nucleo como um componente comum em todoo jogo
        }

        public void CarregaComponentes() { //percorre todos os componentes, setando as telas caso encontre
            foreach (GameComponent gc in Game.Components) {
                if (gc is TelaInicial)
                    telaInicial = (TelaInicial)gc;
                else if (gc is TelaJogo)
                    telaJogo = (TelaJogo)gc;
                else if (gc is TelaEnredo)
                    telaEnredo = (TelaEnredo)gc;
                else if (gc is TelaPause)
                    telaPause = (TelaPause)gc;
               
            }
        }

        public override void Initialize() {
            CarregaComponentes();
            telaInicial.Habilitar();
            base.Initialize();
        }

        public override void Update(GameTime gameTime) {
            if (telaAntiga != telaNova) {
                CarregaComponentes();
                PausaComponentes();
            }
            base.Update(gameTime);
        }

        public void PausaComponentes() {
            telaAntiga = telaNova;
            switch (telaNova) {
                //necessário primeiro desabilitar para dps habilitar
                case TelasJogoEnum.TelaInicial:
                    telaEnredo.Desabilitar();
                    telaJogo.Desabilitar();
                    telaInicial.Habilitar();
                    telaPause.Desabilitar();
                    break;
                case TelasJogoEnum.TelaEnredo:
                    telaInicial.Desabilitar();
                    telaJogo.Desabilitar();
                    telaEnredo.Habilitar();
                    telaPause.Desabilitar();
                    break;
                case TelasJogoEnum.TelaJogo:
                    telaInicial.Desabilitar();
                    telaEnredo.Desabilitar();
                    telaJogo.Habilitar();
                    telaPause.Desabilitar();
                    
                    break;
                case TelasJogoEnum.TelaPause:
                    telaInicial.Desabilitar();
                    telaEnredo.Desabilitar();
                    telaJogo.Desabilitar();
                    telaPause.Habilitar();
                    break;
                default:
                    break;
            }
        }
    }
}
