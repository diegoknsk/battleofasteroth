using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleofAstaroth.Utilidades {
    public enum TextoJogoEnum {
        TextoEnredo,
        Vitoria,
        Derrota,
    }

    public static class TextoJogo {
        public static List<string> RetornaListaHistoria(TextoJogoEnum tipoTexto) {
            List<string> listaTexto = new List<string>();
            switch (tipoTexto) {
                case TextoJogoEnum.TextoEnredo:
                    listaTexto.Add("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
                    listaTexto.Add("Fusce aliquet vulputate sollicitudin");
                    listaTexto.Add("Praesent eget ante orci, in ultricies sem.");
                    break;
                case TextoJogoEnum.Vitoria:
                    break;
                case TextoJogoEnum.Derrota:
                    break;
                default:
                    break;
            }
            return listaTexto;
        }
    }
}
