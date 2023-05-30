using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalisisDete
{
    public class Lexico
    {
        public string cadenaAEvaluar = string.Empty;
        int apuntadorDelantero = 0;
        int inicioLexema = 0;
        int lineaActuual = 1;
        public DataTable dtSimbolos = new DataTable();
        public DataTable dtErrores = new DataTable();

        public Lexico()
        {
            dtErrores.Columns.Add("Error" , Type.GetType("System.String"));
            dtErrores.Columns.Add("LineaError", Type.GetType("System.String"));

            dtSimbolos.Columns.Add("Token", Type.GetType("System.String"));
            dtSimbolos.Columns.Add("Lexema", Type.GetType("System.String"));
            dtSimbolos.Columns.Add("Descripcion", Type.GetType("System.String"));
            
        }

        /// <summary>
        /// Obtiene el siguiente caracter de la cadena
        /// </summary>
        /// <returns>Un caracter, o EOF cuando termina</returns>
        private string ObtenerSiguienteCaracter()
        {
            string caractar = string.Empty;
            if(apuntadorDelantero < cadenaAEvaluar.Length)
            {
                caractar = cadenaAEvaluar.Substring(apuntadorDelantero, 1);
            }
            else
            {
                caractar = "EOF";
            }
            if(caractar == "\n")
            {
                lineaActuual++;
            }
            apuntadorDelantero++;
            return caractar;
        }

        private bool VerificarSiEsLetra(string caracter)
        {
            bool esLetra = false;
            if (caracter.Length == 1)
            {
                caracter = caracter.ToUpper();
                int ascci = Encoding.ASCII.GetBytes(caracter)[0];
                if(ascci>=65 && ascci<=70)
                {
                    esLetra = true;
                }

            }

            return esLetra;
            
        }

        private bool VerificarSiNumero(string caracter)
        {
            bool esNumero = false;
            if (caracter.Length == 1)
            {
                int ascci = Encoding.ASCII.GetBytes(caracter)[0];
                if (ascci >= 48 && ascci <= 57)
                {
                    esNumero = true;
                }

            }

            return esNumero;

        }

        private void RegistrarTablaSimbolos(string token , string lexema, string descripcion)
        {
            if (dtSimbolos.Select("Lexema = '" + lexema + "'").Count() == 0)
            {
                dtSimbolos.Rows.Add(new object[] { token, lexema, descripcion });
            }
        }

        public void RegistrarError(string error)
        {
            dtErrores.Rows.Add(new object[] { error , lineaActuual});
        }

        private int ObtenerInicioSiguienteDiagramaEstado(int estadoActual)
        {
            int estadoSiguienteDiagrama = 0;
            switch(estadoActual)
            {
                case 0:
                    estadoSiguienteDiagrama = 3;
                    apuntadorDelantero = inicioLexema;
                    break;
                default:
                    estadoSiguienteDiagrama = -1;
                    break;
            }

            return estadoSiguienteDiagrama;
        }

        public string ObtenerSiguienteComponenteLexico()
        {
            int estado = 0;
            string caracter = string.Empty;
            bool continuar = true;
            string componenteLexico = string.Empty;
            while(continuar)
            {
                switch(estado)
                {
                    case 0:
                        caracter = ObtenerSiguienteCaracter();
                        if(caracter == " " || caracter == "\n")
                        {
                            inicioLexema++;
                        }
                        else if(caracter == "EOF")
                        {
                            componenteLexico = "EOF";
                            continuar = false;

                        }else if(VerificarSiEsLetra(caracter) == true || VerificarSiNumero(caracter) == true)
                        {
                            estado = 1;
                        }
                        else
                        {
                            estado = ObtenerInicioSiguienteDiagramaEstado(estado);
                        }
                        break;
                    case 1:
                        caracter = ObtenerSiguienteCaracter();
                        if(VerificarSiEsLetra(caracter) == true || VerificarSiNumero(caracter) == true)
                        {
                            estado = 1;
                        }
                        else
                        {
                            estado = 2;
                        }
             
                        break;
                    case 2:
                        apuntadorDelantero--;
                        componenteLexico = cadenaAEvaluar.Substring(inicioLexema, (apuntadorDelantero - inicioLexema));
                        RegistrarTablaSimbolos("HEX", componenteLexico, "Numero hexadecimal declarado por el programador");
                        inicioLexema = apuntadorDelantero;
                        continuar = false;
                        break;
                    case 3:
                        caracter = ObtenerSiguienteCaracter();
                        if (caracter == ">")
                        {
                            estado = 4;
                        }
                        else if (caracter == "<")
                        {
                            estado = 5;
                        }
                        else if (caracter == "=")
                        {
                            estado = 6;
                        }
                        else
                        {
                            estado = ObtenerInicioSiguienteDiagramaEstado(estado);
                        }
                        break;
                    case 4: case 5: case 6: 
                        componenteLexico = cadenaAEvaluar.Substring(inicioLexema, (apuntadorDelantero - inicioLexema));
                        RegistrarTablaSimbolos("OPE_COM", componenteLexico, "Operador de comparacion");
                        inicioLexema = apuntadorDelantero;
                        continuar = false;
                        break;
                    case -1:
                        componenteLexico = cadenaAEvaluar.Substring(inicioLexema, (apuntadorDelantero - inicioLexema));
                        RegistrarError(componenteLexico + " no es valido");
                        inicioLexema = apuntadorDelantero;
                        continuar = false;
                        break;
                }                
            }

            return componenteLexico;
        }

    }
}
