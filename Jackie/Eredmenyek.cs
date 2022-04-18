using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jackie
{
    class Eredmenyek
    {
        int ev;
        int versenyek;
        int gyozelmek;
        int helyek;
        int elsoHelyek;
        int leggyorsabb;


        public Eredmenyek( string sor)
        {
            string[] daraboltSor = sor.Split('\t');
            Ev = Convert.ToInt32(daraboltSor[0].Trim());
            Versenyek = Convert.ToInt32(daraboltSor[1].Trim());
            Gyozelmek = Convert.ToInt32(daraboltSor[2].Trim());
            Helyek = Convert.ToInt32(daraboltSor[3].Trim());
            ElsoHelyek = Convert.ToInt32(daraboltSor[4].Trim());
            Leggyorsabb = Convert.ToInt32(daraboltSor[5].Trim());
        }

        public int Ev { get => ev; set => ev = value; }
        public int Versenyek { get => versenyek; set => versenyek = value; }
        public int Gyozelmek { get => gyozelmek; set => gyozelmek = value; }
        public int Helyek { get => helyek; set => helyek = value; }
        public int ElsoHelyek { get => elsoHelyek; set => elsoHelyek = value; }
        public int Leggyorsabb { get => leggyorsabb; set => leggyorsabb = value; }
    }
}
