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
            double M = M0 * ((gm - bt) * t);
            double R = R0 * Math.Exp(alp * t);
            double x = R / M;
            double Y = M * x;
            return Y;


        }


        /*
      //КРИВАЯ M
        double oM()
        {


        }
        */


        //функция рисования ГРАФИКА

     
        //задача2
        void DrawGraph11(double M0, double R0, double alp, double bt, double gm)
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

            double xmin = 0;
            double xmax = 5;

            /*
            double ymin = -5;
            double ymax = 5;
            */


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
                tr_list.Add(x, o3(M0,gm,bt,x,R0,alp));


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
            LineItem myCurve1 = pane.AddCurve("Экономический рост", tr_list, Color.Blue, SymbolType.None);
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


            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();


            /*
            double l2 = Convert.ToDouble(trackBar6.Value);
            groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();
            */


            /*
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
            */


            //Отрисовываем графы
            //первый граф
           // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);
           // DrawGraph11(a, x1, y1, l1, l2, k1, k2);

          

            label1.Text = "В задаче представлена модель экономического роста с линейной производственной функцией";
            label2.Text = "Выполнил Пономарев С.А.";


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
      

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




            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();




            /*
            if (a > 0)
                label2.Text = "При положительных значениях A наблюдается склонность к развитию процессов";
            if (a < 0)
                label2.Text = "При отрицательных значениях наблюдается склонность к разложению";
        */
             
             
            /*
            else
                label1.Text = "";
            label2.Text = "";
            */
              
             
            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);
          //  DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();



           // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
         //   label1.Text = "";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double M0 = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Мощность в начальный элемент времени " + M0.ToString();

            double R0 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Число занятых работников в начальный момент времени" + R0.ToString();

            double alp = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Коэффицент прироста работников" + alp.ToString();

            double bt = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Коэффицент выбытия мощностей" + bt.ToString();

            double gm = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент времени ввода новых мощностей" + gm.ToString();



            // label1.Text = "Под сложностью структуры государства мы подразумеваем степень политической дифференциации, количество политических институтов";
            //   label1.Text = "";


            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(M0, R0, alp, bt, gm);

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
