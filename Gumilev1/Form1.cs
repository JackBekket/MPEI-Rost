using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Gumilev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         //   public TheVal1;
        }

        public double TheVal;
        public double Valx1;
        public double Valx2;
       

        //Объяснение для второй задачи:
        // M - еденица мощности, на которой производится продукт
        // R - общее число занятых работников
        // x - число работников на еденице мощности
        // Y - нац.продукт.
        // M0,R0 - нач значения, t - время.
        // alp,alpha - коэффицент прироста занятых работников
        // bt,beta - коэффицент выбытия мощностей (износ)
        // gm, gamma - коэффицент времени, требуемого на ввод новых мощностей.


        //ДОП.
        //Следует так же иметь ввиду, что функция Y рассчитывается
        //по принципу f(x) =x, т.к. f(x) трудно формализуема.
        //
        //

        //константы
      //  

        //функции рассчета точек МОДЕЛИ

        //для данной задачи


        /*
        //возвращает график развития гос-ва (структуры)
        double o1(double a, double x1, double l1, double y1, double k1)
        {
            return (a * x1 + l1 * y1 - k1 * Math.Pow(y1,2));
        }

        //возвращает график развития экономики
        double o2(double a, double x1, double l2, double y1, double k2)
        {
            return (a * y1 - l2 * x1 + k2 * Math.Pow(x1, 2));
        }
        */

        //МОДЕЛЬ РОСТА
        double o3(double M0, double gm, double bt, double t, double R0, double alp)
        {
            double M = M0 - ((gm - bt) * t);
            double R = R0 * Math.Exp(alp * t);
            double x = R / M;
            double Y = M * x;
            return Y;


        }

      


        //функция рисования ГРАФИКА

     
        //задача2
        void DrawGraph11(double a, double x1, double y1, double l1, double l2, double k1, double k2)
        {

            //При каждом скролле любого бегунка вызывается функция перерисовки графа, поэтому 
            //будет рационально сначала впихнуть сюда продукционные правила
            //вместо того, что бы прописывать их отдельно для каждого бегунка
            //Выполнил Пономарев С.А.

            //Правила




            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.XAxis.Title.Text = "t, Время";
            pane.YAxis.Title.Text = "Y, Экономический рост";
            pane.Title.Text = "Модель экономического роста";

            // Очистим компонент
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList tr_list = new PointPairList();
            PointPairList tr_list2 = new PointPairList();
            //       PointPairList tr_list3 = new PointPairList();

            double xmin = -5;
            double xmax = 5;

            double ymin = -5;
            double ymax = 5;

            /*
                //Двойной
                // Заполняем список точек
                for (double x = xmin; x <= xmax; x += 0.01)
                {
                    for (double y = ymin; y <= ymax; y += 0.01)
                    {
                        // добавим в список точку

                        //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                        tr_list.Add(x, o1(a, x, l1, y, k1));

                        tr_list2.Add(y, o2(a, x, l2, y, k2));
                        //orig
                        //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                        //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
                    }
                }
                */



            //Т.к. мы строим зависимость от времени, то график будет строится по x.
            // x в данном случае равен t.

            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку

                //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                tr_list.Add(x, o3(M0,gm,bt,x,R0,alp);


                //orig
                //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
            }

    



            /*
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                tr_list3.Add(x, n);
            }
              */

            // Создадим кривую 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve1 = pane.AddCurve("Развитие гос.структур", tr_list, Color.Blue, SymbolType.None);
          //  LineItem myCurve2 = pane.AddCurve("Развитие экономики", tr_list2, Color.Green, SymbolType.None);

            //      LineItem myCurve3 = pane.AddCurve("Минимально допустимый уровень лекарства", tr_list3, Color.Red, SymbolType.None);

            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();




        }





       

        //Функция загрузки формы
        //и чего-то еще
        // и еще чего-то еще
        private void Form1_Load(object sender, EventArgs e)
        {
            //Первый таб
            //ВВОДИМ ПЕРЕМЕНЫЕ

           // double m = trackBar11.Value * 0.001;

         //   double a = trackBar1.Value;

            double a = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Пассионарная напряженность= " + a.ToString();

            double x1 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();

            double y1 = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
           // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);

            /*
            label1.Text = "Объем препарата равен " + m.ToString();
            double v = Convert.ToDouble(trackBar12.Value) / 20 + 5;
            label12.Text = "Объем крови равен " + v.ToString();
            double k1 = (Convert.ToDouble(trackBar13.Value) - 20) / 10;
            label13.Text = "Коэффициент удаления первого препарата равен " + k1.ToString();
            double k2 = (Convert.ToDouble(trackBar14.Value) - 20) / 10;
            label14.Text = "Коэффициент удаления второго препарата равен " + k2.ToString();
            label15.Text = "Концентрация первого препарата убывает, т.к. коэффициент удаления (k1) > 0";
            label16.Text = "Концентрация второго препарата убывает, т.к. коэффициент удаления (k2) > 0";
            double n = trackBar15.Value * 0.00005;
            label17.Text = "Объем препарата равен " + n.ToString();
            DrawGraph1(m, v, k1, k2, n);
            */

            label1.Text = "В задаче представлена модель 'Политика - экономика', состоящая из системы двух дифференциальных уравнений";
            label2.Text = "Выполнил Пономарев С.А.";


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Пассионарная напряженность= " + a.ToString();
            //правила если-то


            // образец функции убывания/увеличивания значения трекбара!!!
            /*
            if (a < TheVal)
                label1.Text = "a убывает";
            if (a > TheVal)
                label1.Text = "a растет";
            */

            /*
            if (a < TheVal)
                label1.Text = "Большая пассионарная напряженность увеличивает скорость процессов развития";
            if (a > TheVal)
                label1.Text = "Меньшая пассионарная напряженность уменьшает скорость процессов развития";
            */

            


            double x1 = Convert.ToDouble(trackBar2.Value);
          //  groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();

            double y1 = Convert.ToDouble(trackBar3.Value);
       //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
        //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
       //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
        //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
         //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();


            if (a > 0)
                label2.Text = "При положительных значениях A наблюдается склонность к развитию процессов";
            if (a < 0)
                label2.Text = "При отрицательных значениях наблюдается склонность к разложению";
        
            /*
            else
                label1.Text = "";
            label2.Text = "";
            */
              
             
            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
          //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();
            

            double x1 = Convert.ToDouble(trackBar2.Value);
              groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
            //правила если-то

              






            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
         //   label1.Text = "";

            // образец функции убывания/увеличивания значения трекбара!!!
            /*
            if (a < TheVal)
                label1.Text = "a убывает";
            if (a > TheVal)
                label1.Text = "a растет";
            */

            if (a<0)
            label2.Text = "При отрицательном параметре пассионарной напряженности начинается разложение государства";

            if (a > 0)
                label2.Text = "При положительном параметре пассионарной напряженности государство развивается";

            if (a < 0 && x1 > Valx1)
                label2.Text = "Государства с более сложной структурой разлагаются быстрее";
            if (a < 0 && x1 > Valx1)
                label2.Text = "Государства с менее сложной структурой разлагаются медленее";

            if (x1 > y1 && a!=0)
                label1.Text = "Экономика всегда стремится дифференцироваться от государства, поэтому графы удаляется разнонаправлено";

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
          //  groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
           

            double y1 = Convert.ToDouble(trackBar3.Value);
                 groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();
            //правила если-то

            double l1 = Convert.ToDouble(trackBar4.Value);
            //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            label1.Text = "Под сложностью экономической структуры мы подразумеваем количество едениц экономических фондов";

            if (a < 0)
                label2.Text = "При отрицательном параметре пассионарной напряженности начинается разложение экономики";

            if (a > 0)
                label2.Text = "При положительном параметре пассионарной напряженности государство развивается";

            if (a < 0 && y1 > Valx2)
                label2.Text = "Экономики с более сложной структурой разлагаются быстрее";
            if (a < 0 && y1 > Valx2)
                label2.Text = "Экономики с менее сложной структурой разлагаются медленее";

            if (y1 > x1 && a!=0)
                label1.Text = "Экономика всегда стремится дифференцироваться от государства, поэтому графы удаляется разнонаправлено";



            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
         //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
            

            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
               groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();
            //  ПРАВИЛА







            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //ПРАВИЛА

            label2.Text="Закон насыщения потребностей - с удовлетворение потребности в каком-либо благе его ценность падает или убывает";

            if (l1 > k1)
                label1.Text = "Коэффицент вливания капитала в развитие гос-структуры не достиг предела";
            if (l1 == k1)
                label1.Text = "Коэффицент вливания капитала в развитие гос-структуры достиг предела";
            if (l1 < k1)
                label1.Text = "Коэффицент вливания капитала в развитие гос-структуры превысил предел, часть капитала расходуется впустую";




            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
         //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();
            


            double k1 = Convert.ToDouble(trackBar5.Value);
                 groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();
            //ПРАВИЛА


            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //ПРАВИЛА
            label2.Text = "усилия людей по укреплению политического режима за счет средств экономики";

            if (k1 < l1)
                label1.Text = "Коэффицент вливания в гос-структуру не достигнут";
            if (k1 == l1)
                label1.Text = "Коэффицент вливания в гос-структуру достиг предела";
            if (k1 > l1)
                label1.Text = "Коэффицент вливания в гос-структуру превысил предел, следует прекратить вливание";




            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();



            double k1 = Convert.ToDouble(trackBar5.Value);
          //  groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();
            


            double l2 = Convert.ToDouble(trackBar6.Value);
                groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();
            //ПРАВИЛА

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();


            label2.Text = "Закон насыщения потребностей - с удовлетворение потребности в каком-либо благе его ценность падает или убывает";

            if (l2 > k2)
                label1.Text = "Коэффицент вливания капитала в развитие экономики не достиг предела";
            if (l2 == k2)
                label1.Text = "Коэффицент вливания капитала в развитие экономики достиг предела";
            if (l2 < k2)
                label1.Text = "Коэффицент вливания капитала в развитие экономики превысил предел, часть капитала расходуется впустую";




            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();



            double k1 = Convert.ToDouble(trackBar5.Value);
            //  groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();



            double l2 = Convert.ToDouble(trackBar6.Value);
         //   groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();
            

            double k2 = Convert.ToDouble(trackBar7.Value);
               groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();
            //ПРАВИЛА

               label2.Text = "усилия людей по укреплению экономики режима за счет государственных вливаний";

               if (k1 < l1)
                   label1.Text = "Коэффицент вливания в экономику не достигнут";
               if (k1 == l1)
                   label1.Text = "Коэффицент вливания в экономику достиг предела";
               if (k1 > l1)
                   label1.Text = "Коэффицент вливания в экономику превысил предел, следует прекратить вливание";



            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
             TheVal = Convert.ToDouble(trackBar1.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            Valx1 = Convert.ToDouble(trackBar2.Value);
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            Valx2 = Convert.ToDouble(trackBar3.Value);
        }

        






    }

}
