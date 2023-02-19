using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    public partial class Form1 : Form
    {

        /*• Dışarıdan ={a,b} şeklinde alfabeyi alan (virgül ile ayrılmış),
        • Düzenli ifadenin ne olacağını da kullanıcının belirlediği,
        • Nihayetinde L kelimelerin dilini üretebilme kabiliyetine sahip ve ekranda kullanıcının istediği kadar
         kelimeyi görüntüleyen program kodunu üretiniz.
        • Not: Düzenli ifadenin alfabeden üretilebilir olmasını kontrol etmelidir!
        • Not: Verilen kelimenin L diline ait olup olmadığını kontrol edebilen ödevlere bonus verilecektir!
        • Örnek:
        • Alfabeyi giriniz ={ a,b<ENTER>}
        • Düzenli ifadeyi giriniz: (a+b)*a <ENTER>
        • L dilinin kaç kelimesini görmek istiyorsunuz? : 3 <ENTER>
        • Düzenli ifade  alfabesinden üretilebilir. Kelimeleriniz listeleniyor..
        • L={a,aa,ba}
          Kontrol edilecek kelimeyi giriniz: b <ENTER>
        

         */
        public Form1()
        {
            InitializeComponent();
        }
        string[] harfler = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "c", "j", "k", "l", "m", "n", "o", "p", "s", "t", "u", "v", "y", "z" };
        int[] sayilar = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        string virgul;
        static string alfabe;
        static string duzenlimetin;
        int kelimeSayisi = 0;
        string dizi2 = " ";
        private void button1_Click(object sender, EventArgs e)
        {
            virgul = ",";
            alfabe = textBox1.Text;
            int konum = alfabe.IndexOf(virgul);

            if (konum == -1)
            {
                MessageBox.Show("Oluşturulan Alfabede , bulunmamaktadır.Lütfen her harften sonra kulanın.");

            }
            duzenlimetin = textBox2.Text;
            int acikParantezIndex = duzenlimetin.IndexOf("(");
            int kapaliParantezKonum = duzenlimetin.IndexOf(")");
            int yildizindex = duzenlimetin.IndexOf("*");
            int artiindex = duzenlimetin.IndexOf("+");

            char[] karakterAyirma = duzenlimetin.ToCharArray();
            char yildiz = '*';
            string dizi = "";
            string pdizi = "";

            int a = 1;
            kelimeSayisi = Convert.ToInt32(textBox3.Text);

            var random = new Random();
          
            for (int m = 0; m < kelimeSayisi; m++)
            {

                for (int i = 0; i < karakterAyirma.Length; i++)

                {

                    if (karakterAyirma[i] == yildiz)
                    {

                        for (int j = 1; j < a; j++)
                        {

                            if (karakterAyirma[i - 1] == ')')
                            {
                                continue;
                            }

                            else
                            {
                                //eğer yıldız var ise yıldızdan bir önceki karakter artan bi şekilde yazdırılır
                                dizi = dizi + karakterAyirma[i - 1];
                            }

                        }


                    }

                    else if (karakterAyirma[i] == '(')

                    {
                        //eğer açık parantez varsa kapalı parantezden  sonra da yıldız varsa
                        //substring ile parantez arası parçalamır
                        //kesilen değerde + var ise artıya göre parçalnıp dizide tutulur.
                        //dizi elemanının rastgele seçilerek artan bi şekilde yazması amaçlanır
                        if (kapaliParantezKonum + 1 == yildizindex)
                        {
                            for (int j = 0; j < a; j++)
                            {
                                pdizi = duzenlimetin.Substring((acikParantezIndex + 1), (kapaliParantezKonum - 2));
                                string[] pdizi2 = pdizi.Split('+');
                                Random rd = new Random();
                                int abc = rd.Next(0, 2);
                                dizi = dizi + pdizi2[abc];
                                i = kapaliParantezKonum + 1;
                                //kapali parantezin dışına çıkıp işlem yapıyor

                            }
                        }
                        else
                        { 
                                continue;

                        }

                    }
                    else if (karakterAyirma[i] == ')')
                    {
                        //kapalı parantezde hiç bir işlem yapmaması gerekir
                        continue;
                    }
                    else if (karakterAyirma[i] == '+')
                    {
                       
                        i = artiindex + i;
                        //artıdan sonra geldiği karakter kadar gidip kapalı parantez 
                        //dışına çıkıp işlem yapıyor
                    }
                    else
                    {
                        //yukarıdaki ihtimallerden hiç bir değilse kontrol edilen karakter harftir ve yazılması geerkir
                        dizi = dizi + karakterAyirma[i];

                    }
                }
                dizi = dizi + " ";
                //satırın sonuna boşluk koyarak sonra bölünüyor

                a++;
            }
            for (int t = 0; t < dizi.Length; t++)
            {
                if (dizi[t] == ')')
                {
                    dizi2 = dizi.Replace(')', ' ');
                }

                else
                {
                    dizi2 = dizi;
                }
            }
            //dizideki boşlukların silinip alt alat yadırılması lazımdır
            string[] value1 = dizi2.Split(' ');
            foreach (string item in value1)
            {
                listBox1.Items.Add(item);
            }
            string[] value2 = alfabe.Split(',');
            foreach (string item in value2)
            {
                listBox2.Items.Add(item);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //texboxa girilen değerin listboxta olup olmadığını kontrol eden kod parçaçığı
            int sayac=0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().Contains(textBox4.Text))
                {
                       listBox1.SetSelected(i, true);
                    //yeni bir değer girince de aramaya devam etmesi için sayacç kontrolü yapılır
                    sayac += 1;
                    break;

                }
                else
                {
                    continue;
                }
            }
                if (sayac >= 1)
                {
                    MessageBox.Show("aradıgınız kelime vardır");

                }
                else
                {
                    MessageBox.Show("yoktur");
                }
                sayac = 0;
            
        }
    }
 }

