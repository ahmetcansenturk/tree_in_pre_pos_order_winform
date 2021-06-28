using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ahmetcansenturk_final2
{
    public partial class Form1 : Form
    {
       public class agacYapisi
        {
            public int deger;
            public agacYapisi sol;
            public agacYapisi sag;
            public static string degerler;
         
            public string getir() {
                degerler +=  deger + " > ";


                return degerler;
                
            }

         
        }
     public  class Agac
        {
            public agacYapisi kok;
            public int duzey = 0;
            public Agac()
            {
                kok = null;

            }
            public agacYapisi kokuGetir()
            {
                return kok;

            }
            public void preorder(agacYapisi a)
            {
                if (a != null)
                {
                    a.getir();
                    preorder(a.sol);
                    preorder(a.sag);
                }




            }
            public void inorder(agacYapisi a)
            {
                if (a != null)
                {
                    inorder(a.sol);
                    a.getir();
                    inorder(a.sag);
                }




            }
            public void postorder(agacYapisi a)
            {
                if (a != null)
                {

                    postorder(a.sol);
                    postorder(a.sag);
                    a.getir();
                }




            }


            public int Min(agacYapisi t)
            {
         t = kok;
                if (t != null)
                    while (t.sol != null)
                        t = t.sol;
                return t.deger;
            }
            public int Max(agacYapisi t)
            {
                t = kok;
                if (t != null)
                    while (t.sag != null)
                        t = t.sag;
                return t.deger;
            }
            public void ekle(int veri)
            {
                agacYapisi yeniAgac = new agacYapisi();
                yeniAgac.deger = veri;
                if (kok == null)
                {
                    kok = yeniAgac;
                }
                else
                {
                    agacYapisi bulunan = kok;
                    agacYapisi anne;



                    while (true)
                    {
                        anne = bulunan;
                        if (veri < bulunan.deger)
                        {
                            bulunan = bulunan.sol;
                            if (bulunan == null)
                            {
                                anne.sol = yeniAgac;

                                return;
                            }
                        }
                        else
                        {
                            bulunan = bulunan.sag;
                            if (bulunan == null)
                            {
                                anne.sag = yeniAgac;

                                return;
                            }

                        }
                    }








                }

            }
            public agacYapisi sil(agacYapisi agac , int deger)
            {
      
                if (agac== null)
                {
                    return null;
                }
                if (agac.deger == deger)
                {
                    if (agac.sol == null && agac.sag == null )
                    {
                        return null;
                    }
                    if (agac.sag != null)
                    {
                        agac.deger = Min(agac.sag);
                        agac.sag = sil(agac.sag, Min(agac.sag));
                        return agac;
                    }
                    agac.deger = Max(agac.sol);
                    agac.sol = sil(agac.sol, Max(agac.sol));
                    return agac;
                }
                if (agac.deger <deger)
                {
                    agac.sag = sil(agac.sag, deger);
                    return agac;
                }
                agac.sol = sil(agac.sol, deger);
                return agac;



            }

            //public agacYapisi yukseklik()
            //{
            //    int a = 0;
            //    int b = 0;
            //    while (true)
            //    {
            //        if (kok.sag !=null)
            //        {
            //            kok.sag = kok.sag.sag;


            //            if (kok.sag == null)
            //            {
            //                kok.sol 
            //            }

            //        }
            //    }


            //}
            
            public agacYapisi bul(int deger) {

                return bul2(kok, deger);
            }
            public agacYapisi bul2(agacYapisi kok, int deger) {
                if (kok == null)
                    return null;
                if (deger == kok.deger)
                {
               
                    return kok;
                }
                else if (deger < kok.deger)
                {
                    duzey++;
                    return bul2(kok.sol, deger);
                }
                else
                {
                    duzey++;
                    return bul2(kok.sag,deger);
                }
            }
    

        }
    
        public Form1()
        {
            InitializeComponent();
        }


        Agac agac = new Agac();
        int sayac = 0;
        
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

       
            agac.ekle(int.Parse(textBox1.Text));
            label1.Text = textBox1.Text;
            listBox1.Items.Add(textBox1.Text);
            listBox1.Visible = false;
            sayac++;
            textBox1.Text = "";
        }
            else
            {
                MessageBox.Show("Değer Giriniz");


            }

}

private void button5_Click(object sender, EventArgs e)
        {

            if (agac.kok != null)
            {
                agac.preorder(agac.kokuGetir());
                textBox4.Text = agacYapisi.degerler;
                agacYapisi.degerler = "";
                agac.inorder(agac.kokuGetir());
                textBox5.Text = agacYapisi.degerler;
                agacYapisi.degerler = "";

                agac.postorder(agac.kokuGetir());
                textBox6.Text = agacYapisi.degerler;
                agacYapisi.degerler = "";
                textBox7.Text = sayac.ToString();
                int a, b ;
         
                agac.bul(agac.Min(agac.kok));
                a = agac.duzey;
                agac.bul(agac.Max(agac.kok));
               b = agac.duzey;
                if (a>b)
                {
                    textBox8.Text = a.ToString();
                }
                else
                {
                    textBox8.Text = b.ToString();

                }

                textBox9.Text = agac.Max(agac.kokuGetir()).ToString() + " - " + agac.Min(agac.kokuGetir()).ToString();
            }
            else
            {
                MessageBox.Show("Ağaç yapısı oluşturulmamış");
            }
     
 

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (textBox3.Text != "")
            {
 agac.bul(int.Parse(textBox3.Text));
            label1.Text = agac.duzey.ToString();
            agac.duzey = 0;
            }
            else
            {
                MessageBox.Show("Değer Giriniz");


            }
               

        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                agac.sil(agac.kokuGetir(), int.Parse(textBox2.Text));
                listBox1.Items.Remove(textBox2.Text);
                label2.Text = textBox2.Text;
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Değer Giriniz");

            }




        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
