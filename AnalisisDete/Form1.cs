using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalisisDete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Lexico objLexico = new Lexico();
        string preanalisis = string.Empty;

        private void btnCompilar_Click(object sender, EventArgs e)
        {
            objLexico = new Lexico();
            objLexico.cadenaAEvaluar = txtAlgoritmo.Text;
            string compLexico = string.Empty;
            do
            {
                preanalisis = objLexico.ObtenerSiguienteComponenteLexico();
                
                switch (ObtenerTipoToken( preanalisis))
                {
                    case "HEX":
                        EvaluarExpresion();
                        break;
                }
            } while (preanalisis != "EOF");
            
            dgTablaSimbolos.DataSource = objLexico.dtSimbolos;
            dgErrores.DataSource = objLexico.dtErrores;
        }

        private void EvaluarExpresion()
        {
            EvaluarNumero();
            EvaluarOperadorComparacion();
            EvaluarNumero();
            EvaluarResto();
        }

        private void EvaluarNumero()
        {
            if(ObtenerTipoToken( preanalisis ) == "HEX")
            {
                MessageBox.Show(Convert.ToString(Convert.ToInt32(preanalisis, 16), 8));
                preanalisis = objLexico.ObtenerSiguienteComponenteLexico();
            }
            else
            {
                objLexico.RegistrarError("Se esperaba un numero hexadecimal");
            }
        }

        private void EvaluarResto()
        {
            if(ObtenerTipoToken(preanalisis) == "OPE_COM")
            {
                EvaluarOperadorComparacion();
                EvaluarNumero();
                EvaluarResto();
            }
        }
        
        private void EvaluarOperadorComparacion()
        {
            if (ObtenerTipoToken(preanalisis) == "OPE_COM")
            {
                preanalisis = objLexico.ObtenerSiguienteComponenteLexico();
            }
            else
            {
                objLexico.RegistrarError("Se esperaba operador aritmetico");
            }
        }

        private string ObtenerTipoToken(string lexema)
        {
            string tipoToken = string.Empty;
            DataRow[] elementos = objLexico.dtSimbolos.Select("Lexema = '" + lexema + "'");
            if(elementos.Count() > 0)
            {
                tipoToken = elementos[0]["Token"].ToString();
            }

            return tipoToken;
        }
    }
}
