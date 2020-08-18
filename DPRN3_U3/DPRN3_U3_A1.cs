using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPRN3_U3
{
    public partial class DPRN3_U3_A1 : Form
    {
        public DPRN3_U3_A1()
        {
            InitializeComponent();
        }
        //EVENTO CLICK DEL BOTÓN "MOSTRAR"
        private void button1_Click(object sender, EventArgs e)
        {
            //SE INSTANCIA LA CLASE DATABASE
            DataBase db = new DataBase();
            //SE ASIGNA EL ORIGEN DE DATOS DEL DATAGRID COMO EL RESULTADO
            //DEL MÉTODO Get_Lista
            dataGridView1.DataSource = db.Get_Lista();
        }
    }
}
