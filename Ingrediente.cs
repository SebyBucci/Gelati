using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bucci.sebastian._4i.Gelati
{
    public enum TipoIngrediente {nessuno, Panna, Colorante, Aroma, PannaSoia, Cacao, Latte, Caffe, Mascarpone, Uovo }
    public class Ingrediente
    {
        public int idGelato { get; set; }
        public TipoIngrediente Tipo { get; set; }
        public string Valore { get; set; }

        public Ingrediente()
        {
            Tipo = TipoIngrediente.nessuno;
        }

        public Ingrediente(string riga)
        {
            string[] campi = riga.Split(';');

            int id = 0;
            int.TryParse(campi[0], out id);
            idGelato = id;

            TipoIngrediente c;
            Enum.TryParse(campi[1], out c);
            this.Tipo = c;
            this.Valore = campi[2];
        }
        public static Ingrediente MakeIngrediente(string riga)
        {
            string[] campi = riga.Split(';');
            TipoIngrediente c;
            Enum.TryParse(campi[1], out c);

            switch (c)
            {
                case TipoIngrediente.Panna:
                    return new IngredientePanna(riga);
                    break;
            }
            return new Ingrediente(riga);

        }



        public class IngredienteColorante : Ingrediente
            
        {
            private string colore;
            public IngredienteColorante() { }

            public IngredienteColorante(string riga)
                : base(riga)
            {
                colore = riga.Split(';')[3];
            }
        }


        public class IngredienteAroma : Ingrediente
        {
            public IngredienteAroma() { }

            public IngredienteAroma(string riga)
                : base(riga)
            { }
        }


        public class IngredientePannaSoia : Ingrediente
        {
            public IngredientePannaSoia() { }

            public IngredientePannaSoia(string riga)
                : base(riga)
            { }
        }


        public class IngredienteCacao : Ingrediente
        {
            public IngredienteCacao() { }

            public IngredienteCacao(string riga)
                : base(riga)
            { }
        }


        public class IngredientePanna : Ingrediente
        {
            private string calorie;
            public IngredientePanna() { }

            public IngredientePanna(string riga)
                : base(riga)
            {
                calorie = riga.Split(';')[3];
            }
        }

        public class IngredienteLatte : Ingrediente
        {
            private string lattosio;
            public IngredienteLatte() { }

            public IngredienteLatte(string riga)
                : base(riga)
            {
                lattosio = riga.Split(';')[3];
            }
        }

        public class IngredienteCaffe : Ingrediente
        {
            public IngredienteCaffe() { }

            public IngredienteCaffe(string riga)
                : base(riga)
            { }
        }

        public class IngredienteMascarpone : Ingrediente
        {
            public IngredienteMascarpone() { }

            public IngredienteMascarpone(string riga)
                : base(riga)
            { }
        }

        public class IngredienteUovo : Ingrediente
        {
            public IngredienteUovo() { }

            public IngredienteUovo(string riga)
                : base(riga)
            { }
        }


        public class Ingredienti : List<Ingrediente>
        {
            public Ingredienti() { }
            public Ingredienti(string nomeFile)
            {
                //Leggi persone..
                StreamReader fin = new StreamReader(nomeFile);
                fin.ReadLine();
                while (!fin.EndOfStream)
                    Add(new Ingrediente(fin.ReadLine()));

                fin.Close();
            }
        }
    }
}